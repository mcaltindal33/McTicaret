using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Notifications;
using DevExpress.Persistent.Base.General;
using DevExpress.Data.Filtering;
using McTicaret.Module.BusinessObjects.Ajanda;
using DevExpress.ExpressApp.Scheduler;

namespace McTicaret.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class McTicaretModule : ModuleBase {
        public McTicaretModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            application.LoggedOn += Application_LoggedOn;
            // Manage various aspects of the application UI and behavior at the module level.
        }

        private void Application_LoggedOn(object sender, LogonEventArgs e)
        {
            NotificationsModule notificationsModule = Application.Modules.FindModule<NotificationsModule>();
            SchedulerModuleBase module = Application.Modules.FindModule<SchedulerModuleBase>();

            NotificationsProvider notificationsProvider = module.NotificationsProvider;
            notificationsProvider.CustomizeNotificationCollectionCriteria += notificationsProvider_CustomizeNotificationCollectionCriteria;

        }

        private void notificationsProvider_CustomizeNotificationCollectionCriteria(object sender, CustomizeCollectionCriteriaEventArgs e)
        {

                if (e.Type == typeof(Ajanda))
                {
                    e.Criteria = CriteriaOperator.Parse("User is null || User.Oid == CurrentUserId()");
                }
            }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
