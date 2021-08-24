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
        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("TabloTipi", this.GetType()));
                if (tanim != null)
                {
                    string Kodu = tanim.Kodu + tanim.Ayrac;
                    if (tanim.Yil)
                        Kodu += DateTime.Now.Year + tanim.Ayrac;
                    if (tanim.Ay)
                        Kodu += DateTime.Now.Month + tanim.Ayrac;
                    if (tanim.Gun)
                        Kodu += DateTime.Now.Day + tanim.Ayrac;
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"{Kodu}Prefix");
                    Kodu = $"{Kodu}{dist:D5}";
                    Kod = Kodu;
                }
                else
                {
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"{GetType().Name}Prefix");
                    Kod = $"{dist:D5}";
                }
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

    }
}