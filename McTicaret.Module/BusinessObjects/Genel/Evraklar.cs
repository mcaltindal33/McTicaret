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
        public Evraklar()
        {

        }
        public Evraklar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        #region Fields Region...
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

        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && Session.IsNewObject(this)
                        && string.IsNullOrEmpty(BelgeNo))
            {
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "MyServerPrefix");
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("Tur", Turu));
                if (tanim != null)
                {
                    BelgeNo = string.Format("{0}{1:D8}", tanim.Tanim, nextSequence);
                }
                else
                {
                    BelgeNo = string.Format("{0:D8}", nextSequence);
                }
            }
            base.OnSaving();
        }

    }
}