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
    public class KasaHareket : Evraklar
    {
        public KasaHareket()
        {

        }
        public KasaHareket(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        #region Fields Region...
        private KasaHareketTuru hareket;
        private Kasalar kasa;
        #endregion
        [Association]
        public Kasalar Kasa
        {
            get
            {
                return kasa;
            }
            set
            {
                SetPropertyValue(nameof(Kasa), ref kasa, value);
            }
        }

        public KasaHareketTuru Hareket
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

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 17.03.2019 16:55
        public new class FieldsClass : Evraklar.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KasaFieldName = "Kasa";

            public Kasalar.FieldsClass Kasa
            {
                get
                {
                    return new Kasalar.FieldsClass(GetNestedName(KasaFieldName));
                }
            }

            public const string HareketFieldName = "Hareket";

            public OperandProperty Hareket
            {
                get
                {
                    return new OperandProperty(GetNestedName(HareketFieldName));
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
    }
}