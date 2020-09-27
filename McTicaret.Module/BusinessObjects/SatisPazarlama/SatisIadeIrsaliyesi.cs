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
    public class SatisIadeIrsaliyesi : StokIslemler
    { 
        public SatisIadeIrsaliyesi(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.SatisIadeIrsaliyesi;
            Islem = IslemTurleri.Irsaliye;
            Hareket = StokHareketTuru.StokGirisi;
            Tarih = DateTime.Now;
        }
    }
}