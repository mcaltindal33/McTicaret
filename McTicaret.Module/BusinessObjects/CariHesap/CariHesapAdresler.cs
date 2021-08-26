using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

using System;
using System.ComponentModel;
using System.Linq;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Adres))]
    public class CariHesapAdresler : XPObject
    {

        #region Fields Region...
        private bool varsayilanSevk;
        private bool varsayilan;
        private AdresTurleri adresTur;
        private string adres;
        private CariHesaplar cariHesap;
        #endregion

        public CariHesapAdresler(Session session) : base(session) { }


        #region Properties Region..


        public AdresTurleri AdresTur
        {
            get
            {
                return adresTur;
            }
            set
            {
                SetPropertyValue(nameof(AdresTur), ref adresTur, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adres
        {
            get
            {
                return adres;
            }
            set
            {
                SetPropertyValue(nameof(Adres), ref adres, value);
            }
        }

        [Association]
        public CariHesaplar CariHesap
        {
            get
            {
                return cariHesap;
            }
            set
            {
                SetPropertyValue(nameof(CariHesap), ref cariHesap, value);
            }
        }

        public bool Varsayilan
        {
            get
            {
                return varsayilan;
            }
            set
            {
                SetPropertyValue(nameof(Varsayilan), ref varsayilan, value);
            }
        }
        public bool VarsayilanSevk
        {
            get
            {
                return varsayilanSevk;
            }
            set
            {
                SetPropertyValue(nameof(VarsayilanSevk), ref varsayilanSevk, value);
            }
        }

        #endregion

    }
}