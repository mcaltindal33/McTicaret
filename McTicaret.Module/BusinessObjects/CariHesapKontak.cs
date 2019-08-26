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
    [DefaultProperty(nameof(AdSoyad))]
    public class CariHesapKontak : XPObject
    {
        public CariHesapKontak(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();

        #region Fields Region...
        private string dogumGunu;
        private string acikalama;
        private string ePosta;
        private string gSM;
        private string telefon;
        private CariHesaplar firma;
        private string soyad;
        private string adi;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adi
        {
            get
            {
                return adi;
            }
            set
            {
                SetPropertyValue(nameof(Adi), ref adi, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Soyad
        {
            get
            {
                return soyad;
            }
            set
            {
                SetPropertyValue(nameof(Soyad), ref soyad, value);
            }
        }

        [PersistentAlias("Concat([Adi],' ',[Soyad])")]
        public string AdSoyad => (string)EvaluateAlias(nameof(AdSoyad));

        [Association]
        public CariHesaplar Firma
        {
            get
            {
                return firma;
            }
            set
            {
                SetPropertyValue(nameof(Firma), ref firma, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                SetPropertyValue(nameof(Telefon), ref telefon, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GSM
        {
            get
            {
                return gSM;
            }
            set
            {
                SetPropertyValue(nameof(GSM), ref gSM, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EPosta
        {
            get
            {
                return ePosta;
            }
            set
            {
                SetPropertyValue(nameof(EPosta), ref ePosta, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Acikalama
        {
            get
            {
                return acikalama;
            }
            set
            {
                SetPropertyValue(nameof(Acikalama), ref acikalama, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DogumGunu
        {
            get
            {
                return dogumGunu;
            }
            set
            {
                SetPropertyValue(nameof(DogumGunu), ref dogumGunu, value);
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

            public const string AdiFieldName = "Adi";

            public OperandProperty Adi
            {
                get
                {
                    return new OperandProperty(GetNestedName(AdiFieldName));
                }
            }

            public const string SoyadFieldName = "Soyad";

            public OperandProperty Soyad
            {
                get
                {
                    return new OperandProperty(GetNestedName(SoyadFieldName));
                }
            }

            public const string AdSoyadFieldName = "AdSoyad";

            public OperandProperty AdSoyad
            {
                get
                {
                    return new OperandProperty(GetNestedName(AdSoyadFieldName));
                }
            }

            public const string FirmaFieldName = "Firma";

            public PersistentBase.FieldsClass Firma
            {
                get
                {
                    return new PersistentBase.FieldsClass(GetNestedName(FirmaFieldName));
                }
            }

            public const string TelefonFieldName = "Telefon";

            public OperandProperty Telefon
            {
                get
                {
                    return new OperandProperty(GetNestedName(TelefonFieldName));
                }
            }

            public const string GSMFieldName = "GSM";

            public OperandProperty GSM
            {
                get
                {
                    return new OperandProperty(GetNestedName(GSMFieldName));
                }
            }

            public const string EPostaFieldName = "EPosta";

            public OperandProperty EPosta
            {
                get
                {
                    return new OperandProperty(GetNestedName(EPostaFieldName));
                }
            }

            public const string AcikalamaFieldName = "Acikalama";

            public OperandProperty Acikalama
            {
                get
                {
                    return new OperandProperty(GetNestedName(AcikalamaFieldName));
                }
            }

            public const string DogumGunuFieldName = "DogumGunu";

            public OperandProperty DogumGunu
            {
                get
                {
                    return new OperandProperty(GetNestedName(DogumGunuFieldName));
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