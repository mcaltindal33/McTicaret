using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Kod))]
    public class DovizTurleri : XPObject
    {
        public DovizTurleri(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private string sembol;
        private string aciklama;
        private string ayrintiliTanim;
        private string tanim;
        private string kod;
        #endregion

        [Size(3)]
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
        public string AyrintiliTanim
        {
            get
            {
                return ayrintiliTanim;
            }
            set
            {
                SetPropertyValue(nameof(AyrintiliTanim), ref ayrintiliTanim, value);
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Sembol
        {
            get
            {
                return sembol;
            }
            set
            {
                SetPropertyValue(nameof(Sembol), ref sembol, value);
            }
        }

        [Association]
        public XPCollection<DovizKurlari> DovizKuru => GetCollection<DovizKurlari>(nameof(DovizKuru));

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 16.03.2019 01:44
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

            public const string AyrintiliTanimFieldName = "AyrintiliTanim";

            public OperandProperty AyrintiliTanim
            {
                get
                {
                    return new OperandProperty(GetNestedName(AyrintiliTanimFieldName));
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

            public const string SembolFieldName = "Sembol";

            public OperandProperty Sembol
            {
                get
                {
                    return new OperandProperty(GetNestedName(SembolFieldName));
                }
            }

            public const string DovizKuruFieldName = "DovizKuru";

            public OperandProperty DovizKuru
            {
                get
                {
                    return new OperandProperty(GetNestedName(DovizKuruFieldName));
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