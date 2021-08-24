using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(AdSoyad))]
    public class Users : PermissionPolicyUser
    {
        public Users(Session session)
            : base(session)
        {
        }

        #region Fields Region...
        private Departmanlar gorevi;
        private string ePosta;
        private string soyad;
        private string adi;
        #endregion

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
        public string AdSoyad
        {
            get { return (string)EvaluateAlias(nameof(AdSoyad)); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EPosta
        {
            get
            {
                return ePosta;
            }
            set
            {
                SetPropertyValue(nameof(EPosta), ref ePosta, value);
            }
        }

        public Departmanlar Gorevi
        {
            get
            {
                return gorevi;
            }
            set
            {
                SetPropertyValue(nameof(Gorevi), ref gorevi, value);
            }
        }

    }
}