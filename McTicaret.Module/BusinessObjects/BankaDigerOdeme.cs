using System;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BankaDigerOdeme : BankaHareket
    {
        public BankaDigerOdeme(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
             base.AfterConstruction();
            Turu = EvrakTurleri.BankadanDigerOdeme;
            Hareket = BankaHareketTuru.BankaCikisi;
            Islem = IslemTurleri.Cikan;
            Tarih = DateTime.Now;
            XPCollection<BankaDigerOdeme> collection = new XPCollection<BankaDigerOdeme>(Session);
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

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:20
        public new class FieldsClass : BankaHareket.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

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