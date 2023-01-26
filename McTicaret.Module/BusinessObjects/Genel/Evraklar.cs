using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Model;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Evraklar : BaseObject
    {
        public Evraklar() { }
        public Evraklar(Session session) : base(session) { }
        #region Fields Region...
        string fTutarYazi;
        private string kod;
        private CariHesaplar cari;
        private string aciklama;
        private IslemTurleri ıslem;
        private DovizTurleri doviz;
        private double tutar;
        private string belgeNo;
        private EvrakTurleri turu;
        private DateTime tarih;
        #endregion
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
        [RuleUniqueValue]
        public DateTime Tarih
        {
            get
            {
                return tarih;
            }
            set
            {
                SetPropertyValue(nameof(Tarih), ref tarih, value);
            }
        }

        public EvrakTurleri Turu
        {
            get
            {
                return turu;
            }
            set
            {
                SetPropertyValue(nameof(Turu), ref turu, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BelgeNo
        {
            get
            {
                return belgeNo;
            }
            set
            {
                SetPropertyValue(nameof(BelgeNo), ref belgeNo, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double Tutar
        {
            get
            {
                return tutar;
            }
            set
            {
                SetPropertyValue(nameof(Tutar), ref tutar, value);
            }
        }

        public DovizTurleri Doviz
        {
            get
            {
                return doviz;
            }
            set
            {
                SetPropertyValue(nameof(Doviz), ref doviz, value);
            }
        }

        public IslemTurleri Islem
        {
            get
            {
                return ıslem;
            }
            set
            {
                SetPropertyValue(nameof(Islem), ref ıslem, value);
            }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Aciklama
        {
            get
            {
                return aciklama;
            }
            set
            {
                SetPropertyValue(nameof(Aciklama), ref aciklama, value);
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

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [VisibleInDetailView(false),VisibleInListView(false)]
        public string TutarYazi
        {
            get => fTutarYazi;
            set => SetPropertyValue(nameof(TutarYazi), ref fTutarYazi, value);
        }
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
            TutarYazi = GeneralValue.yaziyaCevir(Convert.ToDecimal(Tutar));
        }

    }
}