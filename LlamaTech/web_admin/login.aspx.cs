using LlamaTech.BL;
using LlamaTech.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LlamaTech.web_admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            UsuarioBL usuarioBL = new UsuarioBL();
            Security security = new Security();

            string hash = security.generarHash(txtPass.Text);

            ds = usuarioBL.login(txtEmail.Text, hash);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                hash = ds.Tables[0].Rows[0]["Contraseña"].ToString();

                Session["Nombre"] = ds.Tables[0].Rows[0]["Nombre"].ToString(); ;

                RolBL rolBL = new RolBL();
                int rol = 0;

                rol = Convert.ToInt32(ds.Tables[0].Rows[0]["Rol"].ToString());

                ds = rolBL.rolActiveId(rol);

                DateTime TimeOutLogin = DateTime.Now.AddMinutes(Session.Timeout);

                FormsAuthenticationTicket autTicket = new FormsAuthenticationTicket(1, txtEmail.Text, DateTime.Now, TimeOutLogin, false, rol.ToString());

                string encrTicket = FormsAuthentication.Encrypt(autTicket);

                HttpCookie autCookie = new HttpCookie("LoginSimple", encrTicket);

                Response.Cookies.Add(autCookie);

                Response.Redirect("frmPanelControl.aspx");

                lblError.Visible = false;

            } else
            {
                lblError.Visible = true;
                lblError.Text = "Email o Contraseña incorrectos";
            }

        }
    }
}