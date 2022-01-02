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
    [DefaultProperty(nameof(Tanim))]
    public class BankaHesaplari : BaseObject
    {
        public BankaHesaplari(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }
        #region Fields Region...
        private string kod;
        private string tanim;
        private string ıBAN;
        private string hesapNo;
        private BankaSubeleri sube;
        private Bankalar banka;
        #endregion

        [ImmediatePostData]
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

        [ImmediatePostData]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IBAN
        {
            get
            {
                return ıBAN;
            }
            set
            {
                SetPropertyValue(nameof(IBAN), ref ıBAN, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Tanim
        {
            get
            {
                return tanim;
            }
            set
            {
                SetPropertyValue(nameof(Tanim), ref tanim, value);
            }
        }

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
        [Association]
        public XPCollection<BankaHareket> HesapHareketleri => GetCollection<BankaHareket>(nameof(HesapHareketleri));
        protected override void OnSaving()
        {
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
            base.OnSaving();
        }
    }
}