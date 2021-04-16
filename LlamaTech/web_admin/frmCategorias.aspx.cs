using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LlamaTech.web_admin
{
    public partial class frmCategorias : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                verDatos();
                verDatosSC();
                verCategorias();
            }
        }

        // Ver datos en la tabla
        private void verDatos()
        {
            CategoriaBL categoriaBL = new CategoriaBL();
            DataSet ds = new DataSet();
            ds = categoriaBL.categoriaActiva();

            if (ds.Tables.Count > 0)
            {
                rpGrid.DataSource = ds.Tables[0];
                rpGrid.DataBind();
            }

        }

        private void verDatosSC()
        {
            SubCategoriaBL subCategoriaBL = new SubCategoriaBL();
            DataSet ds = new DataSet();
            ds = subCategoriaBL.allSubCategorys();

            if (ds.Tables.Count > 0)
            {
                rpSubCategoria.DataSource = ds.Tables[0];
                rpSubCategoria.DataBind();
            }

        }

        private void verCategorias()
        {
            DataSet ds = new DataSet();
            CategoriaBL categoriaBL = new CategoriaBL();

            ds = categoriaBL.categoriaActiva();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCategoria.Enabled = true;
                ddlCategoria.DataSource = ds.Tables[0];
                ddlCategoria.DataTextField = "Categoria";
                ddlCategoria.DataValueField = "ID";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("Seleccione la Categoria", "0"));
            }
            else
            {
                ddlCategoria.Enabled = false;
                ddlCategoria.Items.Insert(0, new ListItem("No exiten datos", "0"));
            }
        }

        [WebMethod]
        public static bool AgregarCategoria(string nombre)
        {
            bool ok = false;
            CategoriaBL categoriaBL = new CategoriaBL();
            DataSet ds = new DataSet();

            try
            {

                ds = categoriaBL.buscarCategoriaNombre(nombre);
                // Valida que no extista otra categoria del mismo nombre
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ok = false;
                }
                else
                {
                    CategoriaBE objCategoria = new CategoriaBE()
                    {
                        Nombre = nombre
                    };
                    bool rep = categoriaBL.agregarCategoria(objCategoria);
                    ok = true;
                }

            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        [WebMethod]
        public static bool ModificarCategoria(string id, string nombre)
        {
            bool ok = false;
            CategoriaBL categoriaBL = new CategoriaBL();
            DataSet ds = new DataSet();

            try
            {

                CategoriaBE objCategoria = new CategoriaBE()
                {
                    IdCategoria = Convert.ToInt32(id),
                    Nombre = nombre
                };

                bool obj = categoriaBL.modificarCategoria(objCategoria);

                ok = true;

            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        [WebMethod]
        public static bool EliminarCategoria(string id)
        {

            bool ok = false;

            CategoriaBL categoriaBL = new CategoriaBL();
            DataSet ds = new DataSet();

            ds = categoriaBL.BuscarPorId(Convert.ToInt32(id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds = categoriaBL.BuscarCategoriaUsadas(Convert.ToInt32(id));

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Post"].ToString()) > 0)
                {
                    ok = false;
                }
                else
                {
                    ok = categoriaBL.eliminarCategoria(Convert.ToInt32(id));
                }

            }
            else
            {
                ok = false;
            }

            return ok;
        }

        [WebMethod]
        public static bool AgregarSubCategoria(string nombre, string categoria)
        {
            bool ok = false;
            SubCategoriaBL subCategoriaBL = new SubCategoriaBL();
            DataSet ds = new DataSet();

            try
            {

                SubCategoriaBE objSC = new SubCategoriaBE() {
                    Nombre = nombre,
                    IdCategoria = Convert.ToInt32(categoria)
                };

                bool resp = subCategoriaBL.agregarCategoria(objSC);

                ok = true;

            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        [WebMethod]
        public static bool ModificarSubCategoria(string id, string nombre, string categoria)
        {
            bool ok = false;
            SubCategoriaBL subCategoriaBL = new SubCategoriaBL();
            DataSet ds = new DataSet();

            try
            {

                SubCategoriaBE objSC = new SubCategoriaBE()
                {
                    IdSubCategoria = Convert.ToInt32(id),
                    Nombre = nombre,
                    IdCategoria = Convert.ToInt32(categoria)
                };

                bool resp = subCategoriaBL.modificarCategoria(objSC);

                ok = true;

            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        [WebMethod]
        public static bool EliminarSubCategoria(string id)
        {

            bool ok = false;

            SubCategoriaBL subCategoriaBL = new SubCategoriaBL();
            DataSet ds = new DataSet();

            ds = subCategoriaBL.subCategoriaId(Convert.ToInt32(id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                ok = subCategoriaBL.eliminarCategoria(Convert.ToInt32(id));
            }
            else
            {
                ok = false;
            }

            return ok;
        }


    }
}