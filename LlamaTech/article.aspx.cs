using LlamaTech.BL;
using Microsoft.Build.BuildEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LlamaTech
{
    public partial class article1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string request = Page.RouteData.Values["id"].ToString();
                string slug = Page.RouteData.Values["slug"] as string;
                getPost(Convert.ToInt32(request));

                

            }
        }

        public static string BaseSiteUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;
                string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
                return baseUrl;
            }
        }

        // Obtener datos del post
        public void getPost(int id)
        {
            DataSet ods = new DataSet();
            PublicacionBL publicacionBL = new PublicacionBL();
            HtmlMeta tagTitle = new HtmlMeta();
            HtmlMeta tagUrl = new HtmlMeta();
            HtmlMeta tagImg = new HtmlMeta();

            ods = publicacionBL.getPostId(id);

            if (ods.Tables.Count > 0)
            {
                hTitle.InnerText = ods.Tables[0].Rows[0]["Titulo"].ToString();
                divDate.InnerText = ods.Tables[0].Rows[0]["Publicado"].ToString();
                hCategory.InnerText = ods.Tables[0].Rows[0]["Nombre"].ToString();
                pDesc.InnerText = ods.Tables[0].Rows[0]["Descripcion"].ToString();
                //imgPortada.Src = ods.Tables[0].Rows[0]["Imagen"].ToString();
                pContent.InnerHtml = ods.Tables[0].Rows[0]["Contenido"].ToString();
                imgUser.Src = ods.Tables[0].Rows[0]["FotoPerfil"].ToString();
                user.InnerText = ods.Tables[0].Rows[0]["Usuario"].ToString();

                string slug = ods.Tables[0].Rows[0]["Slug"].ToString();
                string titulo = ods.Tables[0].Rows[0]["Titulo"].ToString();

                string tituloTwitter = titulo.Replace(" ", "%");
                string tituloWsp = titulo.Replace(" ", "%20");

                string dirUrl = BaseSiteUrl;
                string dirFullPath = dirUrl + "article/" + id + "/" + slug;

                Page.Title = string.Format(titulo);

                tagTitle.Attributes.Add("property", "og:title");
                tagTitle.Content = ods.Tables[0].Rows[0]["Titulo"].ToString();
                Page.Header.Controls.Add(tagTitle);

                tagUrl.Attributes.Add("property", "og:url");
                tagUrl.Content = dirFullPath;
                Page.Header.Controls.Add(tagUrl);

                tagImg.Attributes.Add("property", "og:image");
                tagImg.Content = ods.Tables[0].Rows[0]["Imagen"].ToString();
                Page.Header.Controls.Add(tagImg);

                hlFace.NavigateUrl = $"https://www.facebook.com/sharer/sharer.php?u={dirFullPath}";
                hlTwitter.NavigateUrl = $"https://twitter.com/intent/tweet?text={tituloTwitter}&url={dirFullPath}";
                hlLinkedin.NavigateUrl = $"https://www.linkedin.com/sharing/share-offsite/?url={dirFullPath}";
                hlWhatsapp.NavigateUrl = $"https://api.whatsapp.com/send?text={tituloWsp}%20{dirFullPath}";

            }
        }
    }
}