using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using McTicaret.Module.BusinessObjects;
using McTicaret.Module.BusinessObjects.TeknikServis;

namespace McTicaret.Module.Controllers
{
    public class CustomizeNewActionItemsListController : ObjectViewController<ObjectView, Evraklar>
    {
        private void Controller_CollectCreatableItemTypes(object sender, CollectTypesEventArgs e)
        {
            CustomizeList(e.Types);
        }
        private void Controller_CollectDescendantTypes(object sender, CollectTypesEventArgs e)
        {
            CustomizeList(e.Types);
        }
        private void CustomizeList(ICollection<Type> types)
        {
            List<Type> _list = new List<Type>();

            foreach (Type item in types)
            {
                if (item == typeof(StokIslemler))
                    _list.Add(item);
                if (item == typeof(Evraklar))
                    _list.Add(item);
                if (item == typeof(BankaHareket))
                    _list.Add(item);
            }
            foreach (Type item in _list)
            {
                types.Remove(item);
            }

        }
        protected override void OnActivated()
        {
            base.OnActivated();
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null)
            {
                controller.CollectCreatableItemTypes += Controller_CollectCreatableItemTypes;
                controller.CollectDescendantTypes += Controller_CollectDescendantTypes;
                if (controller.Active)
                {
                    controller.UpdateNewObjectAction();
                }
            }
        }
        protected override void OnDeactivated()
        {
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null)
            {
                controller.CollectCreatableItemTypes -= Controller_CollectCreatableItemTypes;
                controller.CollectDescendantTypes -= Controller_CollectDescendantTypes;
            }
            base.OnDeactivated();
        }

    }
}
