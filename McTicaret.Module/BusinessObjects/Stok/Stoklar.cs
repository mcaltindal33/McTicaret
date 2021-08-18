using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Tanim")]
    public class Stoklar : BaseObject
    {
        public Stoklar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        #region Fields Region...
        private double toptanSatisFiyati;
        private double perakendeSatis;
        private double maliyetFiyati;
        private double alisFiyati;
        private MediaDataObject resim;
        private string aciklama;
        private string garantiSuresi;
        private double maksimumStokMiktari;
        private double minimumStokMiktari;
        private CariHesaplar tedarikci;
        private VergiTurleri satisKDV;
        private VergiTurleri alisKDV;
        private string barcode;
        private MalzemeTipi urunTipi;
        private int rafOmru;
        private StokTuru turu;
        private Markalar marka;
        private string urunAdi;
        private string ureticiKodu;
        private StoklarGrubu grup;
        private BirimTurleri birim;
        private string tanim;
        private string kod;
        #endregion

        #region Property
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

        [Size(250)]
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

        public BirimTurleri Birim
        {
            get
            {
                return birim;
            }
            set
            {
                SetPropertyValue(nameof(Birim), ref birim, value);
            }
        }

        public StoklarGrubu Grup
        {
            get
            {
                return grup;
            }
            set
            {
                SetPropertyValue(nameof(Grup), ref grup, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string UreticiKodu
        {
            get
            {
                return ureticiKodu;
            }
            set
            {
                SetPropertyValue(nameof(UreticiKodu), ref ureticiKodu, value);
            }
        }

        [Size(350)]
        public string UrunAdi
        {
            get
            {
                return urunAdi;
            }
            set
            {
                SetPropertyValue(nameof(UrunAdi), ref urunAdi, value);
            }
        }

        public Markalar Marka
        {
            get
            {
                return marka;
            }
            set
            {
                SetPropertyValue(nameof(Marka), ref marka, value);
            }
        }

        public StokTuru Turu
        {
            get
            {
                return turu;
            }
            set
            {
                SetPropertyValue(nameof(Turu), ref turu, value);
            }
        }

        public int RafOmru
        {
            get
            {
                return rafOmru;
            }
            set
            {
                SetPropertyValue(nameof(RafOmru), ref rafOmru, value);
            }
        }

        public MalzemeTipi UrunTipi
        {
            get
            {
                return urunTipi;
            }
            set
            {
                SetPropertyValue(nameof(UrunTipi), ref urunTipi, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                SetPropertyValue(nameof(Barcode), ref barcode, value);
            }
        }

        public VergiTurleri AlisKDV
        {
            get
            {
                return alisKDV;
            }
            set
            {
                SetPropertyValue(nameof(AlisKDV), ref alisKDV, value);
            }
        }

        public VergiTurleri SatisKDV
        {
            get
            {
                return satisKDV;
            }
            set
            {
                SetPropertyValue(nameof(SatisKDV), ref satisKDV, value);
            }
        }

        public CariHesaplar Tedarikci
        {
            get
            {
                return tedarikci;
            }
            set
            {
                SetPropertyValue(nameof(Tedarikci), ref tedarikci, value);
            }
        }

        [ModelDefault("DisplayFormat","N2")]
        [ModelDefault("EditMask","N2")]
        public double MinimumStokMiktari
        {
            get
            {
                return minimumStokMiktari;
            }
            set
            {
                SetPropertyValue(nameof(MinimumStokMiktari), ref minimumStokMiktari, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double MaksimumStokMiktari
        {
            get
            {
                return maksimumStokMiktari;
            }
            set
            {
                SetPropertyValue(nameof(MaksimumStokMiktari), ref maksimumStokMiktari, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GarantiSuresi
        {
            get
            {
                return garantiSuresi;
            }
            set
            {
                SetPropertyValue(nameof(GarantiSuresi), ref garantiSuresi, value);
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

        public MediaDataObject Resim
        {
            get
            {
                return resim;
            }
            set
            {
                SetPropertyValue(nameof(Resim), ref resim, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double AlisFiyati
        {
            get
            {
                return alisFiyati;
            }
            set
            {
                SetPropertyValue(nameof(AlisFiyati), ref alisFiyati, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double MaliyetFiyati
        {
            get
            {
                return maliyetFiyati;
            }
            set
            {
                SetPropertyValue(nameof(MaliyetFiyati), ref maliyetFiyati, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double PerakendeSatis
        {
            get
            {
                return perakendeSatis;
            }
            set
            {
                SetPropertyValue(nameof(PerakendeSatis), ref perakendeSatis, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double ToptanSatisFiyati
        {
            get
            {
                return toptanSatisFiyati;
            }
            set
            {
                SetPropertyValue(nameof(ToptanSatisFiyati), ref toptanSatisFiyati, value);
            }
        }
        [Association]
        public XPCollection<StoklarEkBirimleri> EkBirimler => GetCollection<StoklarEkBirimleri>(nameof(EkBirimler));

        [Association]
        public XPCollection<StokHareketleri> Hareket => GetCollection<StokHareketleri>(nameof(Hareket));

        [VisibleInDetailView(false)]
        public double Giren
        {
            get
            {
                double temp = 0;
                if (Hareket.Where(x => x.Hareket == StokHareketTuru.StokGirisi).Sum(x => x.Miktar) > 0)
                    temp = Hareket.Where(x => x.Hareket == StokHareketTuru.StokGirisi).Sum(x => x.Miktar);
                return temp;
            }
        }
        [VisibleInDetailView(false)]
        public double Cikan
        {
            get
            {
                double temp = 0;
                if (Hareket.Where(x => x.Hareket == StokHareketTuru.StokCikisi).Sum(x => x.Miktar) > 0)
                    temp = Hareket.Where(x => x.Hareket == StokHareketTuru.StokCikisi).Sum(x => x.Miktar);
                return temp;
            }
        }
        [VisibleInDetailView(false)]
        public double Kalan { get { return Giren - Cikan; } }
        #endregion

        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && Session.IsNewObject(this)
                        && string.IsNullOrEmpty(Kod))
            {
                if(Grup != null)
                {
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"StokKodu{Grup.Kod}");
                    Kod = string.Format("{0}-{1:D5}", Grup.Kod, dist);
                }
                else
                {
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"StokKodu");
                    Kod = string.Format("{0:D5}", dist);
                }
            }
            base.OnSaving();
        }
    }
}