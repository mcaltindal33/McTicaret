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
    //[ImageName("BO_Contact")]
    [DefaultProperty(nameof(Tanim))]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Kasalar : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Kasalar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<Kasalar> collection = new XPCollection<Kasalar>(Session);
            if (collection.Count > 0)
            {
                switch (collection.Count.ToString().Length)
                {
                    case 1:
                        Kod = $"000000{collection.Count + 1}";
                        break;
                    case 2:
                        Kod = $"00000{collection.Count + 1}";
                        break;
                    case 3:
                        Kod = $"0000{collection.Count + 1}";
                        break;
                    case 4:
                        Kod = $"000{collection.Count + 1}";
                        break;
                    case 5:
                        Kod = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        Kod = $"0{collection.Count + 1}";
                        break;
                    default:
                        Kod = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                Kod = $"000000{collection.Count + 1}";
            }
        }
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