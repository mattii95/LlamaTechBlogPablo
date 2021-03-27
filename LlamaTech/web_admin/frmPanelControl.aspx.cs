using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LlamaTech.web_admin
{
    public partial class frmPanelControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                PublicacionBL publicacionBL = new PublicacionBL();
                UsuarioBL usuarioBL = new UsuarioBL();

                ds = publicacionBL.countEntradas();

                if(ds.Tables[0].Rows.Count > 0)
                {
                    lblEntradas.Text = ds.Tables[0].Rows[0]["Entradas"].ToString();
                }

                ds = usuarioBL.countUsers();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUsers.Text = ds.Tables[0].Rows[0]["Usuarios"].ToString();
                }
            }
        }
    }
}