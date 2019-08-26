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
    public class Projeler : XPObject
    {
        public Projeler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<Projeler> collection = new XPCollection<Projeler>(Session);
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
        private string hedefNeden;
        private int projeEfektiflik;
        private string sorumluAciklama;
        private Personel sorumlu;
        private DateTime bitisTarihi;
        private DateTime baslangicTarihi;
        private double karTutari;
        private double masrafTutari;
        private bool aciliyet;
        private ProjeOncelik oncelik;
        private string aciklama;
        private Projeler ustProje;
        private CariHesaplar firma;
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

        public Projeler UstProje
        {
            get
            {
                return ustProje;
            }
            set
            {
                SetPropertyValue(nameof(UstProje), ref ustProje, value);
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

        public ProjeOncelik Oncelik
        {
            get
            {
                return oncelik;
            }
            set
            {
                SetPropertyValue(nameof(Oncelik), ref oncelik, value);
            }
        }
        [CaptionsForBoolValues("Var", "Yok")]
        public bool Aciliyet
        {
            get
            {
                return aciliyet;
            }
            set
            {
                SetPropertyValue(nameof(Aciliyet), ref aciliyet, value);
            }
        }

        public double MasrafTutari
        {
            get
            {
                return masrafTutari;
            }
            set
            {
                SetPropertyValue(nameof(MasrafTutari), ref masrafTutari, value);
            }
        }

        public double KarTutari
        {
            get
            {
                return karTutari;
            }
            set
            {
                SetPropertyValue(nameof(KarTutari), ref karTutari, value);
            }
        }

        public DateTime BaslangicTarihi
        {
            get
            {
                return baslangicTarihi;
            }
            set
            {
                SetPropertyValue(nameof(BaslangicTarihi), ref baslangicTarihi, value);
            }
        }

        public DateTime BitisTarihi
        {
            get
            {
                return bitisTarihi;
            }
            set
            {
                SetPropertyValue(nameof(BitisTarihi), ref bitisTarihi, value);
            }
        }

        public Personel Sorumlu
        {
            get
            {
                return sorumlu;
            }
            set
            {
                SetPropertyValue(nameof(Sorumlu), ref sorumlu, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SorumluAciklama
        {
            get
            {
                return sorumluAciklama;
            }
            set
            {
                SetPropertyValue(nameof(SorumluAciklama), ref sorumluAciklama, value);
            }
        }

        public int ProjeEfektiflik
        {
            get
            {
                return projeEfektiflik;
            }
            set
            {
                SetPropertyValue(nameof(ProjeEfektiflik), ref projeEfektiflik, value);
            }
        }
        [Association]
        public XPCollection<ProjeArastirma> Arastirma => GetCollection<ProjeArastirma>(nameof(Arastirma));
        [Association]
        public XPCollection<ProjeGorevler> Gorevler => GetCollection<ProjeGorevler>(nameof(Gorevler));

        [Size(250)]
        public string HedefNeden
        {
            get
            {
                return hedefNeden;
            }
            set
            {
                SetPropertyValue(nameof(HedefNeden), ref hedefNeden, value);
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

            public const string FirmaFieldName = "Firma";

            public CariHesaplar.FieldsClass Firma
            {
                get
                {
                    return new CariHesaplar.FieldsClass(GetNestedName(FirmaFieldName));
                }
            }

            public const string UstProjeFieldName = "UstProje";

            public FieldsClass UstProje
            {
                get
                {
                    return new FieldsClass(GetNestedName(UstProjeFieldName));
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

            public const string OncelikFieldName = "Oncelik";

            public OperandProperty Oncelik
            {
                get
                {
                    return new OperandProperty(GetNestedName(OncelikFieldName));
                }
            }

            public const string AciliyetFieldName = "Aciliyet";

            public OperandProperty Aciliyet
            {
                get
                {
                    return new OperandProperty(GetNestedName(AciliyetFieldName));
                }
            }

            public const string MasrafTutariFieldName = "MasrafTutari";

            public OperandProperty MasrafTutari
            {
                get
                {
                    return new OperandProperty(GetNestedName(MasrafTutariFieldName));
                }
            }

            public const string KarTutariFieldName = "KarTutari";

            public OperandProperty KarTutari
            {
                get
                {
                    return new OperandProperty(GetNestedName(KarTutariFieldName));
                }
            }

            public const string BaslangicTarihiFieldName = "BaslangicTarihi";

            public OperandProperty BaslangicTarihi
            {
                get
                {
                    return new OperandProperty(GetNestedName(BaslangicTarihiFieldName));
                }
            }

            public const string BitisTarihiFieldName = "BitisTarihi";

            public OperandProperty BitisTarihi
            {
                get
                {
                    return new OperandProperty(GetNestedName(BitisTarihiFieldName));
                }
            }

            public const string SorumluFieldName = "Sorumlu";

            public Personel.FieldsClass Sorumlu
            {
                get
                {
                    return new Personel.FieldsClass(GetNestedName(SorumluFieldName));
                }
            }

            public const string SorumluAciklamaFieldName = "SorumluAciklama";

            public OperandProperty SorumluAciklama
            {
                get
                {
                    return new OperandProperty(GetNestedName(SorumluAciklamaFieldName));
                }
            }

            public const string ProjeEfektiflikFieldName = "ProjeEfektiflik";

            public OperandProperty ProjeEfektiflik
            {
                get
                {
                    return new OperandProperty(GetNestedName(ProjeEfektiflikFieldName));
                }
            }

            public const string ArastirmaFieldName = "Arastirma";

            public OperandProperty Arastirma
            {
                get
                {
                    return new OperandProperty(GetNestedName(ArastirmaFieldName));
                }
            }

            public const string GorevlerFieldName = "Gorevler";

            public OperandProperty Gorevler
            {
                get
                {
                    return new OperandProperty(GetNestedName(GorevlerFieldName));
                }
            }

            public const string HedefNedenFieldName = "HedefNeden";

            public OperandProperty HedefNeden
            {
                get
                {
                    return new OperandProperty(GetNestedName(HedefNedenFieldName));
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