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
    public class FiyatTipleri : XPObject
    {
        public FiyatTipleri(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<FiyatTipleri> collection = new XPCollection<FiyatTipleri>(Session);
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
        private bool varsayilan;
        private double fiyatZami;
        private FiyatTipleri tabanTuru;
        private FiyatTuru fiyatOlusturmaTuru;
        private DovizTurleri fiyatDoviz;
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

        public DovizTurleri FiyatDoviz
        {
            get
            {
                return fiyatDoviz;
            }
            set
            {
                SetPropertyValue(nameof(FiyatDoviz), ref fiyatDoviz, value);
            }
        }

        public FiyatTuru FiyatOlusturmaTuru
        {
            get
            {
                return fiyatOlusturmaTuru;
            }
            set
            {
                SetPropertyValue(nameof(FiyatOlusturmaTuru), ref fiyatOlusturmaTuru, value);
            }
        }

        public FiyatTipleri TabanTuru
        {
            get
            {
                return tabanTuru;
            }
            set
            {
                SetPropertyValue(nameof(TabanTuru), ref tabanTuru, value);
            }
        }

        public double FiyatZami
        {
            get
            {
                return fiyatZami;
            }
            set
            {
                SetPropertyValue(nameof(FiyatZami), ref fiyatZami, value);
            }
        }

        public bool Varsayilan
        {
            get
            {
                return varsayilan;
            }
            set
            {
                SetPropertyValue(nameof(Varsayilan), ref varsayilan, value);
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

            public const string FiyatDovizFieldName = "FiyatDoviz";

            public DovizTurleri.FieldsClass FiyatDoviz
            {
                get
                {
                    return new DovizTurleri.FieldsClass(GetNestedName(FiyatDovizFieldName));
                }
            }

            public const string FiyatOlusturmaTuruFieldName = "FiyatOlusturmaTuru";

            public OperandProperty FiyatOlusturmaTuru
            {
                get
                {
                    return new OperandProperty(GetNestedName(FiyatOlusturmaTuruFieldName));
                }
            }

            public const string TabanTuruFieldName = "TabanTuru";

            public FieldsClass TabanTuru
            {
                get
                {
                    return new FieldsClass(GetNestedName(TabanTuruFieldName));
                }
            }

            public const string FiyatZamiFieldName = "FiyatZami";

            public OperandProperty FiyatZami
            {
                get
                {
                    return new OperandProperty(GetNestedName(FiyatZamiFieldName));
                }
            }

            public const string VarsayilanFieldName = "Varsayilan";

            public OperandProperty Varsayilan
            {
                get
                {
                    return new OperandProperty(GetNestedName(VarsayilanFieldName));
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