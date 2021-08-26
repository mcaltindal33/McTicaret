using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.PivotGrid.QueryMode;
using DevExpress.Xpo;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace McTicaret.Module.BusinessObjects.TeknikServis
{
    [DefaultClassOptions]
    public class TeknikServisler : BaseObject
    {
        public TeknikServisler(Session session) : base(session) { }
        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kodu))
            {
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, $"TeknikServis{DateTime.Now.Year}{DateTime.Now.Month}Prefix");
                Kodu = $"SER-{DateTime.Now.Year}-{DateTime.Now.Month}-{nextSequence:D5}";
            }

            base.OnSaving();
        }

        Personel _Person;
        CariHesapKontak _IlgiliKisi;
        CariHesapAdresler _Adres;
        double _GenelToplam;
        double _VergiToplam;
        double _IskontoToplam;
        double _AltToplam;
        string _Sonuc;
        string _Ariza;
        DateTime _Tarih;
        CariHesaplar _Hesap;
        string _Kodu;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Appearance("EnableKodu", Enabled = false)]
        public string Kodu
        {
            get => _Kodu;
            set => SetPropertyValue(nameof(Kodu), ref _Kodu, value);
        }

        [ImmediatePostData]
        public CariHesaplar Hesap
        {
            get => _Hesap;
            set => SetPropertyValue(nameof(Hesap), ref _Hesap, value);
        }

        [DataSourceProperty("Hesap.Adresler")]
        public CariHesapAdresler Adres
        {
            get => _Adres;
            set => SetPropertyValue(nameof(Adres), ref _Adres, value);
        }

        [DataSourceProperty("Hesap.IlgiliKisi")]
        public CariHesapKontak IlgiliKisi
        {
            get => _IlgiliKisi;
            set => SetPropertyValue(nameof(IlgiliKisi), ref _IlgiliKisi, value);
        }

        [ModelDefault("DisplayFormat", "G")]
        public DateTime Tarih
        {
            get => _Tarih;
            set => SetPropertyValue(nameof(Tarih), ref _Tarih, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string Ariza
        {
            get => _Ariza;
            set => SetPropertyValue(nameof(Ariza), ref _Ariza, value);
        }

        [Size(SizeAttribute.Unlimited)]
        public string Sonuc
        {
            get => _Sonuc;
            set => SetPropertyValue(nameof(Sonuc), ref _Sonuc, value);
        }

        [Appearance("EnableAltToplam", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        public double AltToplam
        {
            get => _AltToplam;
            set => SetPropertyValue(nameof(AltToplam), ref _AltToplam, value);
        }

        [Appearance("EnableIskontoToplam", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        public double IskontoToplam
        {
            get => _IskontoToplam;
            set => SetPropertyValue(nameof(IskontoToplam), ref _IskontoToplam, value);
        }

        [Appearance("EnableVergiToplam", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        public double VergiToplam
        {
            get => _VergiToplam;
            set => SetPropertyValue(nameof(VergiToplam), ref _VergiToplam, value);
        }

        [Appearance("EnableGenelToplam", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        public double GenelToplam
        {
            get => _GenelToplam;
            set => SetPropertyValue(nameof(GenelToplam), ref _GenelToplam, value);
        }
        
        [XafDisplayName("Teknik Personel")]
        public Personel Person
        {
            get => _Person;
            set => SetPropertyValue(nameof(Person), ref _Person, value);
        }
        [Association("TeknikServisler-TeknikServisDetays")]
        public XPCollection<TeknikServisDetay> TeknikServisDetays => GetCollection<TeknikServisDetay>(nameof(TeknikServisDetays));
    }
}