using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CariHesapBankalar : XPObject
    { 
        public CariHesapBankalar(Session session) : base(session) { }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("TabloTipi", this.GetType()));
                if (tanim != null)
                {
                    string Kodu = tanim.Kodu + tanim.Ayrac;
                    if (tanim.Yil)
                        Kodu += DateTime.Now.Year + tanim.Ayrac;
                    if (tanim.Ay)
                        Kodu += DateTime.Now.Month + tanim.Ayrac;
                    if (tanim.Gun)
                        Kodu += DateTime.Now.Day + tanim.Ayrac;
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"{Kodu}Prefix");
                    Kodu = $"{Kodu}{dist:D5}";
                    Kod = Kodu;
                }
                else
                {
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"{GetType().Name}Prefix");
                    Kod = $"{dist:D5}";
                }
            }

        }
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