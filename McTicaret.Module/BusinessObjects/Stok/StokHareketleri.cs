using System;
using System.Linq;

using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    public class StokHareketleri : BaseObject
    {
        public StokHareketleri(Session session) : base(session) { }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if(propertyName == nameof(Stok))
            {
                if (!IsDeleted)
                {
                    Birim = Stok.Birim;
                    KDVOrani = Stok.SatisKDV.Oran;
                    BirimFiyat = Stok.PerakendeSatis;
                }
            }
            if(propertyName == nameof(Evrak))
            {
                if(!IsDeleted)
                {
                    Depo = Evrak.Depo;
                    Doviz = Evrak.Doviz;
                    Hareket = Evrak.Hareket;
                }
            }

            if (propertyName == nameof(Miktar) || propertyName == nameof(BirimFiyat) || propertyName == nameof(IndirimsizTutar) || propertyName == nameof(IndirimOran) || propertyName == nameof(IndirimTutar) || propertyName == nameof(NetTutar) || propertyName == nameof(KDVOrani) || propertyName == nameof(KDVTutar))
            {
                if(!IsDeleted)
                {
                    IndirimsizTutar = BirimFiyat * Miktar;
                    NetTutar = IndirimsizTutar;
                    // Toplam = NetTutar;
                    IndirimTutar = (IndirimsizTutar / 100) * IndirimOran;
                    NetTutar = IndirimsizTutar - IndirimTutar;
                    KDVTutar = (NetTutar / 100) * KDVOrani;
                    Toplam = NetTutar + KDVTutar;
                }
            }

        }

        #region Fields Region...
        private DovizTurleri doviz;
        private Depolar depo;
        private StokIslemler evrak;
        private StokHareketTuru hareket;
        private double toplam;
        private double kDVTutar;
        private double kDVOrani;
        private double netTutar;
        private double indirimTutar;
        private double indirimOran;
        private double indirimsizTutar;
        private double birimFiyat;
        private BirimTurleri birim;
        private double miktar;
        private Stoklar stok;
        #endregion

        [Association]
        [ImmediatePostData]
        public Stoklar Stok
        {
            get => stok;
            set => SetPropertyValue(nameof(Stok), ref stok, value);
        }

        [Association("StokIslemler-HareketDetay")]
        [ImmediatePostData]
        public StokIslemler Evrak
        {
            get => evrak;
            set => SetPropertyValue(nameof(Evrak), ref evrak, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double Miktar
        {
            get
            {
                return miktar;
            }
            set => SetPropertyValue(nameof(Miktar), ref miktar, value);
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
        [ImmediatePostData]
        public double BirimFiyat
        {
            get => birimFiyat;
            set => SetPropertyValue(nameof(BirimFiyat), ref birimFiyat, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IndirimsizTutar
        {
            get
            {

                return indirimsizTutar;
            }
            set => SetPropertyValue(nameof(IndirimsizTutar), ref indirimsizTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IndirimOran
        {
            get => indirimOran;
            set => SetPropertyValue(nameof(IndirimOran), ref indirimOran, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IndirimTutar
        {
            get
            {
                return indirimTutar;
            }
            set => SetPropertyValue(nameof(IndirimTutar), ref indirimTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double NetTutar
        {
            get
            {
                return netTutar;
            }
            set => SetPropertyValue(nameof(NetTutar), ref netTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double KDVOrani
        {
            get
            {
                return kDVOrani;
            }
            set => SetPropertyValue(nameof(KDVOrani), ref kDVOrani, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double KDVTutar
        {
            get
            {
                return kDVTutar;
            }
            set => SetPropertyValue(nameof(KDVTutar), ref kDVTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double Toplam
        {
            get
            {
                return toplam;
            }
            set => SetPropertyValue(nameof(Toplam), ref toplam, value);
        }
        [VisibleInDetailView(false)]
        public StokHareketTuru Hareket
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

        public Depolar Depo
        {
            get
            {
                return depo;
            }
            set
            {
                SetPropertyValue(nameof(Depo), ref depo, value);

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

    }
}