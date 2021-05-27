using LlamaTech.BE;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LlamaTech.DA
{
    public class HomePageDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();


        // ABOUT US
        public DataSet getAboutUs()
        {
            const string sqlQuery = "SELECT IdAbout as 'ID', Titulo, Descripcion, Logo, ImagenFondo FROM AboutUs ORDER BY IdAbout ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "AboutUs");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public DataSet getAboutUsId(int id)
        {
            const string sqlQuery = "SELECT IdAbout as 'ID', Titulo, Descripcion, Logo, ImagenFondo FROM AboutUs WHERE IdAbout = @IdAbout";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdAbout", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "AboutUs");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public void updateAboutUs(AboutBE aboutBE)
        {
            const string sqlQuery = @"
                UPDATE AboutUs
                SET Titulo = @Titulo, 
                    Descripcion = @Descripcion,
                    Logo = @Logo,
                    ImagenFondo = @ImagenFondo
                WHERE IdAbout = @IdAbout
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdAbout", aboutBE.IdAbout);
            cmd.Parameters.AddWithValue("@Titulo", aboutBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", aboutBE.Descripcion);
            cmd.Parameters.AddWithValue("@Logo", aboutBE.Logo);
            cmd.Parameters.AddWithValue("@ImagenFondo", aboutBE.ImagenFondo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }
        public void updateAboutUsLogo(AboutBE aboutBE)
        {
            const string sqlQuery = @"
                UPDATE AboutUs
                SET Titulo = @Titulo, 
                    Descripcion = @Descripcion,
                    Logo = @Logo
                WHERE IdAbout = @IdAbout
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdAbout", aboutBE.IdAbout);
            cmd.Parameters.AddWithValue("@Titulo", aboutBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", aboutBE.Descripcion);
            cmd.Parameters.AddWithValue("@Logo", aboutBE.Logo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }
        public void updateAboutUsImgBg(AboutBE aboutBE)
        {
            const string sqlQuery = @"
                UPDATE AboutUs
                SET Titulo = @Titulo, 
                    Descripcion = @Descripcion,
                    ImagenFondo = @ImagenFondo
                WHERE IdAbout = @IdAbout
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdAbout", aboutBE.IdAbout);
            cmd.Parameters.AddWithValue("@Titulo", aboutBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", aboutBE.Descripcion);
            cmd.Parameters.AddWithValue("@ImagenFondo", aboutBE.ImagenFondo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }
        public void updateAboutUsSinImg(AboutBE aboutBE)
        {
            const string sqlQuery = @"
                UPDATE AboutUs
                SET Titulo = @Titulo, 
                    Descripcion = @Descripcion
                WHERE IdAbout = @IdAbout
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdAbout", aboutBE.IdAbout);
            cmd.Parameters.AddWithValue("@Titulo", aboutBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", aboutBE.Descripcion);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }
        // END ABOUT US

        // CONTACTO
        public DataSet getContactos()
        {
            const string sqlQuery = "SELECT C.IdContacto, C.Nombre, I.Nombre as 'Icono' FROM Contactos C " +
                "INNER JOIN Iconos I on C.IdIcono = I.IdIcono ORDER BY IdContacto ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Contactos");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public DataSet getContactosRP()
        {
            const string sqlQuery = "SELECT C.IdContacto, C.Nombre, I.Icono as 'Icono' FROM Contactos C " +
                "INNER JOIN Iconos I on C.IdIcono = I.IdIcono ORDER BY IdContacto ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Contactos");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public bool addContacto(ContactoBE contactoBE)
        {
            bool res = false;

            const string sqlQuery = @"
                INSERT INTO Contactos (Nombre, IdIcono)
                VALUES (@Nombre, @IdIcono)
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", contactoBE.Nombre);
            cmd.Parameters.AddWithValue("@IdIcono", contactoBE.IdIcono);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

            return res;

        }
        public bool updateContacto(ContactoBE contactoBE)
        {
            bool res = false;

            const string sqlQuery = @"
                UPDATE Contactos
                SET Nombre = @Nombre, IdIcono = @IdIcono
                WHERE IdContacto = @IdContacto
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdContacto", contactoBE.IdContacto);
            cmd.Parameters.AddWithValue("@Nombre", contactoBE.Nombre);
            cmd.Parameters.AddWithValue("@IdIcono", contactoBE.IdIcono);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

            return res;
        }
        public bool deleteContacto(int id)
        {
            bool res = false;

            const string sqlQuery = @"
                DELETE FROM Contactos
                WHERE IdContacto = @IdContacto
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdContacto", id);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

            return res;
        }
        //END CONTACTO

        //RED SOCIAL
        public DataSet getRS()
        {
            const string sqlQuery = "SELECT RS.IdRedSocial, RS.Nombre, RS.Url, I.Nombre as 'Icono', Activo FROM RedesSociales RS " +
                "INNER JOIN Iconos I on RS.IdIcono = I.IdIcono ORDER BY IdRedSocial ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "RedesSociales");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public DataSet getRSActivo()
        {
            const string sqlQuery = "SELECT RS.IdRedSocial, RS.Nombre as 'Titulo', RS.Url, I.Icono as 'Icono', Activo FROM RedesSociales RS " +
                "INNER JOIN Iconos I on RS.IdIcono = I.IdIcono WHERE Activo = 1 ORDER BY IdRedSocial ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "RedesSociales");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public bool addRS(RedSocialBE redSocialBE)
        {
            bool res = false;

            const string sqlQuery = @"
                INSERT INTO RedesSociales (Nombre, Url, IdIcono, Activo)
                VALUES (@Nombre, @Url, @IdIcono, @Activo)
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", redSocialBE.Nombre);
            cmd.Parameters.AddWithValue("@Url", redSocialBE.Url);
            cmd.Parameters.AddWithValue("@IdIcono", redSocialBE.IdIcono);
            cmd.Parameters.AddWithValue("@Activo", redSocialBE.Activo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                res = false;
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

            return res;

        }
        public bool updateRS(RedSocialBE redSocialBE)
        {
            bool res = false;

            const string sqlQuery = @"
                UPDATE RedesSociales
                SET Nombre = @Nombre, Url = @Url, IdIcono = @IdIcono, Activo = @Activo
                WHERE IdRedSocial = @IdRedSocial
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdRedSocial", redSocialBE.IdRedSocial);
            cmd.Parameters.AddWithValue("@Nombre", redSocialBE.Nombre);
            cmd.Parameters.AddWithValue("@Url", redSocialBE.Url);
            cmd.Parameters.AddWithValue("@IdIcono", redSocialBE.IdIcono);
            cmd.Parameters.AddWithValue("@Activo", redSocialBE.Activo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                res = false;
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

            return res;

        }
        public bool deleteRS(int id)
        {

            bool res = false;

            const string sqlQuery = @"
                DELETE FROM RedesSociales
                WHERE IdRedSocial = @IdRedSocial
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdRedSocial", id);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                res = false;
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

            return res;

        }
        //END RED SOCIAL

        //ICONOS
        public DataSet getIcono()
        {
            const string sqlQuery = "select IdIcono, Nombre, Icono from Iconos order by IdIcono asc";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Iconos");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public void updateIcono(AboutBE aboutBE)
        {
            const string sqlQuery = @"
                UPDATE AboutUs
                SET Titulo = @Titulo, 
                    Descripcion = @Descripcion,
                    Logo = @Logo,
                    ImagenFondo = @ImagenFondo
                WHERE IdAbout = @IdAbout
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdAbout", aboutBE.IdAbout);
            cmd.Parameters.AddWithValue("@Titulo", aboutBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", aboutBE.Descripcion);
            cmd.Parameters.AddWithValue("@Logo", aboutBE.Logo);
            cmd.Parameters.AddWithValue("@ImagenFondo", aboutBE.ImagenFondo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }
        //END ICONOS

    }
}
