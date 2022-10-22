using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tunic_Wiki.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;
        protected void Conectar()
        {
            try
            {
                cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sebas\source\repos\Tunic Wiki\Tunic Wiki\App_Data\DataForo.mdf;Integrated Security=True");
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        protected void Desconectar()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}