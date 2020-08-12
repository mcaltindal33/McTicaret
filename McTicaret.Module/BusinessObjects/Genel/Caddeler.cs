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
    public class Caddeler : XPObject
    {
        public Caddeler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private Mahalle mahalle;
        private string tanim;
        private string kodu;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kodu
        {
            get
            {
                return kodu;
            }
            set
            {
                SetPropertyValue(nameof(Kodu), ref kodu, value);
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
        [Association]
        public Mahalle Mahalle
        {
            get
            {
                return mahalle;
            }
            set
            {
                SetPropertyValue(nameof(Mahalle), ref mahalle, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 16.03.2019 01:44
        public new class FieldsClass : XPObject.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KoduFieldName = "Kodu";

            public OperandProperty Kodu
            {
                get
                {
                    return new OperandProperty(GetNestedName(KoduFieldName));
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

            public const string MahalleFieldName = "Mahalle";

            public Mahalle.FieldsClass Mahalle
            {
                get
                {
                    return new Mahalle.FieldsClass(GetNestedName(MahalleFieldName));
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