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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class StokHareketleri : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public StokHareketleri(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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
            get
            {
                return stok;
            }
            set
            {
                SetPropertyValue(nameof(Stok), ref stok, value);
                Birim = Stok.Birim;
                BirimFiyat = Stok.ToptanSatisFiyati;
            }
        }
        
        [Association("StokIslemler-HareketDetay")]
        [ImmediatePostData]
        public StokIslemler Evrak
        {
            get
            {
                return evrak;
            }
            set
            {
                StokIslemler eskiIslem = evrak;
                bool modified = SetPropertyValue(nameof(Evrak), ref evrak, value);
                if (!IsLoading && !IsSaving && eskiIslem != evrak && modified)
                {
                    eskiIslem = eskiIslem ?? evrak;
                    eskiIslem.UpdateAltToplams(true);
                    eskiIslem.UpdateGenel(true);
                    eskiIslem.UpdateIndirim(true);
                    eskiIslem.UpdateKdv(true);
                    Depo = Evrak.Depo;
                    Hareket = Evrak.Hareket;
                    Doviz = Evrak.Doviz;

                }

            }
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
            set
            {
                if (SetPropertyValue(nameof(Miktar), ref miktar, value))
                    HesaplaBirimMiktar();
                
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
        [ImmediatePostData]
        public double BirimFiyat
        {
            get
            {
                return birimFiyat;
            }
            set
            {
                if (SetPropertyValue(nameof(BirimFiyat), ref birimFiyat, value))
                    HesaplaBirimMiktar();
                
            }
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
            set
            {
                bool modified = SetPropertyValue(nameof(IndirimsizTutar), ref indirimsizTutar, value);
                if (!IsLoading && !IsSaving && Evrak !=null && modified)
                {
                    HesaplaIndirim();
                    Evrak.UpdateAltToplams(true);
                }
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IndirimOran
        {
            get
            {
                return indirimOran;
            }
            set
            {
                if(SetPropertyValue(nameof(IndirimOran), ref indirimOran, value))
                    HesaplaIndirim();
            }
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
            set
            {
                bool modified = SetPropertyValue(nameof(IndirimTutar), ref indirimTutar, value);
                if (!IsLoading && !IsSaving && Evrak != null && modified)
                {
                    HesaplaNetTutar();
                    Evrak.UpdateIndirim(true);
                }
            }
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
            set
            {
                bool modified = SetPropertyValue(nameof(NetTutar), ref netTutar, value);
                if (!IsLoading && !IsSaving && Evrak != null && modified)
                {
                    HesaplaKdvTutar();
                    Evrak.UpdateAltToplams(true);
                    Evrak.UpdateIndirim(true);                    
                }
                
            }
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
            set
            {
                bool modified = SetPropertyValue(nameof(KDVOrani), ref kDVOrani, value);
                if (!IsLoading && !IsSaving && Evrak != null && modified)
                {
                    HesaplaKdvTutar();
                    Evrak.UpdateKdv(true);
                }
                
            }
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
            set
            {
                bool modified = SetPropertyValue(nameof(KDVTutar), ref kDVTutar, value);
                if (!IsLoading && !IsSaving && Evrak != null && modified)
                {
                    HesaplaToplam();
                    Evrak.UpdateKdv(true);
                }
            }
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
            set
            {
                bool modified = SetPropertyValue(nameof(Toplam), ref toplam, value);
                if (!IsLoading && !IsSaving && Evrak != null && modified)
                {
                    Evrak.UpdateGenel(true);
                }
                //bool modified = SetPropertyValue(nameof(Toplam), ref toplam, value);
                //if (!IsLoading && !IsSaving && Evrak != null && modified)
                //    Evrak.UpdateGenel(true);

            }
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

        void HesaplaBirimMiktar()
        {
            IndirimsizTutar = BirimFiyat * Miktar;
            NetTutar = IndirimsizTutar;
            Toplam = NetTutar;
        }
        void HesaplaIndirim()
        {
            IndirimTutar = (IndirimsizTutar / 100) * IndirimOran;
        }

        void HesaplaNetTutar()
        {
            NetTutar = IndirimsizTutar - IndirimTutar;
        }

        void HesaplaKdvTutar()
        {
            KDVTutar = (NetTutar / 100) * KDVOrani;
        }

        void HesaplaToplam()
        {
            Toplam = NetTutar + KDVTutar;
        }
    }
}