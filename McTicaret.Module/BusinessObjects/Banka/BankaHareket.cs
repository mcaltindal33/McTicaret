using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BankaHareket : Evraklar
    {
        public BankaHareket(Session session) : base(session) { }
        public override void AfterConstruction() => base.AfterConstruction();
        #region Fields Region...
        private BankaHareketTuru hareket;
        private BankaHesaplari banka;
        #endregion
        [Association]
        public BankaHesaplari Banka
        {
            get
            {
                return banka;
            }
            set
            {
                SetPropertyValue(nameof(Banka), ref banka, value);
            }
        }

        public BankaHareketTuru Hareket
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