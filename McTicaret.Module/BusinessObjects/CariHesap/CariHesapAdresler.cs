using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

using System;
using System.ComponentModel;
using System.Linq;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Adres))]
    public class CariHesapAdresler : XPObject
    {

        #region Fields Region...
        private bool varsayilanSevk;
        private bool varsayilan;
        private AdresTurleri adresTur;
        private string bina;
        private int binaNo;
        private Caddeler cadde;
        private CariHesaplar cariHesap;
        private int daireNo;
        private string fax;
        private string gSM;
        private Ilceler ılce;
        private Mahalle mahalle;
        private int postaKodu;
        private Sehirler sehir;
        private string telefon;
        private Ulkeler ulke;
        #endregion

        public CariHesapAdresler(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction() => base.AfterConstruction();

        #region Properties Region..
        [PersistentAlias("Concat([Mahalle],' Mah. ',[Cadde],' ',[Bina],' No:',[BinaNo],'/',[DaireNo],' ',[Ilce],'/',[Sehir])")]
        public string Adres => (string)EvaluateAlias(nameof(Adres));
        public AdresTurleri AdresTur
        {
            get
            {
                return adresTur;
            }
            set
            {
                SetPropertyValue(nameof(AdresTur), ref adresTur, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Bina
        {
            get
            {
                return bina;
            }
            set
            {
                SetPropertyValue(nameof(Bina), ref bina, value);
            }
        }
        public int BinaNo
        {
            get
            {
                return binaNo;
            }
            set
            {
                SetPropertyValue(nameof(BinaNo), ref binaNo, value);
            }
        }
        public Caddeler Cadde
        {
            get
            {
                return cadde;
            }
            set
            {
                SetPropertyValue(nameof(Cadde), ref cadde, value);
            }
        }
        [Association]
        public CariHesaplar CariHesap
        {
            get
            {
                return cariHesap;
            }
            set
            {
                SetPropertyValue(nameof(CariHesap), ref cariHesap, value);
            }
        }
        public int DaireNo
        {
            get
            {
                return daireNo;
            }
            set
            {
                SetPropertyValue(nameof(DaireNo), ref daireNo, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                SetPropertyValue(nameof(Fax), ref fax, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GSM
        {
            get
            {
                return gSM;
            }
            set
            {
                SetPropertyValue(nameof(GSM), ref gSM, value);
            }
        }
        public Ilceler Ilce
        {
            get
            {
                return ılce;
            }
            set
            {
                SetPropertyValue(nameof(Ilce), ref ılce, value);
            }
        }
        public Mahalle Mahalle
        {
            get
            {
                return mahalle;
            }
            set
            {
                SetPropertyValue(nameof(Mahalle), ref mahalle, value);
            }
        }
        public int PostaKodu
        {
            get
            {
                return postaKodu;
            }
            set
            {
                SetPropertyValue(nameof(PostaKodu), ref postaKodu, value);
            }
        }
        public Sehirler Sehir
        {
            get
            {
                return sehir;
            }
            set
            {
                SetPropertyValue(nameof(Sehir), ref sehir, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                SetPropertyValue(nameof(Telefon), ref telefon, value);
            }
        }
        public Ulkeler Ulke
        {
            get
            {
                return ulke;
            }
            set
            {
                SetPropertyValue(nameof(Ulke), ref ulke, value);
            }
        }
        public bool Varsayilan
        {
            get
            {
                return varsayilan;
            }
            set
            {
                SetPropertyValue(nameof(Varsayilan), ref varsayilan, value);
            }
        }
        public bool VarsayilanSevk
        {
            get
            {
                return varsayilanSevk;
            }
            set
            {
                SetPropertyValue(nameof(VarsayilanSevk), ref varsayilanSevk, value);
            }
        }

        #endregion

    }
}