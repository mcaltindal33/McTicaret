using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    public class BankaSubeleri : XPObject
    {
        public BankaSubeleri(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<BankaSubeleri> collection = new XPCollection<BankaSubeleri>(Session);
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
        private Bankalar banka;
        private string subeNo;
        private string sHIFTCode;
        private string tanim;
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
        public string SHIFTCode
        {
            get
            {
                return sHIFTCode;
            }
            set
            {
                SetPropertyValue(nameof(SHIFTCode), ref sHIFTCode, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SubeNo
        {
            get
            {
                return subeNo;
            }
            set
            {
                SetPropertyValue(nameof(SubeNo), ref subeNo, value);
            }
        }
        [Association]
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

        public new class FieldsClass : XPObject.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KodFieldName = "Kod";

            public OperandProperty Kod => new OperandProperty(GetNestedName(KodFieldName));

            public const string TanimFieldName = "Tanim";

            public OperandProperty Tanim => new OperandProperty(GetNestedName(TanimFieldName));

            public const string SHIFTCodeFieldName = "SHIFTCode";

            public OperandProperty SHIFTCode => new OperandProperty(GetNestedName(SHIFTCodeFieldName));

            public const string SubeNoFieldName = "SubeNo";

            public OperandProperty SubeNo => new OperandProperty(GetNestedName(SubeNoFieldName));

            public const string BankaFieldName = "Banka";

            public Bankalar.FieldsClass Banka => new Bankalar.FieldsClass(GetNestedName(BankaFieldName));
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