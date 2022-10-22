using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tunic_Wiki.Models;

namespace Tunic_Wiki.Datos
{
    public class Consultas: Conexion
    {
        public IEnumerable<Post> ConsultarItems()
        {
            Conectar();
            List<Post> lista = new List<Post>();
            try
            {
                SqlCommand comando = new SqlCommand("spconsultar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Post post = new Post()
                    {
                        id = int.Parse(lector[0] + ""),
                        titulo = lector[1] + "",
                        contenido = lector[2] + ""
                    };
                    lista.Add(post);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return lista;
        }

        public void Guardar(Post post)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("spguardar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@titulo", post.titulo);
                comando.Parameters.AddWithValue("@contenido", post.contenido);
                comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}