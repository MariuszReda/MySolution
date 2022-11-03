using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using MySolution.Module.BusinessObjects;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using DevExpress.Xpo;

namespace MySolution.Module.Controllers
{
    public class GusController : ViewController<DetailView>
    {
        public GusController()
        {
            SimpleAction getGusNip = new SimpleAction(this, "GetCompany", PredefinedCategory.Edit);
            getGusNip.Execute += GetGusNipAction_Execute;
        }

        private async void GetGusNipAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Subject currentObject = View.CurrentObject as Subject;


            if (currentObject.Nip != null)
            {

                var root1 = await MakeStringGreatAgain(currentObject.Nip);

                currentObject.Nip = root1.result.subject.Nip;
                currentObject.Name = root1.result.subject.name;
                currentObject.StatusVat = root1.result.subject.statusVat;
                currentObject.Regon = root1.result.subject.regon;
                currentObject.Pesel = root1.result.subject.pesel;
                currentObject.Krs = root1.result.subject.krs;
                currentObject.ResidenceAddress = root1.result.subject.residenceAddress;
                currentObject.WorkingAddress = root1.result.subject.workingAddress;
                currentObject.RegistrationLegalDate = root1.result.subject.registrationLegalDate;
                currentObject.HasVirtualAccounts = root1.result.subject.hasVirtualAccounts;

                var partners = root1.result.subject.partners.ToList();
                foreach (var item in partners)
                {
                    var partner = ObjectSpace.CreateObject<Partner>();
                    partner.CompanyName = item.CompanyName;
                    partner.Subject = currentObject;
                }

            }


        }



        private async Task<Root1> MakeStringGreatAgain(string nip)
        {
            try
            {
               var root = JsonConvert.DeserializeObject<Root1>(await TestGet(nip));
               return root;

            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                throw;
            }    
        }
        private string baseAddres = "https://wl-api.mf.gov.pl/api/search/nip/";

        private async Task<string> TestGet(string nip)
        {
           string testRequest = "";
            try
            {
                string test = "https://wl-test.mf.gov.pl/api/search/nip/2051545495?date=2019-05-17";
                //6442941205
                string data = "?date=2019-05-17";
                //var request = HttpWebRequest.CreateHttp(baseAddres + nip + data);
                var request = HttpWebRequest.CreateHttp(test);
               
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).ContinueWith(task =>
                {
                    var response = (HttpWebResponse)task.Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string responseText = responseReader.ReadToEnd();
                            testRequest = responseText.ToString();
                            responseReader.Close();

                        }

                   response.Close();
                });
                return testRequest;
            }
            catch (Exception ex) {
                return "";
            }


        }
    }
}
