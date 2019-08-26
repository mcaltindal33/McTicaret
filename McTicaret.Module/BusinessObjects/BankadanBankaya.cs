using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
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
            XPCollection<BankadanBankaya> collection = new XPCollection<BankadanBankaya>(Session);
            if (collection.Count > 0)
            {
                switch (collection.Count.ToString().Length)
                {
                    case 1:
                        BelgeNo = $"000000{collection.Count + 1}";
                        break;
                    case 2:
                        BelgeNo = $"00000{collection.Count + 1}";
                        break;
                    case 3:
                        BelgeNo = $"0000{collection.Count + 1}";
                        break;
                    case 4:
                        BelgeNo = $"000{collection.Count + 1}";
                        break;
                    case 5:
                        BelgeNo = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        BelgeNo = $"0{collection.Count + 1}";
                        break;
                    default:
                        BelgeNo = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                BelgeNo = $"000000{collection.Count + 1}";
            }

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

        public new class FieldsClass : Evraklar.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string BankadanFieldName = "Bankadan";

            public BankaHesaplari.FieldsClass Bankadan => new BankaHesaplari.FieldsClass(GetNestedName(BankadanFieldName));

            public const string BankadanHareketFieldName = "BankadanHareket";

            public OperandProperty BankadanHareket => new OperandProperty(GetNestedName(BankadanHareketFieldName));

            public const string BankayaFieldName = "Bankaya";

            public BankaHesaplari.FieldsClass Bankaya => new BankaHesaplari.FieldsClass(GetNestedName(BankayaFieldName));

            public const string BankayaHareketFieldName = "BankayaHareket";

            public OperandProperty BankayaHareket => new OperandProperty(GetNestedName(BankayaHareketFieldName));

            public const string BankadanIslemFieldName = "BankadanIslem";

            public BankaHareket.FieldsClass BankadanIslem => new BankaHareket.FieldsClass(GetNestedName(BankadanIslemFieldName));

            public const string BankayaIslemFieldName = "BankayaIslem";

            public BankaHareket.FieldsClass BankayaIslem => new BankaHareket.FieldsClass(GetNestedName(BankayaIslemFieldName));
        }

        public static new FieldsClass Fields
        {
            get
            {
                if (ReferenceEquals(_Fields, null))
                {
                    _Fields = (new FieldsClass());
                }

                return _Fields;
            }
        }

        private static FieldsClass _Fields;
    }
}