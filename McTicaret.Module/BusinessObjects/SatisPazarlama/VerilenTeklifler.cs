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
    public class VerilenTeklifler : StokIslemler
    { 
        public VerilenTeklifler(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.VerilenTeklif;
            Islem = IslemTurleri.Teklif;
            Hareket = StokHareketTuru.TeklifSiparis;
            Tarih = DateTime.Now;
        }
        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && Session.IsNewObject(this)
                        && string.IsNullOrEmpty(Kod))
            {
                int dist = DistributedIdGeneratorHelper.Generate(Session.DataLayer, GetType().Name, $"VerilenTeklifler{Tarih.Year}{Tarih.Month}");
                Kod = string.Format("PRP-{0}-{1}-{2:D5}", Tarih.Year, Tarih.Month, dist);
            }
            base.OnSaving();
        }

    }
}