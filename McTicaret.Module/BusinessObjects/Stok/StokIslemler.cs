using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    public class StokIslemler : Evraklar
    {
        public StokIslemler(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Association("StokIslemler-HareketDetay"), Aggregated]
        public XPCollection<StokHareketleri> HareketDetay
        {
            get
            {
                return GetCollection<StokHareketleri>(nameof(HareketDetay));
            }
        }

        #region Fields Region...
        private double genelToplam;
        private StokHareketTuru hareket;
        private double ındirimToplam;
        private double kdvToplam;
        private double altToplam;
        private Depolar depo;
        #endregion

        [ModelDefault("DisplayFormat","N2")]
        [ModelDefault("EditMask", "N2")]
        public double AltToplam
        {
            get
            {
                return altToplam;
            }
            set
            {
                SetPropertyValue(nameof(AltToplam), ref altToplam, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double KdvToplam
        {
            get
            {
                return kdvToplam;
            }
            set
            {
                SetPropertyValue(nameof(KdvToplam), ref kdvToplam, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double IndirimToplam
        {
            get
            {
                return ındirimToplam;
            }
            set
            {
                SetPropertyValue(nameof(IndirimToplam), ref ındirimToplam, value);
            }
        }


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

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double GenelToplam
        {
            get
            {
                return genelToplam;
            }
            set
            {
                SetPropertyValue(nameof(GenelToplam), ref genelToplam, value);
            }
        }
        protected override void OnSaving()
        {
            Tutar = GenelToplam;
            base.OnSaving();
            
        }
        protected override void OnSaved()
        {
            if(Tutar != GenelToplam)
                Tutar = GenelToplam;
            base.OnSaved();
        }
    }
}