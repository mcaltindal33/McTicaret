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
                if(!IsLoading && !IsSaving && altToplam == 0)
                    UpdateAltToplams(false);
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
                if (!IsLoading && !IsSaving)
                    UpdateKdv(false);
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
                if (!IsLoading && !IsSaving)
                    UpdateIndirim(false);
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
                if (!IsLoading && !IsSaving)
                    UpdateGenel(false);

                return genelToplam;
            }
            set
            {
                SetPropertyValue(nameof(GenelToplam), ref genelToplam, value);
            }
        }
        public void UpdateAltToplams(bool forceChangeEvents)
        {
            double? oldToplam = altToplam;
            double temp = 0;
            foreach (StokHareketleri item in HareketDetay)
            {
                temp += item.IndirimsizTutar;
            }
            altToplam = temp;
            if(forceChangeEvents)
                OnChanged(nameof(AltToplam), oldToplam, altToplam);
        }
        public void UpdateKdv(bool forceChangeEvents)
        {
            double? oldKdv = kdvToplam;
            double temp = 0;
            foreach (StokHareketleri item in HareketDetay)
            {
                temp += item.KDVTutar;
            }
            kdvToplam = temp;
            if (forceChangeEvents)
                OnChanged(nameof(IndirimToplam), oldKdv, kdvToplam);
        }
        public void UpdateIndirim(bool forceChangeEvents)
        {
            double? oldIndirim = ındirimToplam;
            double temp = 0;
            foreach (StokHareketleri item in HareketDetay)
            {
                temp += item.IndirimTutar;
            }
            ındirimToplam = temp;
            if (forceChangeEvents)
                OnChanged(nameof(IndirimToplam), oldIndirim, ındirimToplam);
        }
        public void UpdateGenel(bool forceChangeEvents)
        {
            double? oldIndirim = genelToplam;
            double temp = 0;
            foreach (StokHareketleri item in HareketDetay)
            {
                temp += item.Toplam;
            }
            genelToplam = temp;
            if (forceChangeEvents)
                OnChanged(nameof(GenelToplam), oldIndirim, genelToplam);
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