using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CariHesapBankalar : XPObject
    { 
        public CariHesapBankalar(Session session) : base(session) { }
        #region Fields Region...
        private CariHesaplar cari;
        private BankaSubeleri sube;
        private Bankalar banka;
        private string ıban;
        private string hesapNo;
        private string kod;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get
            {
                return kod;
            }
            set
            {
                SetPropertyValue(nameof(Kod), ref kod, value);
            }
        }

        [PersistentAlias("Concat([Banka],' - ',[Sube],' - ',[HesapNo])")]
        public string Tanim => (string)EvaluateAlias(nameof(Tanim));

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string HesapNo
        {
            get
            {
                return hesapNo;
            }
            set
            {
                SetPropertyValue(nameof(HesapNo), ref hesapNo, value);
            }
        }
        [PersistentAlias("[Sube.SubeNo]")]
        public string SubeKodu => (string)EvaluateAlias(nameof(SubeKodu));

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Iban
        {
            get
            {
                return ıban;
            }
            set
            {
                SetPropertyValue(nameof(Iban), ref ıban, value);
            }
        }

        public Bankalar Banka
        {
            get
            {
                return banka;
            }
            set
            {
                SetPropertyValue(nameof(Banka), ref banka, value);
            }
        }

        public BankaSubeleri Sube
        {
            get
            {
                return sube;
            }
            set
            {
                SetPropertyValue(nameof(Sube), ref sube, value);
            }
        }

        [Association]
        public CariHesaplar Cari
        {
            get
            {
                return cari;
            }
            set
            {
                SetPropertyValue(nameof(Cari), ref cari, value);
            }
        }

    }
}