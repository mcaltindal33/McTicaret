using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BankadanBankaya : Evraklar
    {
        public BankadanBankaya(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Islem = IslemTurleri.Transfer;
            Turu = EvrakTurleri.BankadanBankayaTransfer;
            BankayaHareket = BankaHareketTuru.BankaGirisi;
            BankadanHareket = BankaHareketTuru.BankaCikisi;
            Tarih = DateTime.Now;
        }
        #region Fields Region...
        private BankaHareket bankayaIslem;
        private BankaHareket bankadanIslem;
        private BankaHareketTuru bankayaHareket;
        private BankaHesaplari bankaya;
        private BankaHareketTuru bankadanHareket;
        private BankaHesaplari bankadan;
        #endregion

        public BankaHesaplari Bankadan
        {
            get
            {
                return bankadan;
            }
            set
            {
                SetPropertyValue(nameof(Bankadan), ref bankadan, value);
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDashboards(false)]
        public BankaHareketTuru BankadanHareket
        {
            get
            {
                return bankadanHareket;
            }
            set
            {
                SetPropertyValue(nameof(BankadanHareket), ref bankadanHareket, value);
            }
        }

        public BankaHesaplari Bankaya
        {
            get
            {
                return bankaya;
            }
            set
            {
                SetPropertyValue(nameof(Bankaya), ref bankaya, value);
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDashboards(false)]
        public BankaHareketTuru BankayaHareket
        {
            get
            {
                return bankayaHareket;
            }
            set
            {
                SetPropertyValue(nameof(BankayaHareket), ref bankayaHareket, value);
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDashboards(false)]
        public BankaHareket BankadanIslem
        {
            get
            {
                return bankadanIslem;
            }
            set
            {
                SetPropertyValue(nameof(BankadanIslem), ref bankadanIslem, value);
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDashboards(false)]
        public BankaHareket BankayaIslem
        {
            get
            {
                return bankayaIslem;
            }
            set
            {
                SetPropertyValue(nameof(BankayaIslem), ref bankayaIslem, value);
            }
        }
        protected override void OnSaving()
        {
            if (BankadanIslem == null)
            {
                var BankadanIslems = new BankaHareket(Session)
                {
                    Aciklama = Aciklama,
                    Banka = Bankadan,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = BankadanHareket,
                    Islem = Islem,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar
                };
                BankadanIslems.Save();
                BankadanIslem = BankadanIslems;
            }
            else
            {
                BankaHareket BankadanIslems = BankadanIslem;
                BankadanIslems.Tutar = Tutar;
                BankadanIslems.Save();
            }
            if (BankayaIslem == null)
            {
                var BankayaIslems = new BankaHareket(Session)
                {
                    Aciklama = Aciklama,
                    Banka = Bankaya,
                    BelgeNo = BelgeNo,
                    Doviz = Doviz,
                    Hareket = BankayaHareket,
                    Islem = Islem,
                    Tarih = Tarih,
                    Turu = Turu,
                    Tutar = Tutar
                };
                BankayaIslems.Save();
                BankayaIslem = BankayaIslems;
            }
            else
            {
                BankaHareket BankadanIslems = BankayaIslem;
                BankadanIslems.Tutar = Tutar;
                BankadanIslems.Save();

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
            if (BankayaIslem != null)
                BankayaIslem.Delete();
            if (BankadanIslem != null)
                BankadanIslem.Delete();
            base.OnDeleting();
        }
    }
}