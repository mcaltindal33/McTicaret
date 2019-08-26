using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BankaHareket : Evraklar
    {
        public BankaHareket(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private BankaHareketTuru hareket;
        private BankaHesaplari banka;
        #endregion
        [Association]
        public BankaHesaplari Banka
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

        public BankaHareketTuru Hareket
        {
            get
            {
                return hareket;
            }
            set
            {
                SetPropertyValue(nameof(Hareket), ref hareket, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 17.03.2019 11:30
        public new class FieldsClass : Evraklar.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string BankaFieldName = "Banka";

            public BankaHesaplari.FieldsClass Banka
            {
                get
                {
                    return new BankaHesaplari.FieldsClass(GetNestedName(BankaFieldName));
                }
            }

            public const string HareketFieldName = "Hareket";

            public OperandProperty Hareket
            {
                get
                {
                    return new OperandProperty(GetNestedName(HareketFieldName));
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