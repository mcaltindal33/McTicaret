using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class DovizKurlari : XPObject
    {
        public DovizKurlari(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private double efektifSatis;
        private double efektifAlis;
        private double satis;
        private double alis;
        private double kur;
        private DateTime tarih;
        private DovizTurleri doviz;
        #endregion
        [Association]
        public DovizTurleri Doviz
        {
            get
            {
                return doviz;
            }
            set
            {
                SetPropertyValue(nameof(Doviz), ref doviz, value);
            }
        }

        public DateTime Tarih
        {
            get
            {
                return tarih;
            }
            set
            {
                SetPropertyValue(nameof(Tarih), ref tarih, value);
            }
        }

        public double Kur
        {
            get
            {
                return kur;
            }
            set
            {
                SetPropertyValue(nameof(Kur), ref kur, value);
            }
        }

        public double Alis
        {
            get
            {
                return alis;
            }
            set
            {
                SetPropertyValue(nameof(Alis), ref alis, value);
            }
        }

        public double Satis
        {
            get
            {
                return satis;
            }
            set
            {
                SetPropertyValue(nameof(Satis), ref satis, value);
            }
        }

        public double EfektifAlis
        {
            get
            {
                return efektifAlis;
            }
            set
            {
                SetPropertyValue(nameof(EfektifAlis), ref efektifAlis, value);
            }
        }

        public double EfektifSatis
        {
            get
            {
                return efektifSatis;
            }
            set
            {
                SetPropertyValue(nameof(EfektifSatis), ref efektifSatis, value);
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

            public const string DovizFieldName = "Doviz";

            public DovizTurleri.FieldsClass Doviz
            {
                get
                {
                    return new DovizTurleri.FieldsClass(GetNestedName(DovizFieldName));
                }
            }

            public const string TarihFieldName = "Tarih";

            public OperandProperty Tarih
            {
                get
                {
                    return new OperandProperty(GetNestedName(TarihFieldName));
                }
            }

            public const string KurFieldName = "Kur";

            public OperandProperty Kur
            {
                get
                {
                    return new OperandProperty(GetNestedName(KurFieldName));
                }
            }

            public const string AlisFieldName = "Alis";

            public OperandProperty Alis
            {
                get
                {
                    return new OperandProperty(GetNestedName(AlisFieldName));
                }
            }

            public const string SatisFieldName = "Satis";

            public OperandProperty Satis
            {
                get
                {
                    return new OperandProperty(GetNestedName(SatisFieldName));
                }
            }

            public const string EfektifAlisFieldName = "EfektifAlis";

            public OperandProperty EfektifAlis
            {
                get
                {
                    return new OperandProperty(GetNestedName(EfektifAlisFieldName));
                }
            }

            public const string EfektifSatisFieldName = "EfektifSatis";

            public OperandProperty EfektifSatis
            {
                get
                {
                    return new OperandProperty(GetNestedName(EfektifSatisFieldName));
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