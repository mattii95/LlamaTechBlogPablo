using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Data;
using System.Web.Services;

namespace LlamaTech.web_admin
{
    public partial class frmHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                verDatosAbout();
                verDatosContacto();
                iconoContacto();

                verDatosRS();
                iconoContactoRs();
            }
        }

        // ABOUT US

        // VER DATATABLE
        private void verDatosAbout()
        {
            DataSet ds = new DataSet();
            HomePageBL homePageBL = new HomePageBL();

            ds = homePageBL.allAbout();

            if (ds.Tables.Count > 0)
            {
                txtId.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                txtTitulo.Text = ds.Tables[0].Rows[0]["Titulo"].ToString();
                txtDesc.Text = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                imgLogo.ImageUrl = ds.Tables[0].Rows[0]["Logo"].ToString();
                imgBg.ImageUrl = ds.Tables[0].Rows[0]["ImagenFondo"].ToString();
            }

        }
        // END DATATABLE

        protected void btnModificarAbout_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (fileLogo.HasFile && fileBg.HasFile)
                {
                    modificarAbout();
                }
                else if (fileLogo.HasFile)
                {
                    modificarAboutLogo();
                }
                else if (fileBg.HasFile)
                {
                    modificarAboutBg();
                }
                else
                {
                    modificarAboutSinImg();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('Debes seleccionar un Id')", true);
            }

        }

        private void modificarAbout()
        {
            AboutBE aboutBE = new AboutBE();
            HomePageBL homePageBL = new HomePageBL();
            try
            {
                aboutBE.IdAbout = Convert.ToInt32(txtId.Text);
                aboutBE.Titulo = txtTitulo.Text;
                aboutBE.Descripcion = txtDesc.Text;

                aboutBE.Logo = subirImagen();

                aboutBE.ImagenFondo = subirImagenBg();


                homePageBL.updateAbout(aboutBE);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
            }
            finally
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('Se modifico con exito')", true);
                limpiarCamposAbout();
            }
        }
        private void modificarAboutLogo()
        {
            AboutBE aboutBE = new AboutBE();
            HomePageBL homePageBL = new HomePageBL();
            try
            {
                aboutBE.IdAbout = Convert.ToInt32(txtId.Text);
                aboutBE.Titulo = txtTitulo.Text;
                aboutBE.Descripcion = txtDesc.Text;
                aboutBE.Logo = subirImagen();
                homePageBL.updateAboutUsLogo(aboutBE);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
            }
            finally
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('Se modifico con exito')", true);
                limpiarCamposAbout();
            }
        }
        private void modificarAboutBg()
        {
            AboutBE aboutBE = new AboutBE();
            HomePageBL homePageBL = new HomePageBL();
            try
            {
                aboutBE.IdAbout = Convert.ToInt32(txtId.Text);
                aboutBE.Titulo = txtTitulo.Text;
                aboutBE.Descripcion = txtDesc.Text;
                aboutBE.ImagenFondo = subirImagenBg();

                homePageBL.updateAboutUsImgBg(aboutBE);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
            }
            finally
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('Se modifico con exito')", true);
                limpiarCamposAbout();
            }
        }
        private void modificarAboutSinImg()
        {
            AboutBE aboutBE = new AboutBE();
            HomePageBL homePageBL = new HomePageBL();
            try
            {
                aboutBE.IdAbout = Convert.ToInt32(txtId.Text);
                aboutBE.Titulo = txtTitulo.Text;
                aboutBE.Descripcion = txtDesc.Text;


                homePageBL.updateAboutUsSinImg(aboutBE);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
            }
            finally
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('Se modifico con exito')", true);
                limpiarCamposAbout();
            }
        }

        private string subirImagen()
        {
            var ruta = "";

            if (fileLogo.HasFile)
            {
                string extensionArchivo = System.IO.Path.GetExtension(fileLogo.FileName).ToLower();
                string[] extensionPermitida = { ".jpg", ".jpeg", ".png", ".gif" };

                bool fileOk = false;

                for (int i = 0; i < extensionPermitida.Length; i++)
                {
                    if (extensionArchivo == extensionPermitida[i])
                    {
                        fileOk = true;
                    }
                }


                if (fileOk)
                {
                    string nombreImg = fileLogo.FileName;
                    ruta = "../images/" + nombreImg;
                    fileLogo.SaveAs(Server.MapPath(ruta));
                    return ruta;
                }
            }

            return ruta;
        }
        private string subirImagenBg()
        {
            var ruta = "";

            if (fileBg.HasFile)
            {
                string extensionArchivo = System.IO.Path.GetExtension(fileBg.FileName).ToLower();
                string[] extensionPermitida = { ".jpg", ".jpeg", ".png", ".gif" };

                bool fileOk = false;

                for (int i = 0; i < extensionPermitida.Length; i++)
                {
                    if (extensionArchivo == extensionPermitida[i])
                    {
                        fileOk = true;
                    }
                }


                if (fileOk)
                {
                    string nombreImg = fileBg.FileName;
                    ruta = "../images/" + nombreImg;
                    fileBg.SaveAs(Server.MapPath(ruta));
                    return ruta;
                }
            }

            return ruta;
        }
        private void limpiarCamposAbout()
        {
            txtId.Text = "";
            txtTitulo.Text = "";
            txtDesc.Text = "";
            fileLogo.DataBind();
            fileBg.DataBind();
            imgLogo.ImageUrl = "";
            imgBg.ImageUrl = "";
            verDatosAbout();
            Response.Redirect("frmHomePage.aspx");
        }

        //END ABOUT US

        // CONTACTO
        private void verDatosContacto()
        {
            DataSet ds = new DataSet();
            HomePageBL homePageBL = new HomePageBL();

            ds = homePageBL.allContactos();

            if (ds.Tables.Count > 0)
            {
                rpContacto.DataSource = ds.Tables[0];
                rpContacto.DataBind();
            }
        }
        private void iconoContacto()
        {
            HomePageBL homePageBL = new HomePageBL();
            DataSet ds = new DataSet();

            ds = homePageBL.allIcons();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlIconoContacto.DataSource = ds.Tables[0];
                ddlIconoContacto.DataTextField = "Nombre";
                ddlIconoContacto.DataValueField = "IdIcono";
                ddlIconoContacto.DataBind();
            }
        }

        [WebMethod]
        public static bool AgregarContacto(string nombre, string icono)
        {
            HomePageBL homePageBL = new HomePageBL();
            bool ok = false;

            if (nombre == "" && icono == "")
            {
                ok = false;
            }
            else
            {
                ContactoBE objContacto = new ContactoBE
                {
                    Nombre = nombre,
                    IdIcono = Convert.ToInt32(icono)
                };

                bool resp = homePageBL.addContacto(objContacto);

                ok = true;
            }

            return ok;
        }

        [WebMethod]
        public static bool ActualizarContacto(string id, string nombre, string icono)
        {
            HomePageBL homePageBL = new HomePageBL();
            bool ok = false;

            if (id == "")
            {
                ok = false;
            }
            else
            {

                ContactoBE objContacto = new ContactoBE
                {
                    IdContacto = Convert.ToInt32(id),
                    Nombre = nombre,
                    IdIcono = Convert.ToInt32(icono)
                };

                bool resp = homePageBL.updateContacto(objContacto);

                ok = true;
            }

            return ok;
        }

        [WebMethod]
        public static bool DeleteContacto(string id)
        {
            HomePageBL homePageBL = new HomePageBL();


            bool resp = homePageBL.deleteContacto(Convert.ToInt32(id));
            return true;
        }

        // END CONTACTO

        // REDES SOCIALES
        [WebMethod]
        public static bool AgregarRedSocial(string nombre, string url, string icono, bool status)
        {
            HomePageBL homePageBL = new HomePageBL();
            bool ok = false;

            if(nombre == "" && url == "")
            {
                ok = false;
            }
            else
            {
                RedSocialBE objRS = new RedSocialBE
                {
                    Nombre = nombre,
                    Url = url,
                    IdIcono = Convert.ToInt32(icono),
                    Activo = status
                };

                ok = homePageBL.addRS(objRS);
            }

            return ok;

        }

        [WebMethod]
        public static bool ModificarRedSocial(string id, string nombre, string url, string icono, bool status)
        {
            HomePageBL homePageBL = new HomePageBL();
            bool ok = false;

            if (id == "")
            {
                ok = false;
            }
            else
            {
                RedSocialBE objRS = new RedSocialBE
                {
                    IdRedSocial = Convert.ToInt32(id),
                    Nombre = nombre,
                    Url = url,
                    IdIcono = Convert.ToInt32(icono),
                    Activo = status
                };

                ok = homePageBL.updateRS(objRS);
            }

            return ok;

        }

        [WebMethod]
        public static bool EliminarRedSocial(string id)
        {

            HomePageBL homePageBL = new HomePageBL();
            bool ok = false;

            if (id == "")
            {
                ok = false;
            }
            else
            {
                ok = homePageBL.deleteRS(Convert.ToInt32(id));
            }

            return ok;

        }

        private void verDatosRS()
        {
            DataSet ds = new DataSet();
            HomePageBL homePageBL = new HomePageBL();

            ds = homePageBL.allRS();

            if (ds.Tables.Count > 0)
            {
                rpRS.DataSource = ds.Tables[0];
                rpRS.DataBind();
            }
        }
        private void iconoContactoRs()
        {
            HomePageBL homePageBL = new HomePageBL();
            DataSet ds = new DataSet();

            ds = homePageBL.allIcons();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlIcon.DataSource = ds.Tables[0];
                ddlIcon.DataTextField = "Nombre";
                ddlIcon.DataValueField = "IdIcono";
                ddlIcon.DataBind();
            }
        }

        // END REDES SOCIALES
    }
}