using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Validation;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    [ListViewFilter("Tüm Liste", "")]
    [ListViewFilter("Etkinleşmiş Hesaplar", "[Durum] == True", true)]
    [ListViewFilter("Etkinleştirilmemiş Hesaplar", "[Durum] == False")]
    public class CariHesaplar : BaseObject
    {
        public CariHesaplar(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Durum = true;
        }
        #region Fields Region...
        private bool durum;
        private Personel genelSorumlu;
        private string aciklama;
        private DateTime kurulusTarihi;
        private Projeler proje;
        private CariHesapGruplari cariHesapGrubu;
        private double riskLimiti;
        private IndirimTipleri ındirimTipi;
        private FiyatTipleri fiyatTipi;
        private string webAdresi;
        private string ePosta;
        private string telefonNo;
        private string faxNo;
        private string telefon;
        private CariHesapTuru hesapTuru;
        private CariHesaplar anaSirket;
        private string kompleUnvan;
        private string tCKimlikNo;
        private VergiDaireleri vergiDaire;
        private Ulkeler ulke;
        private string vergiNo;
        private string kod;
        private string tanim;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize),RuleUniqueValue,RuleRequiredField]
        public string Tanim
        {
            get
            {
                return tanim;
            }
            set
            {
                SetPropertyValue(nameof(Tanim), ref tanim, value);
                if (KompleUnvan != null)
                {
                    KompleUnvan = Tanim;
                }
            }
        }

        //[NonCloneable, RuleUniqueValue, Indexed(Unique = true)]
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
        public string VergiNo
        {
            get
            {
                return vergiNo;
            }
            set
            {
                SetPropertyValue(nameof(VergiNo), ref vergiNo, value);
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

        public VergiDaireleri VergiDaire
        {
            get
            {
                return vergiDaire;
            }
            set
            {
                SetPropertyValue(nameof(VergiDaire), ref vergiDaire, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TCKimlikNo
        {
            get
            {
                return tCKimlikNo;
            }
            set
            {
                SetPropertyValue(nameof(TCKimlikNo), ref tCKimlikNo, value);
            }
        }

        [Size(250)]
        public string KompleUnvan
        {
            get
            {
                return kompleUnvan;
            }
            set
            {
                SetPropertyValue(nameof(KompleUnvan), ref kompleUnvan, value);
            }
        }

        public CariHesaplar AnaSirket
        {
            get
            {
                return anaSirket;
            }
            set
            {
                SetPropertyValue(nameof(AnaSirket), ref anaSirket, value);
            }
        }

        public CariHesapTuru HesapTuru
        {
            get
            {
                return hesapTuru;
            }
            set
            {
                SetPropertyValue(nameof(HesapTuru), ref hesapTuru, value);
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
        public string FaxNo
        {
            get
            {
                return faxNo;
            }
            set
            {
                SetPropertyValue(nameof(FaxNo), ref faxNo, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TelefonNo
        {
            get
            {
                return telefonNo;
            }
            set
            {
                SetPropertyValue(nameof(TelefonNo), ref telefonNo, value);
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
        public string WebAdresi
        {
            get
            {
                return webAdresi;
            }
            set
            {
                SetPropertyValue(nameof(WebAdresi), ref webAdresi, value);
            }
        }

        public FiyatTipleri FiyatTipi
        {
            get
            {
                return fiyatTipi;
            }
            set
            {
                SetPropertyValue(nameof(FiyatTipi), ref fiyatTipi, value);
            }
        }

        public IndirimTipleri IndirimTipi
        {
            get
            {
                return ındirimTipi;
            }
            set
            {
                SetPropertyValue(nameof(IndirimTipi), ref ındirimTipi, value);
            }
        }

        public double RiskLimiti
        {
            get
            {
                return riskLimiti;
            }
            set
            {
                SetPropertyValue(nameof(RiskLimiti), ref riskLimiti, value);
            }
        }
        [Association]
        public CariHesapGruplari CariHesapGrubu
        {
            get
            {
                return cariHesapGrubu;
            }
            set
            {
                SetPropertyValue(nameof(CariHesapGrubu), ref cariHesapGrubu, value);
            }
        }

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

        public DateTime KurulusTarihi
        {
            get
            {
                return kurulusTarihi;
            }
            set
            {
                SetPropertyValue(nameof(KurulusTarihi), ref kurulusTarihi, value);
            }
        }


        public bool Durum
        {
            get
            {
                return durum;
            }
            set
            {
                SetPropertyValue(nameof(Durum), ref durum, value);
            }
        }
        [VisibleInDetailView(false), VisibleInDashboards(false)]
        public double Alacak
        {
            get
            {
                double temp = Evraklarim.Where(x => x.Islem == IslemTurleri.Giren).Sum(x => x.Tutar);
                return temp;
            }
        }
        [VisibleInDetailView(false), VisibleInDashboards(false)]
        public double Borc
        {
            get
            {
                double temp = Evraklarim.Where(x => x.Islem == IslemTurleri.Cikan).Sum(x => x.Tutar);
                return temp;
            }
        }
        [VisibleInDetailView(false), VisibleInDashboards(false)]
        public double Bakiye
        {
            get
            {
                //double temp = Evraklarim.Where(x => x.Islem == IslemTurleri.Cikan).Sum(x => x.Tutar);
                return Borc - Alacak;
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

        public Personel GenelSorumlu
        {
            get
            {
                return genelSorumlu;
            }
            set
            {
                SetPropertyValue(nameof(GenelSorumlu), ref genelSorumlu, value);
            }
        }
        [Association]
        public XPCollection<CariHesapAdresler> Adresler => GetCollection<CariHesapAdresler>(nameof(Adresler));
        [Association]
        public XPCollection<CariHesapKontak> IlgiliKisi => GetCollection<CariHesapKontak>(nameof(IlgiliKisi));
        [Association]
        public XPCollection<CariHesapBankalar> CariBanka => GetCollection<CariHesapBankalar>(nameof(CariBanka));
        [Association]
        public XPCollection<Evraklar> Evraklarim => GetCollection<Evraklar>(nameof(Evraklarim));

        [Action(Caption = "Aktif Et", TargetObjectsCriteria = "Not[Durum]")]
        public void ActionMethods()
        {
            this.Durum = true;
        }

        [Action(Caption = "Pasif Et", TargetObjectsCriteria = "[Durum] = true")]
        public void ActionPassiveMethods()
        {
            this.Durum = false;
        }

        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && Session.IsNewObject(this)
                        && string.IsNullOrEmpty(Kod))
            {
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "CariHesapPrefix");
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("Tur",
                                                                                         EvrakTurleri.CariHesap));
                if (tanim != null)
                {
                    Kod = string.Format("{0}{1:D8}", tanim.Tanim, nextSequence);
                }
                else
                {
                    Kod = string.Format("{0:D8}", nextSequence);
                }
            }
            base.OnSaving();
        }
    }
}