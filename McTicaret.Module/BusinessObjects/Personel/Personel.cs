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
    [DefaultProperty(nameof(AdSoyad))]
    public class Personel : XPObject
    {
        public Personel(Session session)
            : base(session)
        {
        }
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
        private Departmanlar departman;
        private string soyad;
        private string adi;
        private string kod;
        private Users tanimliKullanici;
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
        public string Adi
        {
            get
            {
                return adi;
            }
            set
            {
                SetPropertyValue(nameof(Adi), ref adi, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Soyad
        {
            get
            {
                return soyad;
            }
            set
            {
                SetPropertyValue(nameof(Soyad), ref soyad, value);
            }
        }

        [PersistentAlias("Concat([Adi],' ',[Soyad])")]
        [VisibleInDetailView(false)]
        public string AdSoyad => (string)EvaluateAlias(nameof(AdSoyad));


        public Users TanimliKullanici
        {
            get
            {
                return tanimliKullanici;
            }
            set
            {
                SetPropertyValue(nameof(TanimliKullanici), ref tanimliKullanici, value);
            }
        }
        
        public Departmanlar Departman
        {
            get
            {
                return departman;
            }
            set
            {
                SetPropertyValue(nameof(Departman), ref departman, value);
            }
        }

    }
}