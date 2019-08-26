﻿using System;
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
    public class SatisFaturasi : StokIslemler
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SatisFaturasi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Turu = EvrakTurleri.SatisFaturasi;
            Islem = IslemTurleri.Cikan;
            Hareket = StokHareketTuru.StokCikisi;
            Tarih = DateTime.Now;
            XPCollection<SatisFaturasi> collection = new XPCollection<SatisFaturasi>(Session);
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

            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        // Created/Updated: DESKTOP-18J0PDH\PetroDATA on DESKTOP-18J0PDH at 26.03.2019 18:20
        public new class FieldsClass : StokIslemler.FieldsClass
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