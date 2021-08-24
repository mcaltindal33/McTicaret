using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using McTicaret.Module.BusinessObjects;
using McTicaret.Module.BusinessObjects.TeknikServis;

namespace McTicaret.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            Users userAdmin = ObjectSpace.FindObject<Users>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<Users>();
                userAdmin.Adi = "Administrator";
                userAdmin.Soyad = "";
                userAdmin.EPosta = "";
                userAdmin.UserName = "Admin";
                userAdmin.SetPassword("");
            }
            PermissionPolicyRole adminRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
            userAdmin.Roles.Add(adminRole);

            Ulkeler ulke = ObjectSpace.FindObject<Ulkeler>(new BinaryOperator("Tanim", "Türkiye"));
            if(ulke == null)
            {
                if (ulke == null)
                {
                    ulke = ObjectSpace.CreateObject<Ulkeler>();
                    ulke.Tanim = "Türkiye";
                    ulke.Kod = "TR";
                }

                Sehirler sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Adana"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Adana";
                    sehir.Kod = "TR01";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Adıyaman"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Adıyaman";
                    sehir.Kod = "TR02";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Afyonkarahisar"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Afyonkarahisar";
                    sehir.Kod = "TR03";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Ağrı"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Ağrı";
                    sehir.Kod = "TR04";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Amasya"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Amasya";
                    sehir.Kod = "TR05";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Ankara"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Ankara";
                    sehir.Kod = "TR06";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Antalya"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Antalya";
                    sehir.Kod = "TR07";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Artvin"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Artvin";
                    sehir.Kod = "TR08";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Aydın"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Aydın";
                    sehir.Kod = "TR09";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Balıkesir"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Balıkesir";
                    sehir.Kod = "TR10";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bilecik"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bilecik";
                    sehir.Kod = "TR11";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bingöl"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bingöl";
                    sehir.Kod = "TR12";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bitlis"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bitlis";
                    sehir.Kod = "TR13";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bolu"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bolu";
                    sehir.Kod = "TR14";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Burdur"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Burdur";
                    sehir.Kod = "TR15";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bursa"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bursa";
                    sehir.Kod = "TR16";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Çanakkale"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Çanakkale";
                    sehir.Kod = "TR17";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Çankırı"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Çankırı";
                    sehir.Kod = "TR18";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Çorum"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Çorum";
                    sehir.Kod = "TR19";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Denizli"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Denizli";
                    sehir.Kod = "TR20";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Diyarbakır"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Diyarbakır";
                    sehir.Kod = "TR21";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Edirne"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Edirne";
                    sehir.Kod = "TR22";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Elazığ"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Elazığ";
                    sehir.Kod = "TR23";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Erzincan"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Erzincan";
                    sehir.Kod = "TR24";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Erzurum"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Erzurum";
                    sehir.Kod = "TR25";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Eskişehir"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Eskişehir";
                    sehir.Kod = "TR26";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Gaziantep"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Gaziantep";
                    sehir.Kod = "TR27";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Giresun"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Giresun";
                    sehir.Kod = "TR28";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Gümüşhane"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Gümüşhane";
                    sehir.Kod = "TR29";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Hakkari"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Hakkari";
                    sehir.Kod = "TR30";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Hatay"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Hatay";
                    sehir.Kod = "TR31";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Isparta"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Isparta";
                    sehir.Kod = "TR32";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Mersin"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Mersin";
                    sehir.Kod = "TR33";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "İstanbul"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "İstanbul";
                    sehir.Kod = "TR34";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "İzmir"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "İzmir";
                    sehir.Kod = "TR35";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kars"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kars";
                    sehir.Kod = "TR36";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kastamonu"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kastamonu";
                    sehir.Kod = "TR37";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kayseri"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kayseri";
                    sehir.Kod = "TR38";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kırklareli"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kırklareli";
                    sehir.Kod = "TR39";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kırşehir"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kırşehir";
                    sehir.Kod = "TR40";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kocaeli"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kocaeli";
                    sehir.Kod = "TR41";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Konya"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Konya";
                    sehir.Kod = "TR42";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kütahya"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kütahya";
                    sehir.Kod = "TR43";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Malatya"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Malatya";
                    sehir.Kod = "TR44";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Manisa"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Manisa";
                    sehir.Kod = "TR45";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kahramanmaraş"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kahramanmaraş";
                    sehir.Kod = "TR46";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Mardin"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Mardin";
                    sehir.Kod = "TR47";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Muğla"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Muğla";
                    sehir.Kod = "TR48";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Muş"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Muş";
                    sehir.Kod = "TR49";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Nevşehir"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Nevşehir";
                    sehir.Kod = "TR50";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Niğde"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Niğde";
                    sehir.Kod = "TR51";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Ordu"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Ordu";
                    sehir.Kod = "TR52";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Rize"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Rize";
                    sehir.Kod = "TR53";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Sakarya"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Sakarya";
                    sehir.Kod = "TR54";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Samsun"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Samsun";
                    sehir.Kod = "TR55";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Siirt"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Siirt";
                    sehir.Kod = "TR56";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Sinop"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Sinop";
                    sehir.Kod = "TR57";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Sivas"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Sivas";
                    sehir.Kod = "TR58";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Tekirdağ"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Tekirdağ";
                    sehir.Kod = "TR59";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Tokat"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Tokat";
                    sehir.Kod = "TR60";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Trabzon"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Trabzon";
                    sehir.Kod = "TR61";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Tunceli"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Tunceli";
                    sehir.Kod = "TR62";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Şanlıurfa"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Şanlıurfa";
                    sehir.Kod = "TR63";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Uşak"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Uşak";
                    sehir.Kod = "TR64";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Van"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Van";
                    sehir.Kod = "TR65";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Yozgat"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Yozgat";
                    sehir.Kod = "TR66";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Zonguldak"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Zonguldak";
                    sehir.Kod = "TR67";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Aksaray"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Aksaray";
                    sehir.Kod = "TR68";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bayburt"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bayburt";
                    sehir.Kod = "TR69";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Karaman"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Karaman";
                    sehir.Kod = "TR70";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kırıkkale"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kırıkkale";
                    sehir.Kod = "TR71";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Batman"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Batman";
                    sehir.Kod = "TR72";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Şırnak"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Şırnak";
                    sehir.Kod = "TR73";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Bartın"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Bartın";
                    sehir.Kod = "TR74";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Ardahan"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Ardahan";
                    sehir.Kod = "TR75";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Iğdır"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Iğdır";
                    sehir.Kod = "TR76";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Yalova"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Yalova";
                    sehir.Kod = "TR77";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Karabük"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Karabük";
                    sehir.Kod = "TR78";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Kilis"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Kilis";
                    sehir.Kod = "TR79";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Osmaniye"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Osmaniye";
                    sehir.Kod = "TR80";
                    sehir.Ulke = ulke;
                }
                sehir = ObjectSpace.FindObject<Sehirler>(new BinaryOperator("Tanim", "Düzce"));
                if (sehir == null)
                {
                    sehir = ObjectSpace.CreateObject<Sehirler>();
                    sehir.Tanim = "Düzce";
                    sehir.Kod = "TR81";
                    sehir.Ulke = ulke;
                }
            }

            BirimTurleri birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "ADET"));
            if(birim == null)
            {
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000001";
                    birim.Tanim = "ADET";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "Saat"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000002";
                    birim.Tanim = "Saat";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "M3"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000003";
                    birim.Tanim = "M3";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "KG"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000004";
                    birim.Tanim = "KG";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "M"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000005";
                    birim.Tanim = "M";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "M2"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000006";
                    birim.Tanim = "M2";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "TON"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000007";
                    birim.Tanim = "TON";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "ŞİŞE"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000008";
                    birim.Tanim = "ŞİŞE";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "KUTU"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000009";
                    birim.Tanim = "KUTU";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "KM"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000010";
                    birim.Tanim = "KM";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "GRAM"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000011";
                    birim.Tanim = "GRAM";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "ML"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000012";
                    birim.Tanim = "ML";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "DESTE"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000013";
                    birim.Tanim = "DESTE";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "KOLİ"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000014";
                    birim.Tanim = "KOLİ";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "AY"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000015";
                    birim.Tanim = "AY";
                }
                birim = ObjectSpace.FindObject<BirimTurleri>(new BinaryOperator("Tanim", "YIL"));
                if (birim == null)
                {
                    birim = ObjectSpace.CreateObject<BirimTurleri>();
                    birim.Kod = "0000016";
                    birim.Tanim = "YIL";
                }
            }

            DovizTurleri doviz = ObjectSpace.FindObject<DovizTurleri>(new BinaryOperator("Kod", "TRY"));
            if (doviz == null)
            {
                if (doviz == null)
                {
                    doviz = ObjectSpace.CreateObject<DovizTurleri>();
                    doviz.Kod = "TRY";
                    doviz.Tanim = "Türk Lirası";
                    doviz.AyrintiliTanim = "Türkiye Cumhuriyeti Para Birimi";
                    doviz.Aciklama = "Türkiye Cumhuriyet Merkez Bankası tarafindan çıkarılan Turkiyenin ulusal para birimi.";
                    doviz.Sembol = "₺";
                }
                doviz = ObjectSpace.FindObject<DovizTurleri>(new BinaryOperator("Kod", "USD"));
                if (doviz == null)
                {
                    doviz = ObjectSpace.CreateObject<DovizTurleri>();
                    doviz.Kod = "USD";
                    doviz.Tanim = "Amerikan Doları";
                    doviz.AyrintiliTanim = "Birleşik Amerika Devleti Para Birimi";
                    doviz.Aciklama = "Birleşik Amerika Devleti Para Birimi";
                    doviz.Sembol = "$";
                }
                doviz = ObjectSpace.FindObject<DovizTurleri>(new BinaryOperator("Kod", "EUR"));
                if (doviz == null)
                {
                    doviz = ObjectSpace.CreateObject<DovizTurleri>();
                    doviz.Kod = "EUR";
                    doviz.Tanim = "Euro";
                    doviz.AyrintiliTanim = "Avrupa Merkez Bankası Para Birimi";
                    doviz.Aciklama = "Avrupa Merkez Bankası tarafından çıkarılan Euro (EUR, tek para birimi) ";
                    doviz.Sembol = "€";
                }

            }

            KodTanimlariEkle(typeof(CariHesaplar), "CH", "-", false, false, false );
            KodTanimlariEkle(typeof(Stoklar), "STK", "-", false, false, false);
            KodTanimlariEkle(typeof(Depolar), "DP", "-", false, false, false);
            KodTanimlariEkle(typeof(AlisFaturasi), "ALF", "-", false, false, false);
            KodTanimlariEkle(typeof(AlisIadeFaturasi), "AİF", "-", false, false, false);
            KodTanimlariEkle(typeof(AlisIadeIrsaliye), "Aİİ", "-", false, false, false);
            KodTanimlariEkle(typeof(AlisIrsaliye), "ALİ", "-", false, false, false);
            KodTanimlariEkle(typeof(AlinanSerbestMeslek), "ASM", "-", false, false, false);
            KodTanimlariEkle(typeof(AlinanSiparis), "ALS", "-", false, false, false);
            KodTanimlariEkle(typeof(AlinanTekflif), "ALT", "-", false, false, false);
            KodTanimlariEkle(typeof(SatisFaturasi), "STF", "-", false, false, false);
            KodTanimlariEkle(typeof(TeknikServisler), "TSF", "-", false, false, false);
            ObjectSpace.CommitChanges(); //This line persists created object(s).
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if (CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0"))
            //{
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        void KodTanimlariEkle(Type Tip,string Kod,string Ayrac,bool Yil,bool Ay, bool Gun)
        {
            KodTanimlari kod = ObjectSpace.FindObject<KodTanimlari>(new BinaryOperator("TabloTipi", Tip));
            if(kod == null)
            {
                kod = ObjectSpace.CreateObject<KodTanimlari>();
                kod.Ay = Ay;
                kod.Ayrac = Ayrac;
                kod.Gun = Gun;
                kod.Kodu = Kod;
                kod.TabloTipi = Tip;
                kod.Yil = Yil;
            }
        }
    }
}
