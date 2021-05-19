using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LlamaTech.BE;

namespace LlamaTech.DA
{
    public class PublicacionDA
    {
        /*  CONEXION    */
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        //  BUSCAR TODOS LOS POSTS
        public DataSet getPosts()
        {

            const string sqlQuery = "SELECT * FROM Publicaciones ORDER BY IdPublicacion ASC";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Publicaciones");
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
        public DataTable getPostsActive()
        {

            const string sqlQuery = @"
            SELECT P.IdPublicacion, Titulo, Descripcion, Imagen, FORMAT( FechaPublicacion, 'dd/MM/yyyy', 'en-US' ) AS 'Date',
                FORMAT( FechaPublicacion, 'dd', 'en-US' ) AS 'Day', DATENAME(MONTH, FechaPublicacion) AS 'Month', Slug, C.Nombre as 'Categoria', U.Nombre as 'Usuario' , U.FotoPerfil
                FROM Publicaciones P
                inner join PublicacionCategoria PC on P.IdPublicacion = PC.IdPublicacion
                inner join Categorias C on PC.IdCategoria = C.IdCategoria
                INNER JOIN Usuarios U on P.IdUsuario = U.IdUsuario
                WHERE IdEstado = 1 ORDER BY IdPublicacion DESC
            ";

            
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        //  BUSCAR Post POR ID
        public DataSet getPostID(int id)
        {

            const string sqlQuery = @"
                SELECT P.IdPublicacion, P.Titulo, P.Descripcion, P.Imagen, P.Contenido, FORMAT( P.FechaPublicacion, 'dd/MM/yyyy HH:mm', 'en-US' ) AS 'Publicado', P.Slug, C.Nombre, U.Nombre as 'Usuario', U.FotoPerfil
                FROM Publicaciones P
                INNER JOIN PublicacionCategoria PC ON P.IdPublicacion = PC.IdPublicacion
                INNER JOIN Categorias C ON PC.IdCategoria = C.IdCategoria
                INNER JOIN Usuarios U on P.IdUsuario = U.IdUsuario
                WHERE P.IdPublicacion = @IdPublicacion
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdPublicacion", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "Publicaciones");
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

        //  AGREGAR POSTS
        public bool addPost(PublicacionBE publicacionBE, PublicacionCategoriaBE publicacionCategoriaBE, PublicacionSubCategoriaBE publicacionSubCategoriaBE)
        {
            bool res = false;

            const string sqlQuery = @"
                BEGIN TRY
	                BEGIN TRAN
	                DECLARE @IdPublicacion int
	                INSERT INTO Publicaciones (Titulo, Descripcion, Imagen, Contenido, FechaCreacion, FechaPublicacion, Slug, IdUsuario, IdEstado)
	                VALUES (@Titulo, @Descripcion, @Imagen, @Contenido, GETDATE(), @FechaPublicacion, @Slug, @IdUsuario, @IdEstado)
	                SELECT @IdPublicacion = SCOPE_IDENTITY()
	                INSERT INTO PublicacionCategoria(IdPublicacion, IdCategoria)
	                VALUES (@IdPublicacion, @IdCategoria)
					INSERT INTO PublicacionesSubCategorias(IdPublicacion, IdSubCategoria)
					VALUES (@IdPublicacion, @IdSubCategoria)
	                COMMIT
                END TRY
                BEGIN CATCH
	                rollback
                END CATCH
            ";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Titulo", publicacionBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", publicacionBE.Descripcion);
            cmd.Parameters.AddWithValue("@Imagen", publicacionBE.Imagen);
            cmd.Parameters.AddWithValue("@Contenido", publicacionBE.Contenido);
            if (publicacionBE.FechaPublicacion != null)
            {
                cmd.Parameters.AddWithValue("@FechaPublicacion", publicacionBE.FechaPublicacion);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FechaPublicacion", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@Slug", publicacionBE.Slug);
            cmd.Parameters.AddWithValue("@IdUsuario", publicacionBE.IdUsuario);
            cmd.Parameters.AddWithValue("@IdCategoria", publicacionCategoriaBE.IdCategoria);
            cmd.Parameters.AddWithValue("@IdSubCategoria", publicacionSubCategoriaBE.IdSubCategoria);
            cmd.Parameters.AddWithValue("@IdEstado", publicacionBE.idEstado);

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

        //  MODIFICAR POSTS
        public bool updatePost(PublicacionBE publicacionBE, PublicacionCategoriaBE publicacionCategoriaBE, PublicacionSubCategoriaBE publicacionSubCategoriaBE)
        {

            bool res = false;

            const string sqlQuery = @"
                        BEGIN TRY
                        BEGIN TRAN
                        UPDATE Publicaciones 
                        SET Titulo = @Titulo, 
                        Descripcion = @Descripcion,
                        Imagen = @Imagen,
                        Contenido = @Contenido,
                        FechaModificacion = GETDATE(), 
                        FechaPublicacion = @FechaPublicacion,
                        Slug = @Slug, 
                        IdEstado = @IdEstado
                        WHERE IdPublicacion = @IdPublicacion
                        SELECT @IdPublicacion = SCOPE_IDENTITY()
                        UPDATE PublicacionCategoria set IdPublicacion = @Id, IdCategoria = @IdCategoria
                        WHERE IdPublicacion = @Id
                        UPDATE PublicacionesSubCategorias set IdPublicacion = @IdPSC, IdSubCategoria = @IdSubCategoria
                        WHERE IdPublicacion = @IdPSC
                        COMMIT
                        END TRY
                        BEGIN CATCH
                        rollback
                        END CATCH
            ";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdPublicacion", publicacionBE.IdPublicacion);
            cmd.Parameters.AddWithValue("@Titulo", publicacionBE.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", publicacionBE.Descripcion);
            cmd.Parameters.AddWithValue("@Imagen", publicacionBE.Imagen);
            cmd.Parameters.AddWithValue("@Contenido", publicacionBE.Contenido);
            if (publicacionBE.FechaPublicacion != null)
            {
                cmd.Parameters.AddWithValue("@FechaPublicacion", publicacionBE.FechaPublicacion);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FechaPublicacion", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@Slug", publicacionBE.Slug);
            cmd.Parameters.AddWithValue("@IdEstado", publicacionBE.idEstado);
            cmd.Parameters.AddWithValue("@Id", publicacionCategoriaBE.IdPublicacion);
            cmd.Parameters.AddWithValue("@IdCategoria", publicacionCategoriaBE.IdCategoria);
            cmd.Parameters.AddWithValue("@IdPSC", publicacionSubCategoriaBE.IdPublicacion);
            cmd.Parameters.AddWithValue("@IdSubCategoria", publicacionSubCategoriaBE.IdSubCategoria);

            try
            {
                conn.Open();
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
                conn.Close();
            }

            return res;

        }

        //  ELIMINAR POST
        public bool deletePost(int IdPublicacion)
        {

            bool res = false;

            const string sqlQuery = @"
                BEGIN TRY
                BEGIN TRAN
                DELETE FROM Publicaciones 
                WHERE IdPublicacion = @IdPublicacion
                SELECT @IdPublicacion = SCOPE_IDENTITY()
                DELETE FROM PublicacionCategoria
                WHERE IdPublicacion = @Id
                DELETE FROM PublicacionesSubCategorias
                WHERE IdPublicacion = @Id
                COMMIT
                END TRY
                BEGIN CATCH
                rollback
                END CATCH
            ";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdPublicacion", IdPublicacion);
            cmd.Parameters.AddWithValue("@Id", IdPublicacion);

            try
            {
                conn.Open();
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
                conn.Close();
            }

            return res;

        }

        //  BUSCAR LOS ULTIMOS 9 POSTS
        public DataSet getTop9Posts()
        {

            const string sqlQuery = @"
            SELECT TOP 9 P.IdPublicacion, Titulo, Descripcion, Imagen, FORMAT( FechaPublicacion, 'dd/MM/yyyy', 'en-US' ) AS 'Date',
                FORMAT( FechaPublicacion, 'dd', 'en-US' ) AS 'Day', DATENAME(MONTH, FechaPublicacion) AS 'Month', Slug, C.Nombre as 'Categoria', U.Nombre as 'Usuario', U.FotoPerfil
                FROM Publicaciones P
                inner join PublicacionCategoria PC on P.IdPublicacion = PC.IdPublicacion
                inner join Categorias C on PC.IdCategoria = C.IdCategoria
                INNER JOIN Usuarios U on P.IdUsuario = U.IdUsuario
                WHERE idEstado = 1 ORDER BY P.IdPublicacion DESC
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Publicaciones");
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

        //  BUSCAR DATOS EN LA GRILLA
        public DataSet getEntradas()
        {

            const string sqlQuery = @"
                SELECT P.IdPublicacion, P.Titulo, P.Descripcion, P.Imagen, P.Contenido, FORMAT(P.FechaCreacion, 'dd/MM/yyyy, hh:mm') as 'Creado', 
                FORMAT(P.FechaModificacion, 'dd/MM/yyyy, hh:mm') as 'Modificado',
                FORMAT(P.FechaPublicacion, 'dd/MM/yyyy, hh:mm') as 'Publicado',
                P.Slug, C.Nombre as 'Categoria', E.Estado, U.Nombre as 'Usuario'
                FROM Publicaciones P
                INNER JOIN PublicacionCategoria PC on P.IdPublicacion = PC.IdPublicacion
				INNER JOIN Categorias C on PC.IdCategoria = C.IdCategoria
				INNER JOIN PublicacionesSubCategorias PSC on P.IdPublicacion = PSC.IdPublicacion
                INNER JOIN Estados E on P.IdEstado = E.IdEstado
                INNER JOIN Usuarios U on P.IdUsuario = U.IdUsuario
                ORDER BY IdPublicacion ASC
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Publicaciones");
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

        //CONTAR TODAS LAS ENTRADAS
        public DataSet countEntradas()
        {
            const string sqlQuery = "select COUNT(*) as 'Entradas' from Publicaciones";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                adp.Fill(ds, "Publicaciones");
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

        // Filtrar categorias
        public DataTable filetCategorias(int id)
        {

            const string sqlQuery = @"
                SELECT P.IdPublicacion, Titulo, Descripcion, Imagen, FORMAT( FechaPublicacion, 'dd/MM/yyyy', 'en-US' ) AS 'Date',
                FORMAT( FechaPublicacion, 'dd', 'en-US' ) AS 'Day', DATENAME(MONTH, FechaPublicacion) AS 'Month', Slug, U.Nombre as 'Usuario' , U.FotoPerfil
                FROM Publicaciones P
                inner join PublicacionCategoria PC on P.IdPublicacion = PC.IdPublicacion
                inner join Categorias C on PC.IdCategoria = C.IdCategoria
                INNER JOIN Usuarios U on P.IdUsuario = U.IdUsuario
                WHERE P.IdEstado = 1 and C.IdCategoria = @IdCategoria ORDER BY P.IdPublicacion DESC
            ";


            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdCategoria", id);

            try
            {
                conn.Open();
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        // BUSCAR FECHA PUBLICADA
        public DataSet getFechaPublicacion(int id)
        {

            const string sqlQuery = @"
                select FORMAT( FechaPublicacion, 'dd/MM/yyyy HH:mm', 'en-US' ) AS 'Publicado', E.IdEstado
                from Publicaciones P
                INNER JOIN Estados E on P.IdEstado = E.IdEstado
                where IdPublicacion = @IdPublicacion
            ";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IdPublicacion", id);

            try
            {
                conn.Open();
                adp.Fill(ds, "Publicaciones");
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


        // FILTRAR POSTS
        public DataTable getPostName(string name)
        {
            const string sqlQuery = @"
            SELECT P.IdPublicacion, Titulo, Descripcion, Imagen, FORMAT( FechaPublicacion, 'dd/MM/yyyy', 'en-US' ) AS 'Date',
                FORMAT( FechaPublicacion, 'dd', 'en-US' ) AS 'Day', DATENAME(MONTH, FechaPublicacion) AS 'Month', Slug, U.Nombre as 'Usuario' , U.FotoPerfil
                FROM Publicaciones P
                inner join PublicacionCategoria PC on P.IdPublicacion = PC.IdPublicacion
                inner join Categorias C on PC.IdCategoria = C.IdCategoria
                INNER JOIN Usuarios U on P.IdUsuario = U.IdUsuario
                where Titulo like '%'+@Titulo+'%' ORDER BY P.IdPublicacion DESC
            ";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Titulo", name);

            try
            {
                conn.Open();
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;


        }
    }
}
