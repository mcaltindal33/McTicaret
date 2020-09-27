using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class KasaBankaHareketler : Evraklar
    {
        public KasaBankaHareketler(Session session) : base(session) { }

        #region Fields Region...
        private Kasalar kasa;
        private BankaHesaplari banka;
        private BankaHareket bankaIslem;
        private KasaHareket kasaIslem;
        private BankaHareketTuru bankaHarekets;
        private KasaHareketTuru kasaHareket;
        #endregion
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareketTuru KasaHarekets
        {
            get
            {
                return kasaHareket;
            }
            set
            {
                SetPropertyValue(nameof(KasaHareket), ref kasaHareket, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public BankaHareketTuru BankaHarekets
        {
            get
            {
                return bankaHarekets;
            }
            set
            {
                SetPropertyValue(nameof(BankaHarekets), ref bankaHarekets, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareket KasaIslem
        {
            get
            {
                return kasaIslem;
            }
            set
            {
                SetPropertyValue(nameof(KasaIslem), ref kasaIslem, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public BankaHareket BankaIslem
        {
            get
            {
                return bankaIslem;
            }
            set
            {
                SetPropertyValue(nameof(BankaIslem), ref bankaIslem, value);
            }
        }

        public BankaHesaplari Banka
        {
            get
            {
                return banka;
            }
            set
            {
                SetPropertyValue(nameof(Banka), ref banka, value);
            }
        }
        
        public Kasalar Kasa
        {
            get
            {
                return kasa;
            }
            set
            {
                SetPropertyValue(nameof(Kasa), ref kasa, value);
            }
        }
        protected override void OnSaving()
        {
            if(BankaIslem != null)
            {
                BankaHareket BankaIslems = new BankaHareket(Session)
                {
                    Banka = Banka,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = BankaHarekets,
                    Islem = Islem,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar,
                    Aciklama = Aciklama
                };
                BankaIslems.Save();
                BankaIslem = BankaIslems;
            }
            else
            {
                BankaIslem.Tutar = Tutar;
                BankaIslem.Save();
            }
            if(KasaIslem != null)
            {
                KasaHareket KasaIslems = new KasaHareket(Session)
                {
                    Kasa = Kasa,
                    Aciklama = Aciklama,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Tutar = Tutar,
                    Hareket = KasaHarekets,
                    Islem = Islem,
                    Tarih = Tarih,
                    Turu = Turu
                };
                KasaIslems.Save();
                KasaIslem = KasaIslems;
            }
            else
            {
                KasaIslem.Tutar = Tutar;
                KasaIslem.Save();
            }
            base.OnSaving();
            
         
           
        }
        protected override void OnDeleting()
        {
            base.OnDeleting();
            KasaIslem.Delete();
            BankaIslem.Delete();
        }

    }
}