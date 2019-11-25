using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlConnection conexion;
        static SqlCommand comando;

        public delegate void DelegadoSQL(string mensaje);
        public static event DelegadoSQL eventoSQL;

        /// <summary>
        /// Constructor donde se iniciacilzan los atributos y la conexión.
        /// </summary>
        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog =correo-sp-2017; Integrated Security = True";

            PaqueteDAO.conexion = new SqlConnection(connectionString);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        /// <summary>
        /// Método estático para guardar un paquete en una base de datos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public static bool Insertar(Paquete p)
        {
            if(p is null)
            {
                eventoSQL.Invoke("El paquete es null");
                return false;
            }
            PaqueteDAO.comando.CommandText = $"INSERT INTO dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('{p.DireccionEntrega}', '{p.TrackingID}', 'Franco Rodrigo Disconsi')";
            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                eventoSQL.Invoke(e.Message);
                return false;
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }
            return true;
        }



    }
}
