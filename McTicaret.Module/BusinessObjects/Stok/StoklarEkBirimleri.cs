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
    [DefaultProperty(nameof(EkBirim))]
    public class StoklarEkBirimleri : XPObject
    {
        public StoklarEkBirimleri(Session session) : base(session) { }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("TabloTipi", this.GetType()));
                if (tanim != null)
                {
                    string Kodu = tanim.Kodu + tanim.Ayrac;
                    if (tanim.Yil)
                        Kodu += DateTime.Now.Year + tanim.Ayrac;
                    if (tanim.Ay)
                        Kodu += DateTime.Now.Month + tanim.Ayrac;
                    if (tanim.Gun)
                        Kodu += DateTime.Now.Day + tanim.Ayrac;
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"{Kodu}Prefix");
                    Kodu = $"{Kodu}{dist:D5}";
                    Kod = Kodu;
                }
                else
                {
                    int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"{GetType().Name}Prefix");
                    Kod = $"{dist:D5}";
                }
            }
        }
        #region Fields Region...
        private double hacimM3;
        private double agirlik;
        private double katSayi;
        private BirimTurleri ekBirim;
        private Stoklar stok;
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
        [Association]
        [VisibleInListView(false)]
        public Stoklar Stok
        {
            get
            {
                return stok;
            }
            set
            {
                SetPropertyValue(nameof(Stok), ref stok, value);
            }
        }

        public BirimTurleri AnaBirim => Stok.Birim;

        public BirimTurleri EkBirim
        {
            get
            {
                return ekBirim;
            }
            set
            {
                SetPropertyValue(nameof(EkBirim), ref ekBirim, value);
            }
        }

        public double KatSayi
        {
            get
            {
                return katSayi;
            }
            set
            {
                SetPropertyValue(nameof(KatSayi), ref katSayi, value);
            }
        }

        public double Agirlik
        {
            get
            {
                return agirlik;
            }
            set
            {
                SetPropertyValue(nameof(Agirlik), ref agirlik, value);
            }
        }

        public double HacimM3
        {
            get
            {
                return hacimM3;
            }
            set
            {
                SetPropertyValue(nameof(HacimM3), ref hacimM3, value);
            }
        }

    }
}