using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    public class AdresTurleri : XPObject
    {
        public AdresTurleri(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
        #region Fields Region...
        private string tanim;
        private string kod;
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get
            {
                return kod;
            }
            set
            {
                SetPropertyValue(nameof(Kod), ref kod, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Tanim
        {
            get
            {
                return tanim;
            }
            set
            {
                SetPropertyValue(nameof(Tanim), ref tanim, value);
            }
        }
        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && Session.IsNewObject(this)
                        && string.IsNullOrEmpty(Kod))
            {
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "MyServerPrefix");
                KodTanimlari tanim = Session.FindObject<KodTanimlari>(new BinaryOperator("Tur",
                                                                                         EvrakTurleri.AdresTurleri));
                if (tanim != null)
                {
                    Kod = string.Format("{0}{1:D8}", tanim.Tanim, nextSequence);
                }
                else
                {
                    Kod = string.Format("{0:D8}", nextSequence);
                }
            }
            base.OnSaving();
        }
    }
}