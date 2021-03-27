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
    public class RolDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        public DataSet getRoles()
        {
            const string sqlQuery = @"
                SELECT IdRol as 'ID', Nombre as 'Rol', Activo
                FROM Roles 
                ORDER BY IdRol ASC
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Roles");
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

        public DataSet getRolActivo()
        {
            const string sqlQuery = @"
                SELECT IdRol, Nombre, Activo
                FROM Roles
                WHERE Activo = 1
                ORDER BY IdRol ASC
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Roles");
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
        public DataSet getRolActivoId(int idRol)
        {
            const string sqlQuery = @"
                SELECT IdRol, Nombre, Activo
                FROM Roles
                WHERE IdRol = @IdRol and Activo = 1
                ORDER BY IdRol ASC
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdRol", idRol);

            try
            {
                conn.Open();
                adp.Fill(ds, "Roles");
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

        public void addRol(RolBE rolBE)
        {
            const string sqlQuery = @"
                INSERT INTO Categorias (Nombre, Activo)
                VALUES (@Nombre, @Activo)
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", rolBE.Nombre);
            cmd.Parameters.AddWithValue("@Activo", rolBE.Activo);

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
        public void updateRol(RolBE rolBE)
        {
            const string sqlQuery = @"
                UPDATE Roles
                SET Nombre = @Nombre, Activo = @Activo
                WHERE IdRol = @IdRol
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", rolBE.IdRol);
            cmd.Parameters.AddWithValue("@Nombre", rolBE.Nombre);
            cmd.Parameters.AddWithValue("@Activo", rolBE.Activo);

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

        public void deleteRol(int id)
        {
            const string sqlQuery = @"
                DELETE FROM Roles
                WHERE IdRol = @IdRol
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdRol", id);

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
    }
}
