using System;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class SatisFaturasi : StokIslemler
    { 
        public SatisFaturasi(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.SatisFaturasi;
            Islem = IslemTurleri.Cikan;
            Hareket = StokHareketTuru.StokCikisi;
            Tarih = DateTime.Now;
        }

    }
}