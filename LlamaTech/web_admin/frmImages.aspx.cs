using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace LlamaTech.web_admin
{
    public partial class frmImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mostrarDatos();
            }
        }

        // MOSTRAR DATOS EN GRILLA
        private void mostrarDatos()
        {
            ImagenBL imagenDA = new ImagenBL();
            DataSet ds = new DataSet();

            ds = imagenDA.allImages();

            if (ds.Tables.Count > 0)
            {
                rpGrid.DataSource = ds.Tables[0];
                rpGrid.DataBind();
            }

        }


        // BUSCAR IMAGENES NOMBRE
        [WebMethod]
        public static string GetNombreImages(string nombre)
        {
            try
            {
                List<ImagenBE> lista = null;
                ImagenBL imagenBL = new ImagenBL();
                ImagenBE imagenBE = new ImagenBE();
                string path = "../images/server/" + nombre;
                lista = imagenBL.getImagesPathAjx(path);

                for (int i = 0; i < lista.Count; i++)
                {
                    imagenBE.IdImagen = Convert.ToInt32(lista[i].IdImagen.ToString());
                    imagenBE.Ruta = lista[i].Ruta.ToString();
                    imagenBE.Nombre = lista[i].Nombre.ToString();
                    imagenBE.IdUsuario = 1;
                }



                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(lista);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}