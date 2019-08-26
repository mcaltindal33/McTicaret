using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CariHesapBankalar : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CariHesapBankalar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<CariHesapBankalar> collection = new XPCollection<CariHesapBankalar>(Session);
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

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:57
        public new class FieldsClass : XPObject.FieldsClass
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

            public const string TanimFieldName = "Tanim";

            public OperandProperty Tanim
            {
                get
                {
                    return new OperandProperty(GetNestedName(TanimFieldName));
                }
            }

            public const string HesapNoFieldName = "HesapNo";

            public OperandProperty HesapNo
            {
                get
                {
                    return new OperandProperty(GetNestedName(HesapNoFieldName));
                }
            }

            public const string SubeKoduFieldName = "SubeKodu";

            public OperandProperty SubeKodu
            {
                get
                {
                    return new OperandProperty(GetNestedName(SubeKoduFieldName));
                }
            }

            public const string IbanFieldName = "Iban";

            public OperandProperty Iban
            {
                get
                {
                    return new OperandProperty(GetNestedName(IbanFieldName));
                }
            }

            public const string BankaFieldName = "Banka";

            public Bankalar.FieldsClass Banka
            {
                get
                {
                    return new Bankalar.FieldsClass(GetNestedName(BankaFieldName));
                }
            }

            public const string SubeFieldName = "Sube";

            public BankaSubeleri.FieldsClass Sube
            {
                get
                {
                    return new BankaSubeleri.FieldsClass(GetNestedName(SubeFieldName));
                }
            }

            public const string CariFieldName = "Cari";

            public CariHesaplar.FieldsClass Cari
            {
                get
                {
                    return new CariHesaplar.FieldsClass(GetNestedName(CariFieldName));
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