using DevExpress.ExpressApp;

using McTicaret.Module.BusinessObjects.TeknikServis;

using System;
using System.Linq;

namespace McTicaret.Module.Controllers
{
    public class TeknikServislerObjectViewController : ObjectViewController<ObjectView, TeknikServisler>
    {
        public TeknikServislerObjectViewController()
        {
            TargetObjectType = typeof(TeknikServisler);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }


        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (View.CurrentObject is TeknikServisler Teknik)
            {
                Teknik.AltToplam = Teknik.TeknikServisDetays.Sum(x => x.IskontosuzTutar);
                Teknik.IskontoToplam = Teknik.TeknikServisDetays.Sum(x => x.IskontoTutar);
                Teknik.VergiToplam = Teknik.TeknikServisDetays.Sum(x => x.VergiTutar);
                Teknik.GenelToplam = Teknik.TeknikServisDetays.Sum(x => x.ToplamTutar);
            }
        }

    }
}
