using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace LlamaTech
{
    /// <summary>
    /// Descripción breve de UpdateAvatarUser
    /// </summary>
    public class UpdateAvatarUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hola a todos");

            UsuarioBL usuarioBL = new UsuarioBL();

            string path = "../images/users/";
            string archive = null;
            string idUsuario = context.Request.QueryString["id"];
            string nombre = context.Request.QueryString["name"];
            string apellido = context.Request.QueryString["surname"];
            string telefono = context.Request.QueryString["phone"];
            string correo = context.Request.QueryString["email"];
            string rol = context.Request.QueryString["rol"];
            string estado = context.Request.QueryString["status"];

            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                string fName;

                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile postedFile = files[i];

                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testFiles = postedFile.FileName.Split(new char[] { '\\' });
                        fName = generarCodigo() + testFiles[testFiles.Length - 1];
                        archive = generarCodigo() + testFiles[testFiles.Length - 1];
                    }
                    else
                    {
                        archive = generarCodigo() + postedFile.FileName;
                        fName = generarCodigo() + postedFile.FileName;
                    }

                    fName = Path.Combine(context.Server.MapPath("~/images/users/"), fName);
                    postedFile.SaveAs(fName);
                }


                string fullPath = path + archive;

                UsuarioBE objUsuario = new UsuarioBE()
                {
                    IdUsuario = Convert.ToInt32(idUsuario),
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Email = correo,
                    FotoPerfil = fullPath,
                    IdRol = Convert.ToInt32(rol),
                    Status = Convert.ToBoolean(estado)
                };

                usuarioBL.modificarUser(objUsuario);

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

        private string generarCodigo()
        {
            string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random r = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < 20; i++)
            {
                int count = r.Next(0, s.Length - 1);
                sb.Append(s.Substring(count, 1));
            }

            return sb.ToString();
        }
    }
}