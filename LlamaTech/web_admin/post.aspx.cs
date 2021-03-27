using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using LlamaTech.BE;
using LlamaTech.BL;

namespace LlamaTech.web_admin
{
    public partial class post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                verPublicaciones();
                verEstados();
                verImagenes();
            }
        }

        private void verPublicaciones()
        {
            DataSet ds = new DataSet();
            PublicacionBL publicacionBL = new PublicacionBL();

            ds = publicacionBL.verDataGrilla();

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpPublicacion.DataSource = ds.Tables[0];
                rpPublicacion.DataBind();
            }
        }

        private void verEstados()
        {
            DataSet ds = new DataSet();
            EstadoBL estadoBL = new EstadoBL();

            ds = estadoBL.allEstados();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlEstado.DataSource = ds.Tables[0];
                ddlEstado.DataTextField = "Estado";
                ddlEstado.DataValueField = "idEstado";
                ddlEstado.DataBind();
            }
        }

        private void verImagenes()
        {
            DataSet ds = new DataSet();
            ImagenBL imagenBL = new ImagenBL();

            ds = imagenBL.allImages();

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpImgServer.DataSource = ds.Tables[0];
                rpImgServer.DataBind();
            }

        }

        [WebMethod]
        public static bool ActualizarEntradas(string id, string titulo, string descripcion,
            string imagen, string contenido, string status, string slug, string subcategoria, string categoria)
        {
            PublicacionBL publicacionBL = new PublicacionBL();

            DateTime hoy = DateTime.Now;
            DateTime? fechaPublicacion = null;

            // BUSCAR Y MODIFICAR FECHA DE PUBLICACION
            DataSet ds = new DataSet();
            ds = publicacionBL.getFechaPublicacion(Convert.ToInt32(id));


            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];

                // COMPARAR EL ESTADO SELECCIONADO CON EL ESTADO GUARDADO EN LA DB
                if (Convert.ToInt32(row["IdEstado"].ToString()) == 1 && Convert.ToInt32(status) == 1)
                {
                    if (row["Publicado"] != DBNull.Value)
                    {
                        fechaPublicacion = DateTime.Parse(row["Publicado"].ToString());
                    }
                    else
                    {
                        fechaPublicacion = DateTime.Parse(hoy.ToString("dd/MM/yyyy HH:mm"));
                    }
                }
                else if (Convert.ToInt32(row["IdEstado"].ToString()) == 2 && Convert.ToInt32(status) == 2)
                {
                    if (row["Publicado"] != DBNull.Value)
                    {
                        fechaPublicacion = DateTime.Parse(row["Publicado"].ToString());
                    }
                    else
                    {
                        fechaPublicacion = null;
                    }
                }
                else if (Convert.ToInt32(row["IdEstado"].ToString()) == 2 && Convert.ToInt32(status) == 1)
                {
                    fechaPublicacion = DateTime.Parse(hoy.ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {
                    fechaPublicacion = DateTime.Parse(row["Publicado"].ToString());
                }

            }



            PublicacionBE publicacionBE = new PublicacionBE()
            {
                IdPublicacion = Convert.ToInt32(id),
                Titulo = titulo,
                Descripcion = descripcion,
                Imagen = imagen,
                Contenido = contenido,
                FechaPublicacion = fechaPublicacion,
                idEstado = Convert.ToInt32(status),
                Slug = slug,
                SubCategoria = subcategoria
            };

            PublicacionCategoriaBE publicacionCategoriaBE = new PublicacionCategoriaBE()
            {
                IdPublicacion = Convert.ToInt32(id),
                IdCategoria = Convert.ToInt32(categoria)
            };

            bool resp = publicacionBL.editarPost(publicacionBE, publicacionCategoriaBE);

            return true;
        }

        [WebMethod]
        public static bool AgregarEntradas(string titulo, string descripcion,
            string imagen, string contenido, string status, string slug, string subcategoria, string categoria)
        {
            PublicacionBL publicacionBL = new PublicacionBL();

            DateTime hoy = DateTime.Now;
            DateTime? fechaPublicacion = null;

            if (Convert.ToInt32(status) == 1)
                fechaPublicacion = DateTime.Parse(hoy.ToString("dd/MM/yyyy HH:mm"));
            else
                fechaPublicacion = null;

            PublicacionBE publicacionBE = new PublicacionBE()
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Imagen = imagen,
                Contenido = contenido,
                FechaPublicacion = fechaPublicacion,
                idEstado = Convert.ToInt32(status),
                Slug = slug,
                SubCategoria = subcategoria
            };

            PublicacionCategoriaBE publicacionCategoriaBE = new PublicacionCategoriaBE()
            {
                IdCategoria = Convert.ToInt32(categoria)
            };

            bool resp = publicacionBL.addPost(publicacionBE, publicacionCategoriaBE);

            return true;
        }

        [WebMethod]
        public static bool EliminarEntrada(string id)
        {

            bool ok = false;

            PublicacionBL publicacionBL = new PublicacionBL();
            DataSet ds = new DataSet();

            ds = publicacionBL.getPostId(Convert.ToInt32(id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                ok = publicacionBL.deletePost(Convert.ToInt32(id));
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        [WebMethod]
        public static string ListarCategorias()
        {


            try
            {

                List<CategoriaBE> lista = null;
                CategoriaBL categoriaBL = new CategoriaBL();
                CategoriaBE objCategoria = new CategoriaBE();

                lista = categoriaBL.getCategoriasAjax();

                for (int i = 0; i < lista.Count; i++)
                {
                    objCategoria.IdCategoria = Convert.ToInt32(lista[i].IdCategoria.ToString()); 
                    objCategoria.Nombre = lista[i].Nombre.ToString();
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(lista);

            }
            catch (Exception)
            {

                throw;
            }

        }

        [WebMethod]
        public static string ListarSubCategorias(string id)
        {
            //JavaScriptSerializer deserializer = new JavaScriptSerializer();

            //var dict = deserializer.Deserialize<SubCategoriaBE>(id);
            //string idCategoria = Convert.ToString(dict.IdCategoria);

            
            try
            {
                List<SubCategoriaBE> lista = null;
                SubCategoriaBL subCategoriaBL = new SubCategoriaBL();
                SubCategoriaBE subCategoriaBE = new SubCategoriaBE();

                lista = subCategoriaBL.subCategoriaAjax(Convert.ToInt32(id));

                for (int i = 0; i < lista.Count; i++)
                {
                    subCategoriaBE.IdSubCategoria = Convert.ToInt32(lista[i].IdSubCategoria.ToString());
                    subCategoriaBE.Nombre = lista[i].Nombre.ToString();
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(lista);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        [WebMethod]
        public static string BuscarImagen(string ruta)
        {
            //JavaScriptSerializer deserializer = new JavaScriptSerializer();

            //var dict = deserializer.Deserialize<SubCategoriaBE>(id);
            //string idCategoria = Convert.ToString(dict.IdCategoria);


            try
            {
                List<ImagenBE> lista = null;
                ImagenBL imagenBL = new ImagenBL();
                ImagenBE imagenBE = new ImagenBE();

                lista = imagenBL.getImages(ruta);

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