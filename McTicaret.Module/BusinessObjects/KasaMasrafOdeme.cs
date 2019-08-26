using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KasaMasrafOdeme : KasaHareket
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public KasaMasrafOdeme(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Hareket = KasaHareketTuru.KasaCikisi;
            Islem = IslemTurleri.Cikan;
            Turu = EvrakTurleri.KasadanMasrafOdeme;
            Tarih = DateTime.Now;
            XPCollection<KasaMasrafOdeme> collection = new XPCollection<KasaMasrafOdeme>(Session);
            if (collection.Count > 0)
            {
                switch (collection.Count.ToString().Length)
                {
                    case 1:
                        BelgeNo = $"000000{collection.Count + 1}";
                        break;
                    case 2:
                        BelgeNo = $"00000{collection.Count + 1}";
                        break;
                    case 3:
                        BelgeNo = $"0000{collection.Count + 1}";
                        break;
                    case 4:
                        BelgeNo = $"000{collection.Count + 1}";
                        break;
                    case 5:
                        BelgeNo = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        BelgeNo = $"0{collection.Count + 1}";
                        break;
                    default:
                        BelgeNo = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                BelgeNo = $"000000{collection.Count + 1}";
            }

        }

        #region Fields Region...
        private Masraflar masraf;
        #endregion
        [Association]
        public Masraflar Masraf
        {
            get
            {
                return masraf;
            }
            set
            {
                SetPropertyValue(nameof(Masraf), ref masraf, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:20
        public new class FieldsClass : KasaHareket.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string MasrafFieldName = "Masraf";

            public Masraflar.FieldsClass Masraf
            {
                get
                {
                    return new Masraflar.FieldsClass(GetNestedName(MasrafFieldName));
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