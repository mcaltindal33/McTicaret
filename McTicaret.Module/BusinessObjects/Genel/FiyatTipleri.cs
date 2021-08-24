using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    public class FiyatTipleri : XPObject
    {
        public FiyatTipleri(Session session) : base(session) { }
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
        private bool varsayilan;
        private double fiyatZami;
        private FiyatTipleri tabanTuru;
        private FiyatTuru fiyatOlusturmaTuru;
        private DovizTurleri fiyatDoviz;
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

        public DovizTurleri FiyatDoviz
        {
            get
            {
                return fiyatDoviz;
            }
            set
            {
                SetPropertyValue(nameof(FiyatDoviz), ref fiyatDoviz, value);
            }
        }

        public FiyatTuru FiyatOlusturmaTuru
        {
            get
            {
                return fiyatOlusturmaTuru;
            }
            set
            {
                SetPropertyValue(nameof(FiyatOlusturmaTuru), ref fiyatOlusturmaTuru, value);
            }
        }

        public FiyatTipleri TabanTuru
        {
            get
            {
                return tabanTuru;
            }
            set
            {
                SetPropertyValue(nameof(TabanTuru), ref tabanTuru, value);
            }
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        public double FiyatZami
        {
            get
            {
                return fiyatZami;
            }
            set
            {
                SetPropertyValue(nameof(FiyatZami), ref fiyatZami, value);
            }
        }

        public bool Varsayilan
        {
            get
            {
                return varsayilan;
            }
            set
            {
                SetPropertyValue(nameof(Varsayilan), ref varsayilan, value);
            }
        }

    }
}