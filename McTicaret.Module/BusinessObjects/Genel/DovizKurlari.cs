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
    public class DovizKurlari : XPObject
    {
        public DovizKurlari(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private double efektifSatis;
        private double efektifAlis;
        private double satis;
        private double alis;
        private double kur;
        private DateTime tarih;
        private DovizTurleri doviz;
        #endregion
        [Association]
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

        [ModelDefault("DisplayFormat", "N5")]
        [ModelDefault("EditMask", "N5")]
        public double Kur
        {
            get
            {
                return kur;
            }
            set
            {
                SetPropertyValue(nameof(Kur), ref kur, value);
            }
        }

        [ModelDefault("DisplayFormat", "N5")]
        [ModelDefault("EditMask", "N5")]
        public double Alis
        {
            get
            {
                return alis;
            }
            set
            {
                SetPropertyValue(nameof(Alis), ref alis, value);
            }
        }

        [ModelDefault("DisplayFormat", "N5")]
        [ModelDefault("EditMask", "N5")]
        public double Satis
        {
            get
            {
                return satis;
            }
            set
            {
                SetPropertyValue(nameof(Satis), ref satis, value);
            }
        }

        [ModelDefault("DisplayFormat", "N5")]
        [ModelDefault("EditMask", "N5")]
        public double EfektifAlis
        {
            get
            {
                return efektifAlis;
            }
            set
            {
                SetPropertyValue(nameof(EfektifAlis), ref efektifAlis, value);
            }
        }

        [ModelDefault("DisplayFormat", "N5")]
        [ModelDefault("EditMask", "N5")]
        public double EfektifSatis
        {
            get
            {
                return efektifSatis;
            }
            set
            {
                SetPropertyValue(nameof(EfektifSatis), ref efektifSatis, value);
            }
        }

    }
}