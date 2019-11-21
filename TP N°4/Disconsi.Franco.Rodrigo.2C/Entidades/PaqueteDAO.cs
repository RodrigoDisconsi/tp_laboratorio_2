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

        static PaqueteDAO()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
        }


    }
}
