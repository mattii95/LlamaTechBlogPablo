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
    public class UsuarioDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        public DataSet getUsers()
        {
            const string sqlQuery = @"
                SELECT IdUsuario as 'ID', U.Nombre, Apellido, Telefono, Email, Contraseña, FotoPerfil, FechaCreacion, R.Nombre as 'Rol', Status
                FROM Usuarios U
                INNER JOIN Roles R ON U.IdRol = R.IdRol
                ORDER BY U.IdUsuario ASC
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Usuarios");
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

        public void addUser(UsuarioBE usuarioBE)
        {
            const string sqlQuery = @"
                INSERT INTO Usuarios(Nombre, Apellido, Telefono, Email, Contraseña, FotoPerfil, FechaCreacion, IdRol, Status)
                VALUES (@Nombre, @Apellido, @Telefono, @Email, @Contraseña, @FotoPerfil, @FechaCreacion, @IdRol, @Status)
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Nombre", usuarioBE.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuarioBE.Apellido);
            cmd.Parameters.AddWithValue("@Telefono", usuarioBE.Telefono);
            cmd.Parameters.AddWithValue("@Email", usuarioBE.Email);
            cmd.Parameters.AddWithValue("@Contraseña", usuarioBE.Contraseña);
            cmd.Parameters.AddWithValue("@FotoPerfil", usuarioBE.FotoPerfil);
            cmd.Parameters.AddWithValue("@FechaCreacion", usuarioBE.FechaCreacion);
            cmd.Parameters.AddWithValue("@IdRol", usuarioBE.IdRol);
            cmd.Parameters.AddWithValue("@Status", usuarioBE.Status);

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
        public void updateUser(UsuarioBE usuarioBE)
        {
            const string sqlQuery = @"
                UPDATE Usuarios
                SET Nombre = @Nombre, 
                Apellido = @Apellido, 
                Telefono = @Telefono, 
                Email = @Email, 
                FotoPerfil = @FotoPerfil, 
                IdRol = @IdRol, 
                Status = @Status
                WHERE IdUsuario = @IdUsuario
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdUsuario", usuarioBE.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombre", usuarioBE.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuarioBE.Apellido);
            cmd.Parameters.AddWithValue("@Telefono", usuarioBE.Telefono);
            cmd.Parameters.AddWithValue("@Email", usuarioBE.Email);
            cmd.Parameters.AddWithValue("@FotoPerfil", usuarioBE.FotoPerfil);
            cmd.Parameters.AddWithValue("@IdRol", usuarioBE.IdRol);
            cmd.Parameters.AddWithValue("@Status", usuarioBE.Status);

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
        public bool updateUserSinFoto(UsuarioBE usuarioBE)
        {

            bool res = false;

            const string sqlQuery = @"
                UPDATE Usuarios
                SET Nombre = @Nombre, 
                Apellido = @Apellido, 
                Telefono = @Telefono, 
                Email = @Email, 
                IdRol = @IdRol, 
                Status = @Status
                WHERE IdUsuario = @IdUsuario
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdUsuario", usuarioBE.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombre", usuarioBE.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuarioBE.Apellido);
            cmd.Parameters.AddWithValue("@Telefono", usuarioBE.Telefono);
            cmd.Parameters.AddWithValue("@Email", usuarioBE.Email);
            cmd.Parameters.AddWithValue("@IdRol", usuarioBE.IdRol);
            cmd.Parameters.AddWithValue("@Status", usuarioBE.Status);

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
        public bool updatePass(UsuarioBE usuarioBE)
        {

            bool res = false;

            const string sqlQuery = @"
                UPDATE Usuarios
                SET Contraseña = @Contraseña
                WHERE IdUsuario = @IdUsuario
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdUsuario", usuarioBE.IdUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", usuarioBE.Contraseña);

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
        public bool deleteUser(int id)
        {

            bool res = false;

            const string sqlQuery = @"
                DELETE FROM Usuarios
                WHERE IdUsuario = @IdUsuario
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdUsuario", id);

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

        public DataSet login(string email, string pass)
        {
            const string sqlQuery = @"
                SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Email, U.Contraseña, U.FotoPerfil, R.IdRol as 'Rol'
                FROM Usuarios U
                INNER JOIN Roles R on U.IdRol = R.IdRol
                WHERE U.Email = @Email and U.Contraseña = @Contraseña and R.Nombre = 'Administrador' and U.Status = 1
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Contraseña", pass);

            try
            {
                conn.Open();
                adp.Fill(ds, "Usuarios");
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

        // BUSCAR EMAIL
        public List<UsuarioBE> getEmail(string email)
        {
            const string sqlQuery = @"
                SELECT Email
                FROM Usuarios 
                WHERE Email = @Email
            ";

            List<UsuarioBE> lista = new List<UsuarioBE>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UsuarioBE objUsuario = new UsuarioBE();
                    objUsuario.Email = dr["Email"].ToString();

                    lista.Add(objUsuario);
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

        //CONTAR TODAS LAS ENTRADAS
        public DataSet countUsers()
        {
            const string sqlQuery = "select COUNT(*) as 'Usuarios' from Usuarios";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Usuarios");
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
