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
    public class BankaSubeleri : XPObject
    {
        public BankaSubeleri(Session session) : base(session) { }
        #region Fields Region...
        private Bankalar banka;
        private string subeNo;
        private string sHIFTCode;
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SHIFTCode
        {
            get
            {
                return sHIFTCode;
            }
            set
            {
                SetPropertyValue(nameof(SHIFTCode), ref sHIFTCode, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SubeNo
        {
            get
            {
                return subeNo;
            }
            set
            {
                SetPropertyValue(nameof(SubeNo), ref subeNo, value);
            }
        }
        [Association]
        public Bankalar Banka
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
    }
}