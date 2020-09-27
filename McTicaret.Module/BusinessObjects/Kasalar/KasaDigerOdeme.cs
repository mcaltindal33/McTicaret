using System;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class KasaDigerOdeme : KasaHareket
    {
        public KasaDigerOdeme(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.KasadanDigerNakitOdeme;
            Tarih = DateTime.Now;
        }
    }
}