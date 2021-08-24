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
    public class KasadanKasaya : Evraklar
    { 
        public KasadanKasaya(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            KasadanHareket = KasaHareketTuru.KasaCikisi;
            KasayaHareket = KasaHareketTuru.KasaGirisi;
            Islem = IslemTurleri.Transfer;
            Turu = EvrakTurleri.KasadanKasayaTransfer;
            Tarih = DateTime.Now;
        }
        #region Fields Region...
        private KasaHareket kasayaIslem;
        private KasaHareket kasadanIslem;
        private KasaHareketTuru kasayaHareket;
        private Kasalar kasaya;
        private KasaHareketTuru kasadanHareket;
        private Kasalar kasadan;
        #endregion

        public Kasalar Kasadan
        {
            get
            {
                return kasadan;
            }
            set
            {
                SetPropertyValue(nameof(Kasadan), ref kasadan, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareketTuru KasadanHareket
        {
            get
            {
                return kasadanHareket;
            }
            set
            {
                SetPropertyValue(nameof(KasadanHareket), ref kasadanHareket, value);
            }
        }
        public Kasalar Kasaya
        {
            get
            {
                return kasaya;
            }
            set
            {
                SetPropertyValue(nameof(Kasaya), ref kasaya, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareketTuru KasayaHareket
        {
            get
            {
                return kasayaHareket;
            }
            set
            {
                SetPropertyValue(nameof(KasayaHareket), ref kasayaHareket, value);
            }
        }

        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareket KasadanIslem
        {
            get
            {
                return kasadanIslem;
            }
            set
            {

                SetPropertyValue(nameof(KasadanIslem), ref kasadanIslem, value);
            }
        }
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public KasaHareket KasayaIslem
        {
            get
            {
                return kasayaIslem;
            }
            set
            {

                SetPropertyValue(nameof(KasayaIslem), ref kasayaIslem, value);
            }
        }

        protected override void OnSaving()
        {
            if (KasadanIslem == null)
            {
                KasaHareket KasadanIslems = new KasaHareket(Session)
                {
                    Aciklama = Aciklama,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = KasadanHareket,
                    Islem = Islem,
                    Kasa = Kasadan,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar
                };
                KasadanIslems.Save();
                kasadanIslem = KasadanIslems;
            }
            if (KasayaIslem == null)
            {
                KasaHareket KasayaIslems = new KasaHareket(Session)
                {
                    Aciklama = Aciklama,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = KasayaHareket,
                    Islem = Islem,
                    Kasa = Kasaya,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar
                };
                KasayaIslems.Save();
                KasayaIslem = KasayaIslems;
            }
            if(KasayaIslem != null)
            {
                KasaHareket k1 = KasayaIslem;
                k1.Tutar = Tutar;
                k1.Save();
            }
            if(KasadanIslem != null)
            {
                KasaHareket k2 = KasadanIslem;
                k2.Tutar = Tutar;
                k2.Save();
            }
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

            base.OnSaving();
        }
        protected override void OnDeleting()
        {
            if(KasadanIslem != null)
                KasadanIslem.Delete();
            if(KasayaIslem != null)
                KasayaIslem.Delete();
            base.OnDeleting();
        }

    }
}