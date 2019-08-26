using System;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ProjeGorevler : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ProjeGorevler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        #region Fields Region...
        private Projeler proje;
        private Personel personel;
        private Gorevler gorev;
        #endregion

        public Gorevler Gorev
        {
            get
            {
                return gorev;
            }
            set
            {
                SetPropertyValue(nameof(Gorev), ref gorev, value);
            }
        }

        public Personel Personel
        {
            get
            {
                return personel;
            }
            set
            {
                SetPropertyValue(nameof(Personel), ref personel, value);
            }
        }
        [Association]
        public Projeler Proje
        {
            get
            {
                return proje;
            }
            set
            {
                SetPropertyValue(nameof(Proje), ref proje, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 16.03.2019 01:44
        public new class FieldsClass : XPObject.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string GorevFieldName = "Gorev";

            public Gorevler.FieldsClass Gorev
            {
                get
                {
                    return new Gorevler.FieldsClass(GetNestedName(GorevFieldName));
                }
            }

            public const string PersonelFieldName = "Personel";

            public Personel.FieldsClass Personel
            {
                get
                {
                    return new Personel.FieldsClass(GetNestedName(PersonelFieldName));
                }
            }

            public const string ProjeFieldName = "Proje";

            public Projeler.FieldsClass Proje
            {
                get
                {
                    return new Projeler.FieldsClass(GetNestedName(ProjeFieldName));
                }
            }
        }

        public new static FieldsClass Fields
        {
            get
            {
                if (ReferenceEquals(_Fields, null))
                {
                    _Fields = (new FieldsClass());
                }

                return _Fields;
            }
        }

        private static FieldsClass _Fields;
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}