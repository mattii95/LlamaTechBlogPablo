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
    public class CategoriaDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        public DataSet buscarCategoriaNombre(string nombre)
        {
            const string sqlQuery = "SELECT IdCategoria, Nombre FROM Categorias WHERE Nombre = @Nombre";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", nombre);

            try
            {
                conn.Open();
                adp.Fill(ds, "Categorias");
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

        public DataSet getCategoryActive()
        {
            const string sqlQuery = "SELECT IdCategoria as 'ID', Nombre as 'Categoria' FROM Categorias";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Categorias");
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

        public List<CategoriaBE> getCategoriasAjax()
        {
            const string sqlQuery = "SELECT IdCategoria, Nombre FROM Categorias";

            List<CategoriaBE> list = new List<CategoriaBE>();
            
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);            
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CategoriaBE objCategoria = new CategoriaBE();
                    objCategoria.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    objCategoria.Nombre = dr["Nombre"].ToString();

                    list.Add(objCategoria);
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

        public bool addCategory(CategoriaBE categoriaBE)
        {
            bool res = false;

            const string sqlQuery = @"
                INSERT INTO Categorias (Nombre)
                VALUES (@Nombre)
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", categoriaBE.Nombre);

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

        public bool updateCategory(CategoriaBE categoriaBE)
        {

            bool res = false;

            const string sqlQuery = @"
                UPDATE Categorias
                SET Nombre = @Nombre
                WHERE IdCategoria = @IdCategoria
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", categoriaBE.IdCategoria);
            cmd.Parameters.AddWithValue("@Nombre", categoriaBE.Nombre);

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

        public bool deleteCategory(int id)
        {

            bool res = false;

            const string sqlQuery = @"
                DELETE FROM Categorias
                WHERE IdCategoria = @IdCategoria
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", id);

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

        public DataSet BuscarCategoriasUsadas(int id)
        {
            const string sqlQuery = @"select Count(*) as 'Post' from Publicaciones P
                inner join PublicacionCategoria PC on P.IdPublicacion = PC.IdPublicacion
                inner join Categorias C on PC.IdCategoria = C.IdCategoria
                where PC.IdCategoria = @IdCategoria";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "Categorias");
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
        public DataSet BuscarPorId(int id)
        {
            const string sqlQuery = @"select * from Categorias 
                where IdCategoria = @IdCategoria";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "Categorias");
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
    }
}
