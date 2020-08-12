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
    public class AlisIadeIrsaliye : StokIslemler
    { 
        public AlisIadeIrsaliye(Session session) : base(session){ }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.AlimIadeIrsaliye;
            Islem = IslemTurleri.Irsaliye;
            Hareket = StokHareketTuru.StokCikisi;
            Tarih = DateTime.Now;
        }
        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                 && (Session.DataLayer != null)
                 && Session.IsNewObject(this)
                 && string.IsNullOrEmpty(Kod))
            {
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("Tur", EvrakTurleri.AlimIadeIrsaliye));
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