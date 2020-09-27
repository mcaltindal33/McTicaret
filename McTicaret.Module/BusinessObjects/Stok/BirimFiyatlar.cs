using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BirimFiyatlar : BaseObject
    {
        public BirimFiyatlar(Session session) : base(session) { }
        #region Fields Region...
        private double yeniFiyat;
        private double karOrani;
        private double birimFiyat;
        private BirimTurleri birim;
        private string aciklama;
        private DovizTurleri doviz;
        private DateTime tarih;
        private FiyatTipleri fiyatTipi;
        private Stoklar stok;
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
        [VisibleInListView(false)]
        public Stoklar Stok
        {
            get
            {
                return stok;
            }
            set
            {
                SetPropertyValue(nameof(Stok), ref stok, value);
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double BirimFiyat
        {
            get
            {
                return birimFiyat;
            }
            set
            {
                SetPropertyValue(nameof(BirimFiyat), ref birimFiyat, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double KarOrani
        {
            get
            {
                return karOrani;
            }
            set
            {
                SetPropertyValue(nameof(KarOrani), ref karOrani, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double YeniFiyat
        {
            get
            {
                return yeniFiyat;
            }
            set
            {
                SetPropertyValue(nameof(YeniFiyat), ref yeniFiyat, value);
            }
        }
    }
}