using modelEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelDao
{
    public class IngenieroDao:Obligatorio<Ingeniero>
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public IngenieroDao() 
        {
            objConexion = Conexion.saberEstado();
        }


        public void create(Ingeniero objIngeniero)
        {
            string create = "insert into ingenieros(nombre,edad,fecha_nac,altura) values ('" + objIngeniero.Nombre + "','"+ objIngeniero.Edad + "','"+ objIngeniero.Fecha_nac.ToString("yyyy-MM-dd HH:mm:ss") + "','"+ objIngeniero.Altura +"')";
            try
            {
                comando = new SqlCommand(create, objConexion.getcon());
                objConexion.getcon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }finally
            {
                objConexion.getcon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void delete(Ingeniero objIngeniero)
        {
            string delete = "delete ingenieros where id='" + objIngeniero.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexion.getcon());
                objConexion.getcon().Open();
                comando.ExecuteNonQuery();
                objIngeniero.Estado = 45;
            }
            catch (Exception)
            {
                objIngeniero.Estado = 25;
                throw;
            }
            finally
            {
                objConexion.getcon().Close();
                objConexion.cerrarConexion();
            }
        }
    

        public bool find(Ingeniero objIngeniero)
        {
            bool existenRegistros;
            string find = "select * from ingenieros where id = '"+ objIngeniero.Id+"'";
            try
            {
                comando = new SqlCommand(find, objConexion.getcon());
                objConexion.getcon().Open();
                SqlDataReader read = comando.ExecuteReader();
                existenRegistros = read.Read();
                if (existenRegistros)
                {
                    objIngeniero.Id = Convert.ToInt32(read[0].ToString());
                    objIngeniero.Nombre = read[1].ToString();
                    objIngeniero.Edad = Convert.ToInt32(read[2].ToString());
                    objIngeniero.Fecha_nac = Convert.ToDateTime(read[3].ToString());
                    objIngeniero.Altura = Convert.ToDouble(read[4].ToString());

                    objIngeniero.Estado = 99;
                }
                else
                {
                    objIngeniero.Estado = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getcon().Close();
                objConexion.cerrarConexion();
            }
            return existenRegistros;
        }

        public List<Ingeniero> findAll()
        {
            List<Ingeniero> listaIngenieros = new List<Ingeniero>();
            string findAll = "select * from ingenieros";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getcon());
                objConexion.getcon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Ingeniero objIngeniero = new Ingeniero();
                    objIngeniero.Id = Convert.ToInt32(read[0].ToString());
                    objIngeniero.Nombre = read[1].ToString();
                    objIngeniero.Edad = Convert.ToInt32(read[2].ToString());
                    objIngeniero.Fecha_nac = Convert.ToDateTime(read[3].ToString());
                    objIngeniero.Altura = Convert.ToDouble(read[4].ToString());
                    listaIngenieros.Add(objIngeniero);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getcon().Close();
                objConexion.cerrarConexion();
            }
            return listaIngenieros;
        }

        public void update(Ingeniero objIngeniero)
        {
            string update = "update ingenieros set nombre='" + objIngeniero.Nombre + "',edad = '" + objIngeniero.Edad + "',fecha_nac = '" + objIngeniero.Fecha_nac.ToString("yyyy-MM-dd HH:mm:ss") + "',altura = '" + objIngeniero.Altura + "' where id = '"+ objIngeniero.Id+"'";
            try
            {
                comando = new SqlCommand(update, objConexion.getcon());
                objConexion.getcon().Open();
                comando.ExecuteNonQuery();
                objIngeniero.Estado = 68;
            }
            catch (Exception)
            {
                objIngeniero.Estado = 69;
                throw;
            }
            finally
            {
                objConexion.getcon().Close();
                objConexion.cerrarConexion();
            }
        }
    }
}
