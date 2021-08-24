using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    public class ProjeArastirma : XPObject
    {
        public ProjeArastirma(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private Projeler proje;
        private string aciklama;
        private string kaynak;
        private string tanim;
        #endregion

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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kaynak
        {
            get
            {
                return kaynak;
            }
            set
            {
                SetPropertyValue(nameof(Kaynak), ref kaynak, value);
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

        [Association]
        public Projeler Proje
        {
            get
            {
                return proje;
            }
            set
            {
                SetPropertyValue(nameof(Proje), ref proje, value);
            }
        }
    }
}