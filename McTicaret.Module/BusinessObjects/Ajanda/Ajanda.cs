using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace McTicaret.Module.BusinessObjects.Ajanda
{
    public class Ajanda : Event
    { 
        public Ajanda(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            User = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
        }

        PermissionPolicyUser fUser;

        public PermissionPolicyUser User
        {
            get => fUser;
            set => SetPropertyValue(nameof(User), ref fUser, value);
        }
    }
}