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
    public class SatisIrsaliye : StokIslemler
    { 
        public SatisIrsaliye(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.SatisIrsaliyesi;
            Islem = IslemTurleri.Irsaliye;
            Hareket = StokHareketTuru.StokCikisi;
            Tarih = DateTime.Now;
        }
    }
}