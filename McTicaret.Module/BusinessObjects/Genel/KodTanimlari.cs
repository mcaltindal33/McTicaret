using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

using System;
using System.ComponentModel;
using System.Linq;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class KodTanimlari : BaseObject
    {
        public KodTanimlari(Session session) : base(session) { }
        bool _Gun;
        bool _Ay;
        bool _Yil;
        string _Ayrac;
        string _Kodu;
        Type _TabloTipi;

        [ValueConverter(typeof(TypeToStringConverter))]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        [Size(SizeAttribute.Unlimited)]
        [RuleUniqueValue]
        [XafDisplayName("Tablo Türü")]
        [Persistent("TableType")]
        public Type TabloTipi
        {
            get => _TabloTipi;
            set => SetPropertyValue(nameof(TabloTipi), ref _TabloTipi, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Kod")]
        [Persistent("Code")]
        public string Kodu
        {
            get => _Kodu;
            set => SetPropertyValue(nameof(Kodu), ref _Kodu, value);
        }

        [Size(1)]
        [XafDisplayName("Ayraç")]
        [Persistent("Brace")]
        public string Ayrac
        {
            get => _Ayrac;
            set => SetPropertyValue(nameof(Ayrac), ref _Ayrac, value);
        }

        [XafDisplayName("Yıl Ekle")]
        [Persistent("Year")]
        public bool Yil
        {
            get => _Yil;
            set => SetPropertyValue(nameof(Yil), ref _Yil, value);
        }

        [XafDisplayName("Ay Ekle")]
        [Persistent("Month")]
        public bool Ay
        {
            get => _Ay;
            set => SetPropertyValue(nameof(Ay), ref _Ay, value);
        }

        [XafDisplayName("Gün Ekle")]
        [Persistent("Day")]
        public bool Gun
        {
            get => _Gun;
            set => SetPropertyValue(nameof(Gun), ref _Gun, value);
        }

    }
}