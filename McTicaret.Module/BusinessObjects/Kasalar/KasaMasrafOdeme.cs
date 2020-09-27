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
    public class KasaMasrafOdeme : KasaHareket
    { 
        public KasaMasrafOdeme(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Hareket = KasaHareketTuru.KasaCikisi;
            Islem = IslemTurleri.Cikan;
            Turu = EvrakTurleri.KasadanMasrafOdeme;
            Tarih = DateTime.Now;
        }

        #region Fields Region...
        private Masraflar masraf;
        #endregion
        [Association]
        public Masraflar Masraf
        {
            get
            {
                return masraf;
            }
            set
            {
                SetPropertyValue(nameof(Masraf), ref masraf, value);
            }
        }

    }
}