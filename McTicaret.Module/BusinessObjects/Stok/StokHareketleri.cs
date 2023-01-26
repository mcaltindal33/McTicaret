using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;
using System.Linq;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class StokHareketleri : BaseObject
    {
        public StokHareketleri(Session session) : base(session) { }

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
            set
            {
                Stoklar rStok = stok;
                bool modified = SetPropertyValue(nameof(Stok), ref stok, value); 
                if(!IsLoading && !IsSaving && rStok != stok && modified)
                {
                    rStok = rStok ?? stok;
                    BirimFiyat = rStok.PerakendeSatis;
                    Birim = rStok.Birim;
                    KDVOrani = rStok.SatisKDV.Oran;
                }
            }
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
            get => miktar;
            set => SetPropertyValue(nameof(Miktar), ref miktar, value);
        }

        public BirimTurleri Birim
        {
            get => birim;
            set=> SetPropertyValue(nameof(Birim), ref birim, value);
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
            get=> indirimsizTutar;
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
            get=> indirimTutar;
            set => SetPropertyValue(nameof(IndirimTutar), ref indirimTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double NetTutar
        {
            get=> netTutar;
            set => SetPropertyValue(nameof(NetTutar), ref netTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double KDVOrani
        {
            get=> kDVOrani;
            set => SetPropertyValue(nameof(KDVOrani), ref kDVOrani, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double KDVTutar
        {
            get=> kDVTutar;
            set => SetPropertyValue(nameof(KDVTutar), ref kDVTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double Toplam
        {
            get=> toplam;
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
            get=> depo;
            set=> SetPropertyValue(nameof(Depo), ref depo, value);
        }

        public DovizTurleri Doviz
        {
            get=> doviz;
            set=> SetPropertyValue(nameof(Doviz), ref doviz, value);
        }

    }
}