using LlamaTech.BE;
using LlamaTech.DA;
using System.Data;

namespace LlamaTech.BL
{
    public class HomePageBL
    {
        private HomePageDA homePageDA = new HomePageDA();

        // ABOUT US
        public DataSet allAbout() => homePageDA.getAboutUs();
        public DataSet getIdAbout(int id) => homePageDA.getAboutUsId(id);
        public void updateAbout(AboutBE aboutBE) => homePageDA.updateAboutUs(aboutBE);
        public void updateAboutUsLogo(AboutBE aboutBE) => homePageDA.updateAboutUsLogo(aboutBE);
        public void updateAboutUsImgBg(AboutBE aboutBE) => homePageDA.updateAboutUsImgBg(aboutBE);
        public void updateAboutUsSinImg(AboutBE aboutBE) => homePageDA.updateAboutUsSinImg(aboutBE);

        //END ABOUT US

        //CONTACTO
        public DataSet allContactos() => homePageDA.getContactos();
        public DataSet allContactosRp() => homePageDA.getContactosRP();
        public bool updateContacto(ContactoBE contactoBE) => homePageDA.updateContacto(contactoBE);
        public bool addContacto(ContactoBE contactoBE) => homePageDA.addContacto(contactoBE);
        public bool deleteContacto(int id) => homePageDA.deleteContacto(id);

        //END CONTACTO

        // RED SOCIAL
        public DataSet allRS() => homePageDA.getRS();
        public DataSet allRSActive() => homePageDA.getRSActivo();
        public bool updateRS(RedSocialBE redSocialBE) => homePageDA.updateRS(redSocialBE);
        public bool addRS(RedSocialBE redSocialBE) => homePageDA.addRS(redSocialBE);
        public bool deleteRS(int id) => homePageDA.deleteRS(id);

        //END RED SOCIAL

        // Iconos
        public DataSet allIcons() => homePageDA.getIcono();

        // END ICONOS


    }
}
