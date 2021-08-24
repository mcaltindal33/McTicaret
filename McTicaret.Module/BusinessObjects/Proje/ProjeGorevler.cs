using System;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace McTicaret.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ProjeGorevler : XPObject
    { 
        public ProjeGorevler(Session session)
            : base(session)
        {
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
    }
}