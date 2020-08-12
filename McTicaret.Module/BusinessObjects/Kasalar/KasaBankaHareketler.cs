using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KasaBankaHareketler : Evraklar
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public KasaBankaHareketler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        #region Fields Region...
        private Kasalar kasa;
        private BankaHesaplari banka;
        private BankaHareket bankaIslem;
        private KasaHareket kasaIslem;
        private BankaHareketTuru bankaHarekets;
        private KasaHareketTuru kasaHareket;
        #endregion
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareketTuru KasaHarekets
        {
            get
            {
                return kasaHareket;
            }
            set
            {
                SetPropertyValue(nameof(KasaHareket), ref kasaHareket, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public BankaHareketTuru BankaHarekets
        {
            get
            {
                return bankaHarekets;
            }
            set
            {
                SetPropertyValue(nameof(BankaHarekets), ref bankaHarekets, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareket KasaIslem
        {
            get
            {
                return kasaIslem;
            }
            set
            {
                SetPropertyValue(nameof(KasaIslem), ref kasaIslem, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public BankaHareket BankaIslem
        {
            get
            {
                return bankaIslem;
            }
            set
            {
                SetPropertyValue(nameof(BankaIslem), ref bankaIslem, value);
            }
        }

        public BankaHesaplari Banka
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
        
        public Kasalar Kasa
        {
            get
            {
                return kasa;
            }
            set
            {
                SetPropertyValue(nameof(Kasa), ref kasa, value);
            }
        }
        protected override void OnSaving()
        {
            if(BankaIslem != null)
            {
                BankaHareket BankaIslems = new BankaHareket(Session)
                {
                    Banka = Banka,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = BankaHarekets,
                    Islem = Islem,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar,
                    Aciklama = Aciklama
                };
                BankaIslems.Save();
                BankaIslem = BankaIslems;
            }
            else
            {
                BankaIslem.Tutar = Tutar;
                BankaIslem.Save();
            }
            if(KasaIslem != null)
            {
                KasaHareket KasaIslems = new KasaHareket(Session)
                {
                    Kasa = Kasa,
                    Aciklama = Aciklama,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Tutar = Tutar,
                    Hareket = KasaHarekets,
                    Islem = Islem,
                    Tarih = Tarih,
                    Turu = Turu
                };
                KasaIslems.Save();
                KasaIslem = KasaIslems;
            }
            else
            {
                KasaIslem.Tutar = Tutar;
                KasaIslem.Save();
            }
            base.OnSaving();
            
         
           
        }
        protected override void OnDeleting()
        {
            base.OnDeleting();
            KasaIslem.Delete();
            BankaIslem.Delete();
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:16
        public new class FieldsClass : Evraklar.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KasaHareketsFieldName = "KasaHarekets";

            public OperandProperty KasaHarekets
            {
                get
                {
                    return new OperandProperty(GetNestedName(KasaHareketsFieldName));
                }
            }

            public const string BankaHareketsFieldName = "BankaHarekets";

            public OperandProperty BankaHarekets
            {
                get
                {
                    return new OperandProperty(GetNestedName(BankaHareketsFieldName));
                }
            }

            public const string KasaIslemFieldName = "KasaIslem";

            public KasaHareket.FieldsClass KasaIslem
            {
                get
                {
                    return new KasaHareket.FieldsClass(GetNestedName(KasaIslemFieldName));
                }
            }

            public const string BankaIslemFieldName = "BankaIslem";

            public BankaHareket.FieldsClass BankaIslem
            {
                get
                {
                    return new BankaHareket.FieldsClass(GetNestedName(BankaIslemFieldName));
                }
            }

            public const string BankaFieldName = "Banka";

            public BankaHesaplari.FieldsClass Banka
            {
                get
                {
                    return new BankaHesaplari.FieldsClass(GetNestedName(BankaFieldName));
                }
            }

            public const string KasaFieldName = "Kasa";

            public Kasalar.FieldsClass Kasa
            {
                get
                {
                    return new Kasalar.FieldsClass(GetNestedName(KasaFieldName));
                }
            }
        }

        public new static FieldsClass Fields
        {
            get
            {
                if (ReferenceEquals(_Fields, null))
                {
                    _Fields = (new FieldsClass());
                }

                return _Fields;
            }
        }

        private static FieldsClass _Fields;
    }
}