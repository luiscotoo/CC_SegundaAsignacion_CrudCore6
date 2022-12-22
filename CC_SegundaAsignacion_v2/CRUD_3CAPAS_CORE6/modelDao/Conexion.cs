using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelDao
{
    internal class Conexion
    {
        //singleton
        private static Conexion objconexion = null;
        private SqlConnection con;

        private Conexion()
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=crud_mvc;Integrated Security=True");
        }

        public static Conexion saberEstado()
        {
            if (objconexion == null)
            {
                objconexion = new Conexion();
            }
            return objconexion;
        }

        public SqlConnection getcon()
        {
            return con;
        }

        public void cerrarConexion()
        {
            objconexion = null;
        }
    }
}
