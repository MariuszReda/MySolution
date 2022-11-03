using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Module.BusinessObjects
{
  
    public class Result1
    {
        public Subject1 subject { get; set; }
        public string requestId { get; set; }
        public string requestDateTime { get; set; }
    }

    public class Root1
    {
        public Result1 result { get; set; }
    }

    public class Subject1
    {
        public string name { get; set; }

        string nip;
        public string Nip
        {
            get { return nip; }
            set { nip = value; }
        }


        public string statusVat { get; set; }
        public string regon { get; set; }
        public object pesel { get; set; }
        public string krs { get; set; }
        public object residenceAddress { get; set; }
        public string workingAddress { get; set; }
        public List<object> representatives { get; set; }
        public List<object> authorizedClerks { get; set; }
        public List<Partner1> partners { get; set; }
        public string registrationLegalDate { get; set; }
        public object registrationDenialBasis { get; set; }
        public object registrationDenialDate { get; set; }
        public object restorationBasis { get; set; }
        public object restorationDate { get; set; }
        public object removalBasis { get; set; }
        public object removalDate { get; set; }
        public List<string> accountNumbers { get; set; }
        public bool hasVirtualAccounts { get; set; }
    }


    public class Partner1
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nip { get; set; }
        public string Pesel { get; set; }
    }
}
