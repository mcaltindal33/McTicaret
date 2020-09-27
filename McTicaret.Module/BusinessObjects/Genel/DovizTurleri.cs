using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Kod))]
    public class DovizTurleri : XPObject
    {
        public DovizTurleri(Session session) : base(session) { }
        #region Fields Region...
        private string sembol;
        private string aciklama;
        private string ayrintiliTanim;
        private string tanim;
        private string kod;
        #endregion

        [Size(3)]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AyrintiliTanim
        {
            get
            {
                return ayrintiliTanim;
            }
            set
            {
                SetPropertyValue(nameof(AyrintiliTanim), ref ayrintiliTanim, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Sembol
        {
            get
            {
                return sembol;
            }
            set
            {
                SetPropertyValue(nameof(Sembol), ref sembol, value);
            }
        }

        [Association]
        public XPCollection<DovizKurlari> Kurlar
        {
            get
            {
                return GetCollection<DovizKurlari>(nameof(Kurlar));
            }
        }
    }
}