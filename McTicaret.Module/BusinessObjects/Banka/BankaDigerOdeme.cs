using System;
using System.Linq;

using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BankaDigerOdeme : BankaHareket
    {
        public BankaDigerOdeme(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.BankadanDigerOdeme;
            Hareket = BankaHareketTuru.BankaCikisi;
            Islem = IslemTurleri.Cikan;
            Tarih = DateTime.Now;
        }
        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Kod))
            {
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("Tur", EvrakTurleri.BankadanDigerOdeme));
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, $"{tanim.Tanim}Prefix");
                if (tanim != null)
                {
                    Kod = string.Format("{0}{1:D8}", tanim.Tanim, nextSequence);
                }
                else
                {
                    Kod = string.Format("{0:D8}", nextSequence);
                }
            }
            base.OnSaving();
        }
    }
}