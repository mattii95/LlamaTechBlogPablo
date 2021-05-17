using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace LlamaTech.web_admin
{
    public partial class frmUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                verDatos();
                cargarRol();
                if (Session["Nombre"] != null)
                {
                    lblUser.Text = Session["Nombre"].ToString();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }


        private void verDatos()
        {
            DataSet ds = new DataSet();
            UsuarioBL usuarioBL = new UsuarioBL();

            ds = usuarioBL.allUsers();

            if (ds.Tables.Count > 0)
            {
                rpGrid.DataSource = ds.Tables[0];
                rpGrid.DataBind();
            }

        }

        [WebMethod]
        public static bool ModificarUsuarioSinImagen(string id, string nombre, string apellido, string telefono, string email, string rol, string status)
        {

            UsuarioBL usuarioBL = new UsuarioBL();

            UsuarioBE objUsuario = new UsuarioBE()
            {
                IdUsuario = Convert.ToInt32(id),
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Email = email,
                IdRol = Convert.ToInt32(rol),
                Status = Convert.ToBoolean(status)
            };

            return usuarioBL.modificarUserSinFoto(objUsuario);
        }

        [WebMethod]
        public static bool UpdatePassword(string id, string pass)
        {
            UsuarioBL usuarioBL = new UsuarioBL();

            UsuarioBE objUsuario = new UsuarioBE()
            {
                IdUsuario = Convert.ToInt32(id),
                Contraseña = pass,
            };

            return usuarioBL.modificarUserPass(objUsuario);
        }

        [WebMethod]
        public static bool Eliminar(string id)
        {
            UsuarioBL usuarioBL = new UsuarioBL();

            return usuarioBL.eliminarUser(Convert.ToInt32(id));
        }


        [WebMethod]
        public static string GetEmail(string email)
        {
            try
            {
                List<UsuarioBE> lista = null;
                UsuarioBL usuarioBL = new UsuarioBL();
                UsuarioBE objUsuario = new UsuarioBE();

                lista = usuarioBL.getEmail(email);

                for (int i = 0; i < lista.Count; i++)
                {
                    objUsuario.Email = lista[i].Email.ToString();
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(lista);

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        // LLENAR DDL ROLES
        private void cargarRol()
        {
            DataSet ds = new DataSet();
            RolBL rolBL = new RolBL();

            ds = rolBL.rolActive();

            if (ds.Tables.Count > 0)
            {
                ddlRol.DataSource = ds.Tables[0];
                ddlRol.DataTextField = "Nombre";
                ddlRol.DataValueField = "IdRol";
                ddlRol.DataBind();
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            HttpCookie cookie = new HttpCookie("LoginSimple");
            Response.Cookies.Add(cookie);
            Response.Redirect("login.aspx");
        }
    }
}