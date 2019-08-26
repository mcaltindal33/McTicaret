using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(EkBirim))]
    public class StoklarEkBirimleri : XPObject
    {
        public StoklarEkBirimleri(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<StoklarEkBirimleri> collection = new XPCollection<StoklarEkBirimleri>(Session);
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
        private double hacimM3;
        private double agirlik;
        private double katSayi;
        private BirimTurleri ekBirim;
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
        [Association]
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

        public BirimTurleri AnaBirim => Stok.Birim;

        public BirimTurleri EkBirim
        {
            get
            {
                return ekBirim;
            }
            set
            {
                SetPropertyValue(nameof(EkBirim), ref ekBirim, value);
            }
        }

        public double KatSayi
        {
            get
            {
                return katSayi;
            }
            set
            {
                SetPropertyValue(nameof(KatSayi), ref katSayi, value);
            }
        }

        public double Agirlik
        {
            get
            {
                return agirlik;
            }
            set
            {
                SetPropertyValue(nameof(Agirlik), ref agirlik, value);
            }
        }

        public double HacimM3
        {
            get
            {
                return hacimM3;
            }
            set
            {
                SetPropertyValue(nameof(HacimM3), ref hacimM3, value);
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

            public const string StokFieldName = "Stok";

            public Stoklar.FieldsClass Stok
            {
                get
                {
                    return new Stoklar.FieldsClass(GetNestedName(StokFieldName));
                }
            }

            public const string AnaBirimFieldName = "AnaBirim";

            public BirimTurleri.FieldsClass AnaBirim
            {
                get
                {
                    return new BirimTurleri.FieldsClass(GetNestedName(AnaBirimFieldName));
                }
            }

            public const string EkBirimFieldName = "EkBirim";

            public BirimTurleri.FieldsClass EkBirim
            {
                get
                {
                    return new BirimTurleri.FieldsClass(GetNestedName(EkBirimFieldName));
                }
            }

            public const string KatSayiFieldName = "KatSayi";

            public OperandProperty KatSayi
            {
                get
                {
                    return new OperandProperty(GetNestedName(KatSayiFieldName));
                }
            }

            public const string AgirlikFieldName = "Agirlik";

            public OperandProperty Agirlik
            {
                get
                {
                    return new OperandProperty(GetNestedName(AgirlikFieldName));
                }
            }

            public const string HacimM3FieldName = "HacimM3";

            public OperandProperty HacimM3
            {
                get
                {
                    return new OperandProperty(GetNestedName(HacimM3FieldName));
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