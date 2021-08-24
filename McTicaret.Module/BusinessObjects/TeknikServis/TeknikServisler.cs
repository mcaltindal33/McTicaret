using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
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


        string _Sonuc;
        string _Ariza;
        DateTime _Tarih;
        CariHesaplar _Hesap;
        string _Kodu;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kodu
        {
            get => _Kodu;
            set => SetPropertyValue(nameof(Kodu), ref _Kodu, value);
        }

        public CariHesaplar Hesap
        {
            get => _Hesap;
            set => SetPropertyValue(nameof(Hesap), ref _Hesap, value);
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

        [Association("TeknikServisler-TeknikServisDetays")]
        public XPCollection<TeknikServisDetay> TeknikServisDetays => GetCollection<TeknikServisDetay>(nameof(TeknikServisDetays));
    }


    public class TeknikServisDetay : BaseObject
    {
        public TeknikServisDetay(Session session) : base(session) { }

        double _ToplamTutar;
        double _VergiTutar;
        VergiTurleri _Vergi;
        double _NetTutar;
        double _IskontoTutar;
        double _IskontoOran;
        double _IskontosuzTutar;
        double _BirimFiyat;
        BirimTurleri _Birim;
        double _Miktar;
        Stoklar _Stok;
        TeknikServisler _Servis;

        [Association("TeknikServisler-TeknikServisDetays")]
        public TeknikServisler Servis
        {
            get => _Servis;
            set => SetPropertyValue(nameof(Servis), ref _Servis, value);
        }


        public Stoklar Stok
        {
            get => _Stok;
            set => SetPropertyValue(nameof(Stok), ref _Stok, value);
        }

        public double Miktar
        {
            get => _Miktar;
            set => SetPropertyValue(nameof(Miktar), ref _Miktar, value);
        }

        public BirimTurleri Birim
        {
            get => _Birim;
            set => SetPropertyValue(nameof(Birim), ref _Birim, value);
        }

        public double BirimFiyat
        {
            get => _BirimFiyat;
            set => SetPropertyValue(nameof(BirimFiyat), ref _BirimFiyat, value);
        }


        public double IskontosuzTutar
        {
            get => _IskontosuzTutar;
            set => SetPropertyValue(nameof(IskontosuzTutar), ref _IskontosuzTutar, value);
        }

        public double IskontoOran
        {
            get => _IskontoOran;
            set => SetPropertyValue(nameof(IskontoOran), ref _IskontoOran, value);
        }

        public double IskontoTutar
        {
            get => _IskontoTutar;
            set => SetPropertyValue(nameof(IskontoTutar), ref _IskontoTutar, value);
        }

        public double NetTutar
        {
            get => _NetTutar;
            set => SetPropertyValue(nameof(NetTutar), ref _NetTutar, value);
        }

        public VergiTurleri Vergi
        {
            get => _Vergi;
            set => SetPropertyValue(nameof(Vergi), ref _Vergi, value);
        }

        public double VergiTutar
        {
            get => _VergiTutar;
            set => SetPropertyValue(nameof(VergiTutar), ref _VergiTutar, value);
        }

        public double ToplamTutar
        {
            get => _ToplamTutar;
            set => SetPropertyValue(nameof(ToplamTutar), ref _ToplamTutar, value);
        }
    }
}