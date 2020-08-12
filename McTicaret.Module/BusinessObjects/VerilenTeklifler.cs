﻿using System;
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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class VerilenTeklifler : StokIslemler
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public VerilenTeklifler(Session session)
            : base(session)
        {
        }
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