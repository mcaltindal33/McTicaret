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
    public class KasadanKasaya : Evraklar
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public KasadanKasaya(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            KasadanHareket = KasaHareketTuru.KasaCikisi;
            KasayaHareket = KasaHareketTuru.KasaGirisi;
            Islem = IslemTurleri.Transfer;
            Turu = EvrakTurleri.KasadanKasayaTransfer;
            Tarih = DateTime.Now;
            XPCollection<KasadanKasaya> collection = new XPCollection<KasadanKasaya>(Session);
            if (collection.Count > 0)
            {
                switch (collection.Count.ToString().Length)
                {
                    case 1:
                        BelgeNo = $"000000{collection.Count + 1}";
                        break;
                    case 2:
                        BelgeNo = $"00000{collection.Count + 1}";
                        break;
                    case 3:
                        BelgeNo = $"0000{collection.Count + 1}";
                        break;
                    case 4:
                        BelgeNo = $"000{collection.Count + 1}";
                        break;
                    case 5:
                        BelgeNo = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        BelgeNo = $"0{collection.Count + 1}";
                        break;
                    default:
                        BelgeNo = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                BelgeNo = $"000000{collection.Count + 1}";
            }

            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        #region Fields Region...
        private KasaHareket kasayaIslem;
        private KasaHareket kasadanIslem;
        private KasaHareketTuru kasayaHareket;
        private Kasalar kasaya;
        private KasaHareketTuru kasadanHareket;
        private Kasalar kasadan;
        #endregion

        public Kasalar Kasadan
        {
            get
            {
                return kasadan;
            }
            set
            {
                SetPropertyValue(nameof(Kasadan), ref kasadan, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareketTuru KasadanHareket
        {
            get
            {
                return kasadanHareket;
            }
            set
            {
                SetPropertyValue(nameof(KasadanHareket), ref kasadanHareket, value);
            }
        }
        public Kasalar Kasaya
        {
            get
            {
                return kasaya;
            }
            set
            {
                SetPropertyValue(nameof(Kasaya), ref kasaya, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareketTuru KasayaHareket
        {
            get
            {
                return kasayaHareket;
            }
            set
            {
                SetPropertyValue(nameof(KasayaHareket), ref kasayaHareket, value);
            }
        }

        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareket KasadanIslem
        {
            get
            {
                return kasadanIslem;
            }
            set
            {

                SetPropertyValue(nameof(KasadanIslem), ref kasadanIslem, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareket KasayaIslem
        {
            get
            {
                return kasayaIslem;
            }
            set
            {

                SetPropertyValue(nameof(KasayaIslem), ref kasayaIslem, value);
            }
        }

        protected override void OnSaving()
        {
            if (KasadanIslem == null)
            {
                KasaHareket KasadanIslems = new KasaHareket(Session)
                {
                    Aciklama = Aciklama,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = KasadanHareket,
                    Islem = Islem,
                    Kasa = Kasadan,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar
                };
                KasadanIslems.Save();
                kasadanIslem = KasadanIslems;
            }
            if (KasayaIslem == null)
            {
                KasaHareket KasayaIslems = new KasaHareket(Session)
                {
                    Aciklama = Aciklama,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = KasayaHareket,
                    Islem = Islem,
                    Kasa = Kasaya,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar
                };
                KasayaIslems.Save();
                KasayaIslem = KasayaIslems;
            }
            if(KasayaIslem != null)
            {
                KasaHareket k1 = KasayaIslem;
                k1.Tutar = Tutar;
                k1.Save();
            }
            if(KasadanIslem != null)
            {
                KasaHareket k2 = KasadanIslem;
                k2.Tutar = Tutar;
                k2.Save();
            }
            base.OnSaving();
        }
        protected override void OnDeleting()
        {
            if(KasadanIslem != null)
                KasadanIslem.Delete();
            if(KasayaIslem != null)
                KasayaIslem.Delete();
            base.OnDeleting();
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:20
        public new class FieldsClass : Evraklar.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KasadanFieldName = "Kasadan";

            public Kasalar.FieldsClass Kasadan
            {
                get
                {
                    return new Kasalar.FieldsClass(GetNestedName(KasadanFieldName));
                }
            }

            public const string KasadanHareketFieldName = "KasadanHareket";

            public OperandProperty KasadanHareket
            {
                get
                {
                    return new OperandProperty(GetNestedName(KasadanHareketFieldName));
                }
            }

            public const string KasayaFieldName = "Kasaya";

            public Kasalar.FieldsClass Kasaya
            {
                get
                {
                    return new Kasalar.FieldsClass(GetNestedName(KasayaFieldName));
                }
            }

            public const string KasayaHareketFieldName = "KasayaHareket";

            public OperandProperty KasayaHareket
            {
                get
                {
                    return new OperandProperty(GetNestedName(KasayaHareketFieldName));
                }
            }

            public const string KasadanIslemFieldName = "KasadanIslem";

            public KasaHareket.FieldsClass KasadanIslem
            {
                get
                {
                    return new KasaHareket.FieldsClass(GetNestedName(KasadanIslemFieldName));
                }
            }

            public const string KasayaIslemFieldName = "KasayaIslem";

            public KasaHareket.FieldsClass KasayaIslem
            {
                get
                {
                    return new KasaHareket.FieldsClass(GetNestedName(KasayaIslemFieldName));
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
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}