using LlamaTech.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.DA
{
    public class ImagenDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        //  BUSCAR TODOS LOS POSTS
        public DataSet getImages()
        {

            const string sqlQuery = "SELECT IdImagen as 'ID', Ruta, Nombre as 'ALT', IdUsuario FROM Imagenes ORDER BY IdImagen ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Imagenes");
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

        // AGREGAR
        public void addImagen(ImagenBE imagenBE)
        {
            

            const string sqlQuery = @"
                INSERT INTO Imagenes (Nombre, Ruta, IdUsuario)
                VALUES (@Nombre, @Ruta, @IdUsuario)
            ";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", imagenBE.Nombre);
            cmd.Parameters.AddWithValue("@Ruta", imagenBE.Ruta);
            cmd.Parameters.AddWithValue("@IdUsuario", 1);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                conn.Close();
            }

        }

        // MODIFICAR CON IMAGEN
        public void updateImage(ImagenBE imagenBE)
        {
            const string sqlQuery = @"
                UPDATE Imagenes
                SET Nombre = @Nombre,
                    Ruta = @Ruta,
                    IdUsuario = @IdUsuario
                WHERE IdImagen = @IdImagen
            ";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdImagen", imagenBE.IdImagen);
            cmd.Parameters.AddWithValue("@Nombre", imagenBE.Nombre);
            cmd.Parameters.AddWithValue("@Ruta", imagenBE.Ruta);
            cmd.Parameters.AddWithValue("@IdUsuario", 1);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        // MODIFICAR Sin IMAGEN
        public void updateNoImage(ImagenBE imagenBE)
        {
            const string sqlQuery = @"
                UPDATE Imagenes
                SET Nombre = @Nombre,
                    IdUsuario = @IdUsuario
                WHERE IdImagen = @IdImagen
            ";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdImagen", imagenBE.IdImagen);
            cmd.Parameters.AddWithValue("@Nombre", imagenBE.Nombre);
            cmd.Parameters.AddWithValue("@IdUsuario", 1);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        // ELIMINAR
        public void deleteImagen(int id)
        {
            const string sqlQuery = @"
                DELETE FROM Imagenes
                WHERE IdImagen = @IdImagen
            ";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdImagen", id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        // FILTRAR GRILLA
        public DataSet filterGridView(string text)
        {
            const string sqlQuery = "SELECT IdImagen as 'ID', Ruta, Nombre as 'ALT', IdUsuario FROM Imagenes WHERE Ruta = '%' @Ruta '%' ORDER BY IdImagen ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Ruta", text);

            try
            {
                conn.Open();
                adp.Fill(ds, "Imagenes");
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

        public List<ImagenBE> getImagesByAlt(string name)
        {

            const string sqlQuery = @"BEGIN 
                    SET NOCOUNT ON;
                    SELECT IdImagen as 'ID', Ruta, Nombre as 'ALT', IdUsuario 
                    FROM Imagenes
                    WHERE Nombre LIKE @SearchImage + '%' OR @SearchImage = ''
                END";

            List<ImagenBE> list = new List<ImagenBE>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@SearchImage", name);
            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ImagenBE objImagen = new ImagenBE();
                    objImagen.IdImagen = Convert.ToInt32(dr["ID"].ToString());
                    objImagen.Ruta = dr["Ruta"].ToString();
                    objImagen.Nombre = dr["ALT"].ToString();
                    objImagen.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());

                    list.Add(objImagen);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return list;

        }

        public DataSet getImagesByPath(string ruta)
        {

            const string sqlQuery = @"BEGIN 
                    SELECT IdImagen as 'ID', Ruta, Nombre as 'ALT', IdUsuario 
                    FROM Imagenes
                    WHERE Ruta LIKE @Ruta 
                END";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Ruta", ruta);

            try
            {
                conn.Open();
                adp.Fill(ds, "Imagenes");
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

        public List<ImagenBE> getImagesByPathAjx(string ruta)
        {

            const string sqlQuery = @"BEGIN 
                    SELECT IdImagen as 'ID', Ruta, Nombre as 'ALT', IdUsuario 
                    FROM Imagenes
                    WHERE Ruta LIKE @Ruta 
                END";

            List<ImagenBE> list = new List<ImagenBE>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Ruta", ruta);

            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ImagenBE objImagen = new ImagenBE();
                    objImagen.IdImagen = Convert.ToInt32(dr["ID"].ToString());
                    objImagen.Ruta = dr["Ruta"].ToString();
                    objImagen.Nombre = dr["ALT"].ToString();
                    objImagen.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());

                    list.Add(objImagen);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return list;

        }

    }
}
