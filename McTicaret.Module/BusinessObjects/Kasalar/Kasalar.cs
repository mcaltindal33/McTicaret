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
    [DefaultProperty(nameof(Tanim))]
    public class Kasalar : BaseObject
    { 
        public Kasalar(Session session) : base(session) { }
        #region Fields Region...
        private string aciklama;
        private string tanim;
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [Association]
        public XPCollection<KasaHareket> Hareketler
        {
            get
            {
                return GetCollection<KasaHareket>(nameof(Hareketler));
            }
        }
        [VisibleInDetailView(false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double Giren
        {
            get
            {
                double temp = 0;
                if (Hareketler.Where(x => x.Hareket == KasaHareketTuru.KasaGirisi).Sum(x => x.Tutar) > 0)
                {
                    temp = Hareketler.Where(x => x.Hareket == KasaHareketTuru.KasaGirisi).Sum(x => x.Tutar);
                }
                return temp;
            }
        }
        [VisibleInDetailView(false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double Cikan
        {
            get
            {
                double temp = 0;
                if (Hareketler.Where(x => x.Hareket == KasaHareketTuru.KasaCikisi).Sum(x => x.Tutar) > 0)
                {
                    temp = Hareketler.Where(x => x.Hareket == KasaHareketTuru.KasaCikisi).Sum(x => x.Tutar);
                }
                return temp;
            }
        }
        [VisibleInDetailView(false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double Bakiye
        {
            get
            {
                double temp = 0;
                temp = Giren - Cikan;
                return temp;
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
    }
}