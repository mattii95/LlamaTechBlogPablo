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
    public class SubCategoriaDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        public DataSet getSubCategory()
        {
            const string sqlQuery = @"Select SC.IdSubCategoria, sc.Nombre as 'SubCategoria', C.Nombre as 'Categoria'
                from SubCategorias SC
                inner
                join Categorias C on SC.IdCategoria = c.IdCategoria";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "SubCategorias");
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
        public DataSet getSubCategoryId(int id)
        {
            const string sqlQuery = @"
                Select IdSubCategoria, Nombre, IdCategoria
                from SubCategorias 
                where IdSubCategoria = @IdSubCategoria
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdSubCategoria", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "SubCategorias");
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
        public DataSet getSubCategoryActive(int id)
        {
            const string sqlQuery = @"
                Select SC.IdSubCategoria as 'id', sc.Nombre as 'SubCategoria'
                from SubCategorias SC
                inner join Categorias C on SC.IdCategoria = c.IdCategoria
                where C.IdCategoria = @IdCategoria
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "SubCategorias");
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
        public List<SubCategoriaBE> getSubCategoryAjax(int id)
        {
            const string sqlQuery = @"
                Select SC.IdSubCategoria as 'id', sc.Nombre as 'SubCategoria'
                from SubCategorias SC
                inner join Categorias C on SC.IdCategoria = c.IdCategoria
                where C.IdCategoria = @IdCategoria
            ";

            List<SubCategoriaBE> lista = new List<SubCategoriaBE>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", id);
            SqlDataReader dr = null;


            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SubCategoriaBE subCategoriaBE = new SubCategoriaBE();
                    subCategoriaBE.IdSubCategoria = Convert.ToInt32(dr["id"].ToString());
                    subCategoriaBE.Nombre = dr["SubCategoria"].ToString();

                    lista.Add(subCategoriaBE);
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

            return lista;
        }

        public bool agregarSub(SubCategoriaBE subCategoriaBE)
        {
            bool res = false;

            const string sqlQuery = @"
                INSERT INTO SubCategorias (IdCategoria, Nombre)
                VALUES (@IdCategoria, @Nombre)
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", subCategoriaBE.IdCategoria);
            cmd.Parameters.AddWithValue("@Nombre", subCategoriaBE.Nombre);

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

        public bool modificarSub(SubCategoriaBE subCategoriaBE)
        {

            bool res = false;

            const string sqlQuery = @"
                UPDATE SubCategorias
                SET IdCategoria = @IdCategoria, Nombre = @Nombre
                WHERE IdSubCategoria = @IdSubCategoria
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdSubCategoria", subCategoriaBE.IdSubCategoria);
            cmd.Parameters.AddWithValue("@IdCategoria", subCategoriaBE.IdCategoria);
            cmd.Parameters.AddWithValue("@Nombre", subCategoriaBE.Nombre);

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

        public bool eliminarSub(int id)
        {

            bool res = false;

            const string sqlQuery = @"
                DELETE FROM SubCategorias
                WHERE IdSubCategoria = @IdSubCategoria
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdSubCategoria", id);

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
    }
}
