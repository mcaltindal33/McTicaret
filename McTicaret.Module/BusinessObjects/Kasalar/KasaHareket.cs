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
    public class KasaHareket : Evraklar
    {
        public KasaHareket(Session session) : base(session) { }
        #region Fields Region...
        private KasaHareketTuru hareket;
        private Kasalar kasa;
        #endregion
        [Association]
        public Kasalar Kasa
        {
            get
            {
                return kasa;
            }
            set
            {
                SetPropertyValue(nameof(Kasa), ref kasa, value);
            }
        }

        public KasaHareketTuru Hareket
        {
            get
            {
                return hareket;
            }
            set
            {
                SetPropertyValue(nameof(Hareket), ref hareket, value);
            }
        }

    }
}