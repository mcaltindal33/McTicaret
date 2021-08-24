using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    public class Caddeler : XPObject
    {
        public Caddeler(Session session) : base(session) { }
        
        #region Fields Region...
        private Mahalle mahalle;
        private string tanim;
        private string kodu;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kodu
        {
            get
            {
                return kodu;
            }
            set
            {
                SetPropertyValue(nameof(Kodu), ref kodu, value);
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
        public Mahalle Mahalle
        {
            get
            {
                return mahalle;
            }
            set
            {
                SetPropertyValue(nameof(Mahalle), ref mahalle, value);
            }
        }

    }
}