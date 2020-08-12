using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(AdSoyad))]
    public class CariHesapKontak : XPObject
    {
        public CariHesapKontak(Session session) : base(session) { }

        #region Fields Region...
        private string dogumGunu;
        private string acikalama;
        private string ePosta;
        private string gSM;
        private string telefon;
        private CariHesaplar firma;
        private string soyad;
        private string adi;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adi
        {
            get
            {
                return adi;
            }
            set
            {
                SetPropertyValue(nameof(Adi), ref adi, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Soyad
        {
            get
            {
                return soyad;
            }
            set
            {
                SetPropertyValue(nameof(Soyad), ref soyad, value);
            }
        }

        [PersistentAlias("Concat([Adi],' ',[Soyad])")]
        public string AdSoyad => (string)EvaluateAlias(nameof(AdSoyad));

        [Association]
        public CariHesaplar Firma
        {
            get
            {
                return firma;
            }
            set
            {
                SetPropertyValue(nameof(Firma), ref firma, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                SetPropertyValue(nameof(Telefon), ref telefon, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GSM
        {
            get
            {
                return gSM;
            }
            set
            {
                SetPropertyValue(nameof(GSM), ref gSM, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EPosta
        {
            get
            {
                return ePosta;
            }
            set
            {
                SetPropertyValue(nameof(EPosta), ref ePosta, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Acikalama
        {
            get
            {
                return acikalama;
            }
            set
            {
                SetPropertyValue(nameof(Acikalama), ref acikalama, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DogumGunu
        {
            get
            {
                return dogumGunu;
            }
            set
            {
                SetPropertyValue(nameof(DogumGunu), ref dogumGunu, value);
            }
        }

    }
}