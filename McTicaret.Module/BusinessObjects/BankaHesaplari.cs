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
            XPCollection<BankaHesaplari> collection = new XPCollection<BankaHesaplari>(Session);
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
                         Kod= $"000{collection.Count + 1}";
                        break;
                    case 5:
                       Kod  = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        Kod = $"0{collection.Count + 1}";
                        break;
                    default:
                       Kod  = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                Kod = $"000000{collection.Count + 1}";
            }

        }
        #region Fields Region...
        private string kod;
        private string tanim;
        private string ıBAN;
        private string hesapNo;
        private BankaSubeleri sube;
        private Bankalar banka;
        #endregion

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

        public new class FieldsClass : PersistentBase.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string BankaFieldName = "Banka";

            public Bankalar.FieldsClass Banka => new Bankalar.FieldsClass(GetNestedName(BankaFieldName));

            public const string SubeFieldName = "Sube";

            public BankaSubeleri.FieldsClass Sube => new BankaSubeleri.FieldsClass(GetNestedName(SubeFieldName));

            public const string HesapNoFieldName = "HesapNo";

            public OperandProperty HesapNo => new OperandProperty(GetNestedName(HesapNoFieldName));

            public const string IBANFieldName = "IBAN";

            public OperandProperty IBAN => new OperandProperty(GetNestedName(IBANFieldName));

            public const string TanimFieldName = "Tanim";

            public OperandProperty Tanim => new OperandProperty(GetNestedName(TanimFieldName));

            public const string KodFieldName = "Kod";

            public OperandProperty Kod => new OperandProperty(GetNestedName(KodFieldName));

            public const string HesapHareketleriFieldName = "HesapHareketleri";

            public OperandProperty HesapHareketleri => new OperandProperty(GetNestedName(HesapHareketleriFieldName));
        }

        public static new FieldsClass Fields
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