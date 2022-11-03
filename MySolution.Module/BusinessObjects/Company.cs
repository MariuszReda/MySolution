using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace MySolution.Module.BusinessObjects
{
    [NavigationItem("Company")]
    public class Result : BaseObject
    {
        public Result(Session session) : base(session) { }

        public Subject subject { get; set; }
        public string requestId { get; set; }
        public string requestDateTime { get; set; }
    }
    [NavigationItem("Company")]
    public class Root : BaseObject
    {
        public Root(Session session) : base(session) { }
        public Result result { get; set; }
    }
    [NavigationItem("Company")]

    public class Subject : BaseObject
    {
        public Subject(Session session) : base(session) { }

        string name;
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        string nip;
        public string Nip
        {
            get { return nip; }
            set { SetPropertyValue(nameof(Nip), ref nip, value); }
        }

        string statusVat;

        public string StatusVat
        {
            get { return statusVat; }
            set { SetPropertyValue(nameof(StatusVat), ref statusVat, value); }
        }


        string regon;
        public string Regon
        {
            get { return regon; }
            set { SetPropertyValue(nameof(Regon), ref regon, value); }
        }

        object pesel;
        public object Pesel
        {
            get { return pesel; }
            set { SetPropertyValue(nameof(Pesel), ref pesel, value); }
        }

        string krs;
        public string Krs
        {
            get { return krs; }
            set { SetPropertyValue(nameof(Krs), ref krs, value); }
        }

        object residenceAddress;
        public object ResidenceAddress
        {
            get { return residenceAddress; }
            set { SetPropertyValue(nameof(ResidenceAddress), ref residenceAddress, value); }
        }

        string workingAddress;
        public string WorkingAddress
        {
            get { return workingAddress; }
            set { SetPropertyValue(nameof(WorkingAddress), ref workingAddress, value); }
        }

        [AssociationAttribute("Customer-Partners")]      
        public XPCollection<Partner> Partners { get { return GetCollection<Partner>(nameof(Partners)); } }

        string registrationLegalDate;
        public string RegistrationLegalDate
        {
            get { return registrationLegalDate; }
            set { SetPropertyValue(nameof(RegistrationLegalDate), ref registrationLegalDate, value); }
        }

        bool hasVirtualAccounts;
        public bool HasVirtualAccounts
        {
            get { return hasVirtualAccounts; }
            set { SetPropertyValue(nameof(HasVirtualAccounts), ref hasVirtualAccounts, value); }
        }

    }
    [DefaultClassOptions]
    public class Partner : BaseObject
    {
        public Partner(Session session) : base(session)
        {        }
        string companyName;
        public string CompanyName
        {
            get { return CompanyName; }
            set { SetPropertyValue(nameof(CompanyName), ref companyName, value); }
        }
        Subject subject;

        [AssociationAttribute("Customer-Partners")]
        public Subject Subject
        {
            get { return subject; }
            set { SetPropertyValue(nameof(Subject), ref subject, value); }
        }

    }
}
