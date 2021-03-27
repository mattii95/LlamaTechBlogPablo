using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

namespace LlamaTech
{
    /// <summary>
    /// Descripción breve de UploadImages
    /// </summary>
    public class UploadImages : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hola a todos");
            ImagenBL imagenBL = new ImagenBL();
            DataSet ds = new DataSet();

            string path = "../images/server/";
            string archive = null;
            string alt = context.Request.QueryString["desc"];
            

            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                string fname;

                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    ds = imagenBL.getImagesPath("../images/server/" + file.FileName);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        
                        context.Response.End();
                    }
                    else
                    {

                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testFiles = file.FileName.Split(new char[] { '\\' });
                            fname = testFiles[testFiles.Length - 1];
                            archive = testFiles[testFiles.Length - 1];
                        }
                        else
                        {
                            archive = file.FileName;
                            fname = file.FileName;
                        }

                        fname = Path.Combine(context.Server.MapPath("~/images/server/"), fname);
                        file.SaveAs(fname);

                    }
                    
                }

                string fullPath = path + archive;

                ImagenBE objImg = new ImagenBE()
                {
                    Nombre = alt,
                    Ruta = fullPath
                };

                imagenBL.addImagen(objImg);
            }


            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "text/plain";
            context.Response.Write("File Uploaded Successfully!");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}