using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                rpAbout.DataSource = ds.Tables[0];
                rpAbout.DataBind();
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
        private void limpiarCamposContacto()
        {
            txtIdContacto.Text = "";
            txtDescContacto.Text = "";
            iconoContacto();
            verDatosContacto();
        }

        protected void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            if(txtDescContacto.Text != "")
            {
                HomePageBL homePageBL = new HomePageBL();
                ContactoBE contactoBE = new ContactoBE();
                try
                {
                    contactoBE.Nombre = txtDescContacto.Text;
                    contactoBE.IdIcono = Convert.ToInt32(ddlIconoContacto.SelectedItem.Value);

                    homePageBL.addContacto(contactoBE);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
                }
                finally
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertAddSuccess('El contacto se agrego con exito')", true);
                    limpiarCamposContacto();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('Todos los campos son obligatorios')", true);
            }
        }

        protected void btnModificarContacto_Click(object sender, EventArgs e)
        {
            if (txtIdContacto.Text != "")
            {
                HomePageBL homePageBL = new HomePageBL();
                ContactoBE contactoBE = new ContactoBE();
                try
                {
                    contactoBE.IdContacto = Convert.ToInt32(txtIdContacto.Text);
                    contactoBE.Nombre = txtDescContacto.Text;
                    contactoBE.IdIcono = Convert.ToInt32(ddlIconoContacto.SelectedItem.Value);

                    homePageBL.updateContacto(contactoBE);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
                }
                finally
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('El contacto se modifico con exito')", true);
                    limpiarCamposContacto();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('El campo ID es obligatorio')", true);
            }
        }

        protected void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            if (txtIdContacto.Text != "")
            {
                HomePageBL homePageBL = new HomePageBL();
                ContactoBE contactoBE = new ContactoBE();
                try
                {
                    contactoBE.IdContacto = Convert.ToInt32(txtIdContacto.Text);

                    homePageBL.deleteContacto(contactoBE.IdContacto);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
                }
                finally
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('El contacto se elimino con exito')", true);
                    limpiarCamposContacto();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('El campo ID es obligatorio')", true);
            }
        }

        // END CONTACTO

        // REDES SOCIALES

        private void limpiarCampoRS()
        {
            txtIdrs.Text = "";
            txtRS.Text = "";
            txtURL.Text = "";
            iconoContactoRs();
            verDatosRS();
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

        protected void btnAgregarRS_Click(object sender, EventArgs e)
        {
            if (txtRS.Text != "")
            {
                HomePageBL homePageBL = new HomePageBL();
                RedSocialBE redSocialBE = new RedSocialBE();
                try
                {
                    redSocialBE.Nombre = txtRS.Text;
                    redSocialBE.Url = txtURL.Text;
                    redSocialBE.IdIcono = Convert.ToInt32(ddlIcon.SelectedValue);
                    redSocialBE.Activo = chkStatus.Checked;

                    homePageBL.addRS(redSocialBE);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
                }
                finally
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertAddSuccess('La Red Social se agrego con exito')", true);
                    limpiarCampoRS();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('Todos los campos son obligatorios')", true);
            }
        }

        protected void btnModificarRS_Click(object sender, EventArgs e)
        {
            if (txtIdrs.Text != "")
            {
                HomePageBL homePageBL = new HomePageBL();
                RedSocialBE redSocialBE = new RedSocialBE();
                try
                {
                    redSocialBE.IdRedSocial = Convert.ToInt32(txtIdrs.Text);
                    redSocialBE.Nombre = txtRS.Text;
                    redSocialBE.Url = txtURL.Text;
                    redSocialBE.IdIcono = Convert.ToInt32(ddlIcon.SelectedValue);
                    redSocialBE.Activo = chkStatus.Checked;

                    homePageBL.updateRS(redSocialBE);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
                }
                finally
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('La Red Social se modifico con exito')", true);
                    limpiarCampoRS();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('Todos los campos son obligatorios')", true);
            }
        }

        protected void btnEliminarRS_Click(object sender, EventArgs e)
        {
            if (txtIdrs.Text != "")
            {
                HomePageBL homePageBL = new HomePageBL();
                RedSocialBE redSocialBE = new RedSocialBE();
                try
                {
                    redSocialBE.IdRedSocial = Convert.ToInt32(txtIdrs.Text);

                    homePageBL.deleteRS(redSocialBE.IdRedSocial);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('" + ex.Message + "')", true);
                }
                finally
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertUpdateSuccess('La Red Social se elimino con exito')", true);
                    limpiarCampoRS();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertError('Todos los campos son obligatorios')", true);
            }
        }


        // END REDES SOCIALES
    }
}