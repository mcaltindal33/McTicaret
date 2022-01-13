using DevExpress.ExpressApp;

using McTicaret.Module.BusinessObjects;

using System;
using System.Linq;

namespace McTicaret.Module.Controllers
{
    public class StokIslemlerObjectViewController : ObjectViewController<ObjectView, StokIslemler>
    {
        public StokIslemlerObjectViewController()
        {
            //TargetObjectType = typeof(StokIslemler);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (View.CurrentObject is StokIslemler Islem)
            {
                Islem.AltToplam = Islem.HareketDetay.Sum(x => x.IndirimsizTutar);
                Islem.IndirimToplam = Islem.HareketDetay.Sum(x => x.IndirimTutar);
                Islem.KdvToplam = Islem.HareketDetay.Sum(x => x.KDVTutar);
                Islem.Tutar = Islem.HareketDetay.Sum(x => x.Toplam);
            }
        }

        protected override void OnDeactivated()
        {
            ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
            base.OnDeactivated();
        }
    }
}
