using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CariHesapGruplari : XPObject
    {
        public CariHesapGruplari(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<CariHesapGruplari> collection = new XPCollection<CariHesapGruplari>(Session);
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
        private string aciklama;
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
        [Association]
        public XPCollection<CariHesaplar> CariHesap
        {
            get
            {
                return GetCollection<CariHesaplar>(nameof(CariHesap));
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

            public const string AciklamaFieldName = "Aciklama";

            public OperandProperty Aciklama
            {
                get
                {
                    return new OperandProperty(GetNestedName(AciklamaFieldName));
                }
            }

            public const string CariHesapFieldName = "CariHesap";

            public OperandProperty CariHesap
            {
                get
                {
                    return new OperandProperty(GetNestedName(CariHesapFieldName));
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