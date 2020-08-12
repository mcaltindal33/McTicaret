using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(AdSoyad))]
    public class Personel : XPObject
    {
        public Personel(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<Personel> collection = new XPCollection<Personel>(Session);
            if (collection.Count > 0)
            {
                switch (collection.Count.ToString().Length)
                {
                    case 1:
                        Kod = $"000000{collection.Count + 1}";
                        break;
                    case 2:
                        Kod = $"00000{collection.Count + 1}";
                        break;
                    case 3:
                        Kod = $"0000{collection.Count + 1}";
                        break;
                    case 4:
                        Kod = $"000{collection.Count + 1}";
                        break;
                    case 5:
                        Kod = $"00{collection.Count + 1}";
                        break;
                    case 6:
                        Kod = $"0{collection.Count + 1}";
                        break;
                    default:
                        Kod = $"{collection.Count + 1}";
                        break;
                }
            }
            else
            {
                Kod = $"000000{collection.Count + 1}";
            }
        }
        #region Fields Region...
        private Departmanlar departman;
        private string soyad;
        private string adi;
        private string kod;
        private Users tanimliKullanici;
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
        public string Adi
        {
            get
            {
                return adi;
            }
            set
            {
                SetPropertyValue(nameof(Adi), ref adi, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Soyad
        {
            get
            {
                return soyad;
            }
            set
            {
                SetPropertyValue(nameof(Soyad), ref soyad, value);
            }
        }

        [PersistentAlias("Concat([Adi],' ',[Soyad])")]
        [VisibleInDetailView(false)]
        public string AdSoyad => (string)EvaluateAlias(nameof(AdSoyad));


        public Users TanimliKullanici
        {
            get
            {
                return tanimliKullanici;
            }
            set
            {
                SetPropertyValue(nameof(TanimliKullanici), ref tanimliKullanici, value);
            }
        }
        
        public Departmanlar Departman
        {
            get
            {
                return departman;
            }
            set
            {
                SetPropertyValue(nameof(Departman), ref departman, value);
            }
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:57
        public new class FieldsClass : XPObject.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public const string KodFieldName = "Kod";

            public OperandProperty Kod
            {
                get
                {
                    return new OperandProperty(GetNestedName(KodFieldName));
                }
            }

            public const string AdiFieldName = "Adi";

            public OperandProperty Adi
            {
                get
                {
                    return new OperandProperty(GetNestedName(AdiFieldName));
                }
            }

            public const string SoyadFieldName = "Soyad";

            public OperandProperty Soyad
            {
                get
                {
                    return new OperandProperty(GetNestedName(SoyadFieldName));
                }
            }

            public const string AdSoyadFieldName = "AdSoyad";

            public OperandProperty AdSoyad
            {
                get
                {
                    return new OperandProperty(GetNestedName(AdSoyadFieldName));
                }
            }

            public const string TanimliKullaniciFieldName = "TanimliKullanici";

            public Users.FieldsClass TanimliKullanici
            {
                get
                {
                    return new Users.FieldsClass(GetNestedName(TanimliKullaniciFieldName));
                }
            }

            public const string DepartmanFieldName = "Departman";

            public XPObject.FieldsClass Departman
            {
                get
                {
                    return new XPObject.FieldsClass(GetNestedName(DepartmanFieldName));
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