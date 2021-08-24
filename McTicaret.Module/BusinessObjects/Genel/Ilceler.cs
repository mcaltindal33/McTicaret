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
    public class Ilceler : XPObject
    {
        public Ilceler(Session session) : base(session) { }
        #region Fields Region...
        private Sehirler sehir;
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
        public Sehirler Sehir
        {
            get
            {
                return sehir;
            }
            set
            {
                SetPropertyValue(nameof(Sehir), ref sehir, value);
            }
        }
        [Association]
        public XPCollection<Mahalle> Mahallelerim => GetCollection<Mahalle>(nameof(Mahallelerim));

    }
}