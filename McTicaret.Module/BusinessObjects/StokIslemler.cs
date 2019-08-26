using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class StokIslemler : Evraklar
    {
        public StokIslemler(Session session)
            : base(session)
        {
        }
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
        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 01.04.2019 20:51
        public new class FieldsClass : Evraklar.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string HareketDetayFieldName = "HareketDetay";

            public OperandProperty HareketDetay
            {
                get
                {
                    return new OperandProperty(GetNestedName(HareketDetayFieldName));
                }
            }

            public const string AltToplamFieldName = "AltToplam";

            public OperandProperty AltToplam
            {
                get
                {
                    return new OperandProperty(GetNestedName(AltToplamFieldName));
                }
            }

            public const string KdvToplamFieldName = "KdvToplam";

            public OperandProperty KdvToplam
            {
                get
                {
                    return new OperandProperty(GetNestedName(KdvToplamFieldName));
                }
            }

            public const string IndirimToplamFieldName = "IndirimToplam";

            public OperandProperty IndirimToplam
            {
                get
                {
                    return new OperandProperty(GetNestedName(IndirimToplamFieldName));
                }
            }

            public const string HareketFieldName = "Hareket";

            public OperandProperty Hareket
            {
                get
                {
                    return new OperandProperty(GetNestedName(HareketFieldName));
                }
            }

            public const string DepoFieldName = "Depo";

            public Depolar.FieldsClass Depo
            {
                get
                {
                    return new Depolar.FieldsClass(GetNestedName(DepoFieldName));
                }
            }

            public const string GenelToplamFieldName = "GenelToplam";

            public OperandProperty GenelToplam
            {
                get
                {
                    return new OperandProperty(GetNestedName(GenelToplamFieldName));
                }
            }
        }

        public new static FieldsClass Fields
        {
            get
            {
                if (ReferenceEquals(_Fields, null))
                {
                    _Fields = (new FieldsClass());
                }

                return _Fields;
            }
        }

        private static FieldsClass _Fields;
    }
}