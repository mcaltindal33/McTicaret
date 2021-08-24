using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;
using System.Linq;

namespace McTicaret.Module.BusinessObjects.TeknikServis
{
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    public class TeknikServisDetay : BaseObject
    {
        public TeknikServisDetay(Session session) : base(session) { }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == nameof(Stok))
            {
                Vergi = Stok.SatisKDV;
                Birim = Stok.Birim;
                BirimFiyat = Stok.PerakendeSatis;
            }
            if (propertyName == nameof(Miktar) || propertyName == nameof(BirimFiyat) || propertyName == nameof(IskontoOran) || propertyName == nameof(IskontosuzTutar)|| propertyName == nameof(IskontoTutar)|| propertyName == nameof(NetTutar) || propertyName == nameof(Vergi) || propertyName == nameof(VergiTutar))
            {
                if(!IsLoading && !IsSaving)
                {
                    IskontosuzHesap();
                    IskontoTutarHesaplar();
                    NetTutarHesapla();
                    VergiHesapla();
                    ToplamHesapla();
                }
            }
        }

        private void ToplamHesapla()
        {
            ToplamTutar = NetTutar + VergiTutar;
        }

        private void VergiHesapla()
        {
            if (Vergi != null)
                VergiTutar = NetTutar * (Vergi.Oran / 100);
        }

        private void NetTutarHesapla()
        {
            NetTutar = IskontosuzTutar - IskontoTutar;
        }

        private void IskontoTutarHesaplar()
        {
            IskontoTutar = IskontosuzTutar * (IskontoOran / 100);
        }

        private void IskontosuzHesap()
        {
            IskontosuzTutar = Miktar * BirimFiyat;
        }

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
        [VisibleInDetailView(false), VisibleInListView(false)]
        public TeknikServisler Servis
        {
            get => _Servis;
            set => SetPropertyValue(nameof(Servis), ref _Servis, value);
        }

        [ImmediatePostData]
        public Stoklar Stok
        {
            get => _Stok;
            set => SetPropertyValue(nameof(Stok), ref _Stok, value);
        }

        [ModelDefault("DisplayFormat","N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double Miktar
        {
            get => _Miktar;
            set => SetPropertyValue(nameof(Miktar), ref _Miktar, value);
        }

        [ImmediatePostData]
        public BirimTurleri Birim
        {
            get => _Birim;
            set => SetPropertyValue(nameof(Birim), ref _Birim, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double BirimFiyat
        {
            get => _BirimFiyat;
            set => SetPropertyValue(nameof(BirimFiyat), ref _BirimFiyat, value);
        }

        [Appearance("EnableIskontosuzTutar", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IskontosuzTutar
        {
            get => _IskontosuzTutar;
            set => SetPropertyValue(nameof(IskontosuzTutar), ref _IskontosuzTutar, value);
        }

        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IskontoOran
        {
            get => _IskontoOran;
            set => SetPropertyValue(nameof(IskontoOran), ref _IskontoOran, value);
        }

        [Appearance("EnableIskontoTutar", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double IskontoTutar
        {
            get => _IskontoTutar;
            set => SetPropertyValue(nameof(IskontoTutar), ref _IskontoTutar, value);
        }

        [Appearance("EnableNetTutar", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double NetTutar
        {
            get => _NetTutar;
            set => SetPropertyValue(nameof(NetTutar), ref _NetTutar, value);
        }

        [ImmediatePostData]
        public VergiTurleri Vergi
        {
            get => _Vergi;
            set => SetPropertyValue(nameof(Vergi), ref _Vergi, value);
        }

        [Appearance("EnableVergiTutar", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double VergiTutar
        {
            get => _VergiTutar;
            set => SetPropertyValue(nameof(VergiTutar), ref _VergiTutar, value);
        }

        [Appearance("EnableToplamTutar", Enabled = false)]
        [ModelDefault("DisplayFormat", "N2")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public double ToplamTutar
        {
            get => _ToplamTutar;
            set => SetPropertyValue(nameof(ToplamTutar), ref _ToplamTutar, value);
        }
    }
}