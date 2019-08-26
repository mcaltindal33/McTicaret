using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class BirimFiyatlar : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public BirimFiyatlar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<BirimFiyatlar> collection = new XPCollection<BirimFiyatlar>(Session);
            if (collection.Count > 0)
            {
                switch (collection.Count.ToString().Length)
                {
                    case 1:
                        Kod = $"000000{collection.Count + 1}";
                        break;
                    case 2:
                        Kod = $"00000{collection.Count + 1}";
                        break;
                    case 3:
                        Kod = $"0000{collection.Count + 1}";
                        break;
                    case 4:
                        Kod = $"000{collection.Count + 1}";
                        break;
                    case 5:
                        Kod = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        Kod = $"0{collection.Count + 1}";
                        break;
                    default:
                        Kod = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                Kod = $"000000{collection.Count + 1}";
            }
        }
        #region Fields Region...
        private double yeniFiyat;
        private double karOrani;
        private double birimFiyat;
        private BirimTurleri birim;
        private string aciklama;
        private DovizTurleri doviz;
        private DateTime tarih;
        private FiyatTipleri fiyatTipi;
        private Stoklar stok;
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
        [VisibleInListView(false)]
        public Stoklar Stok
        {
            get
            {
                return stok;
            }
            set
            {
                SetPropertyValue(nameof(Stok), ref stok, value);
            }
        }

        public FiyatTipleri FiyatTipi
        {
            get
            {
                return fiyatTipi;
            }
            set
            {
                SetPropertyValue(nameof(FiyatTipi), ref fiyatTipi, value);
            }
        }

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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        public BirimTurleri Birim
        {
            get
            {
                return birim;
            }
            set
            {
                SetPropertyValue(nameof(Birim), ref birim, value);
            }
        }

        public double BirimFiyat
        {
            get
            {
                return birimFiyat;
            }
            set
            {
                SetPropertyValue(nameof(BirimFiyat), ref birimFiyat, value);
            }
        }

        public double KarOrani
        {
            get
            {
                return karOrani;
            }
            set
            {
                SetPropertyValue(nameof(KarOrani), ref karOrani, value);
            }
        }

        public double YeniFiyat
        {
            get
            {
                return yeniFiyat;
            }
            set
            {
                SetPropertyValue(nameof(YeniFiyat), ref yeniFiyat, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:57
        public new class FieldsClass : PersistentBase.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KodFieldName = "Kod";

            public OperandProperty Kod
            {
                get
                {
                    return new OperandProperty(GetNestedName(KodFieldName));
                }
            }

            public const string StokFieldName = "Stok";

            public Stoklar.FieldsClass Stok
            {
                get
                {
                    return new Stoklar.FieldsClass(GetNestedName(StokFieldName));
                }
            }

            public const string FiyatTipiFieldName = "FiyatTipi";

            public FiyatTipleri.FieldsClass FiyatTipi
            {
                get
                {
                    return new FiyatTipleri.FieldsClass(GetNestedName(FiyatTipiFieldName));
                }
            }

            public const string TarihFieldName = "Tarih";

            public OperandProperty Tarih
            {
                get
                {
                    return new OperandProperty(GetNestedName(TarihFieldName));
                }
            }

            public const string DovizFieldName = "Doviz";

            public DovizTurleri.FieldsClass Doviz
            {
                get
                {
                    return new DovizTurleri.FieldsClass(GetNestedName(DovizFieldName));
                }
            }

            public const string AciklamaFieldName = "Aciklama";

            public OperandProperty Aciklama
            {
                get
                {
                    return new OperandProperty(GetNestedName(AciklamaFieldName));
                }
            }

            public const string BirimFieldName = "Birim";

            public BirimTurleri.FieldsClass Birim
            {
                get
                {
                    return new BirimTurleri.FieldsClass(GetNestedName(BirimFieldName));
                }
            }

            public const string BirimFiyatFieldName = "BirimFiyat";

            public OperandProperty BirimFiyat
            {
                get
                {
                    return new OperandProperty(GetNestedName(BirimFiyatFieldName));
                }
            }

            public const string KarOraniFieldName = "KarOrani";

            public OperandProperty KarOrani
            {
                get
                {
                    return new OperandProperty(GetNestedName(KarOraniFieldName));
                }
            }

            public const string YeniFiyatFieldName = "YeniFiyat";

            public OperandProperty YeniFiyat
            {
                get
                {
                    return new OperandProperty(GetNestedName(YeniFiyatFieldName));
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