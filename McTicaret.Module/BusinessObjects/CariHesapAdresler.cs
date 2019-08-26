using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Adres))]
    public class CariHesapAdresler : XPObject
    {

        #region Fields Region...
        private bool varsayilanSevk;
        private bool varsayilan;
        private AdresTurleri adresTur;
        private string bina;
        private int binaNo;
        private Caddeler cadde;
        private CariHesaplar cariHesap;
        private int daireNo;
        private string fax;
        private string gSM;
        private Ilceler ılce;
        private Mahalle mahalle;
        private int postaKodu;
        private Sehirler sehir;
        private string telefon;
        private Ulkeler ulke;
        #endregion

        public CariHesapAdresler(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction() => base.AfterConstruction();

        #region Properties Region..
        [PersistentAlias("Concat([Mahalle],' Mah. ',[Cadde],' ',[Bina],' No:',[BinaNo],'/',[DaireNo],' ',[Ilce],'/',[Sehir])")]
        public string Adres => (string)EvaluateAlias(nameof(Adres));
        public AdresTurleri AdresTur
        {
            get
            {
                return adresTur;
            }
            set
            {
                SetPropertyValue(nameof(AdresTur), ref adresTur, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Bina
        {
            get
            {
                return bina;
            }
            set
            {
                SetPropertyValue(nameof(Bina), ref bina, value);
            }
        }
        public int BinaNo
        {
            get
            {
                return binaNo;
            }
            set
            {
                SetPropertyValue(nameof(BinaNo), ref binaNo, value);
            }
        }
        public Caddeler Cadde
        {
            get
            {
                return cadde;
            }
            set
            {
                SetPropertyValue(nameof(Cadde), ref cadde, value);
            }
        }
        [Association]
        public CariHesaplar CariHesap
        {
            get
            {
                return cariHesap;
            }
            set
            {
                SetPropertyValue(nameof(CariHesap), ref cariHesap, value);
            }
        }
        public int DaireNo
        {
            get
            {
                return daireNo;
            }
            set
            {
                SetPropertyValue(nameof(DaireNo), ref daireNo, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                SetPropertyValue(nameof(Fax), ref fax, value);
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
        public Ilceler Ilce
        {
            get
            {
                return ılce;
            }
            set
            {
                SetPropertyValue(nameof(Ilce), ref ılce, value);
            }
        }
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
        public int PostaKodu
        {
            get
            {
                return postaKodu;
            }
            set
            {
                SetPropertyValue(nameof(PostaKodu), ref postaKodu, value);
            }
        }
        public Sehirler Sehir
        {
            get
            {
                return sehir;
            }
            set
            {
                SetPropertyValue(nameof(Sehir), ref sehir, value);
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
        public Ulkeler Ulke
        {
            get
            {
                return ulke;
            }
            set
            {
                SetPropertyValue(nameof(Ulke), ref ulke, value);
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
        public bool VarsayilanSevk
        {
            get
            {
                return varsayilanSevk;
            }
            set
            {
                SetPropertyValue(nameof(VarsayilanSevk), ref varsayilanSevk, value);
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

            public const string AdresFieldName = "Adres";

            public OperandProperty Adres
            {
                get
                {
                    return new OperandProperty(GetNestedName(AdresFieldName));
                }
            }

            public const string AdresTurFieldName = "AdresTur";

            public AdresTurleri.FieldsClass AdresTur
            {
                get
                {
                    return new AdresTurleri.FieldsClass(GetNestedName(AdresTurFieldName));
                }
            }

            public const string BinaFieldName = "Bina";

            public OperandProperty Bina
            {
                get
                {
                    return new OperandProperty(GetNestedName(BinaFieldName));
                }
            }

            public const string BinaNoFieldName = "BinaNo";

            public OperandProperty BinaNo
            {
                get
                {
                    return new OperandProperty(GetNestedName(BinaNoFieldName));
                }
            }

            public const string CaddeFieldName = "Cadde";

            public Caddeler.FieldsClass Cadde
            {
                get
                {
                    return new Caddeler.FieldsClass(GetNestedName(CaddeFieldName));
                }
            }

            public const string CariHesapFieldName = "CariHesap";

            public CariHesaplar.FieldsClass CariHesap
            {
                get
                {
                    return new CariHesaplar.FieldsClass(GetNestedName(CariHesapFieldName));
                }
            }

            public const string DaireNoFieldName = "DaireNo";

            public OperandProperty DaireNo
            {
                get
                {
                    return new OperandProperty(GetNestedName(DaireNoFieldName));
                }
            }

            public const string FaxFieldName = "Fax";

            public OperandProperty Fax
            {
                get
                {
                    return new OperandProperty(GetNestedName(FaxFieldName));
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

            public const string IlceFieldName = "Ilce";

            public Ilceler.FieldsClass Ilce
            {
                get
                {
                    return new Ilceler.FieldsClass(GetNestedName(IlceFieldName));
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

            public const string PostaKoduFieldName = "PostaKodu";

            public OperandProperty PostaKodu
            {
                get
                {
                    return new OperandProperty(GetNestedName(PostaKoduFieldName));
                }
            }

            public const string SehirFieldName = "Sehir";

            public Sehirler.FieldsClass Sehir
            {
                get
                {
                    return new Sehirler.FieldsClass(GetNestedName(SehirFieldName));
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

            public const string UlkeFieldName = "Ulke";

            public Ulkeler.FieldsClass Ulke
            {
                get
                {
                    return new Ulkeler.FieldsClass(GetNestedName(UlkeFieldName));
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

            public const string VarsayilanSevkFieldName = "VarsayilanSevk";

            public OperandProperty VarsayilanSevk
            {
                get
                {
                    return new OperandProperty(GetNestedName(VarsayilanSevkFieldName));
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
        #endregion

    }
}