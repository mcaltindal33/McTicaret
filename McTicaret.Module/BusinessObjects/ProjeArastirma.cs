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
    public class ProjeArastirma : XPObject
    {
        public ProjeArastirma(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private Projeler proje;
        private string aciklama;
        private string kaynak;
        private string tanim;
        #endregion

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
        public string Kaynak
        {
            get
            {
                return kaynak;
            }
            set
            {
                SetPropertyValue(nameof(Kaynak), ref kaynak, value);
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
        public Projeler Proje
        {
            get
            {
                return proje;
            }
            set
            {
                SetPropertyValue(nameof(Proje), ref proje, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 15.03.2019 11:32
        public new class FieldsClass : XPObject.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string TanimFieldName = "Tanim";

            public OperandProperty Tanim
            {
                get
                {
                    return new OperandProperty(GetNestedName(TanimFieldName));
                }
            }

            public const string KaynakFieldName = "Kaynak";

            public OperandProperty Kaynak
            {
                get
                {
                    return new OperandProperty(GetNestedName(KaynakFieldName));
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

            public const string ProjeFieldName = "Proje";

            public Projeler.FieldsClass Proje
            {
                get
                {
                    return new Projeler.FieldsClass(GetNestedName(ProjeFieldName));
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