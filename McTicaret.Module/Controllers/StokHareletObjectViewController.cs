using DevExpress.ExpressApp;

using McTicaret.Module.BusinessObjects;

namespace McTicaret.Module.Controllers
{
    public class StokHareletObjectViewController: ObjectViewController<ObjectView, StokHareketleri>
    {
        public StokHareletObjectViewController()
        {
            TargetObjectType = typeof(StokHareketleri);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if(ViewCurrentObject is StokHareketleri fDetay)
            {
                fDetay.IndirimsizTutar = fDetay.Miktar * fDetay.BirimFiyat;
                fDetay.IndirimTutar = fDetay.IndirimsizTutar * fDetay.IndirimOran / 100;
                fDetay.NetTutar = fDetay.IndirimsizTutar - fDetay.IndirimTutar;
                fDetay.KDVTutar = fDetay.NetTutar * fDetay.KDVOrani / 100;
                fDetay.Toplam = fDetay.NetTutar + fDetay.KDVTutar;
                if(fDetay.Evrak != null)
                {
                    fDetay.Doviz = fDetay.Doviz;
                    fDetay.Depo = fDetay.Depo;

                }
            }
        }
    }
}
