using LlamaTech.BE;
using LlamaTech.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void updateContacto(ContactoBE contactoBE) => homePageDA.updateContacto(contactoBE);
        public void addContacto(ContactoBE contactoBE) => homePageDA.addContacto(contactoBE);
        public void deleteContacto(int id) => homePageDA.deleteContacto(id);

        //END CONTACTO

        // RED SOCIAL
        public DataSet allRS() => homePageDA.getRS();
        public DataSet allRSActive() => homePageDA.getRSActivo();
        public void updateRS(RedSocialBE redSocialBE) => homePageDA.updateRS(redSocialBE);
        public void addRS(RedSocialBE redSocialBE) => homePageDA.addRS(redSocialBE);
        public void deleteRS(int id) => homePageDA.deleteRS(id);

        //END RED SOCIAL

        // Iconos
        public DataSet allIcons() => homePageDA.getIcono();

        // END ICONOS


    }
}
