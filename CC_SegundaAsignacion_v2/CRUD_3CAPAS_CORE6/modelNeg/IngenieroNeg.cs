using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelDao;
using modelEntity;

namespace modelNeg
{
    public class IngenieroNeg
    {
        private IngenieroDao objIngenieroDao;
        public IngenieroNeg()
        {
            objIngenieroDao = new IngenieroDao();
        }
        public void create(Ingeniero objIngeniero)
        {
            bool verificacion;
            //validar idIngeniero estado=1
            string codigo = objIngeniero.Id.ToString();
            int idIngeniero = 0;
            if (codigo == null)
            {
                objIngeniero.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    idIngeniero = Convert.ToInt32(objIngeniero.Id);
                    verificacion = idIngeniero >= 0;
                    if (!verificacion)
                    {
                        objIngeniero.Estado = 1;
                        return;
                    }

                }
                catch (Exception e)
                {
                    objIngeniero.Estado = 100;
                }
            }

            //validar Nombre Ingeniero estado=2
            string nombre = objIngeniero.Nombre;
            if (nombre == null)
            {
                objIngeniero.Estado = 20;
                return;
            }
            else
            {
                nombre = objIngeniero.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    objIngeniero.Estado = 2;
                    return;
                }
            }
            //Validar edad Ingeniero estado=3
            int edad = Convert.ToInt32(objIngeniero.Edad);
            if (edad == 0)
            {
                objIngeniero.Estado = 30;
                return;
            }
            else
            {
                edad = objIngeniero.Edad;
                verificacion = edad > 0 || edad <= 100;
                if (!verificacion)
                {
                    objIngeniero.Estado = 3;
                    return;
                }
            }
            //validar FechaNac Ingeniero estado=4
            DateTime fechanac = objIngeniero.Fecha_nac;
            if (fechanac.ToString() == null)
            {
                objIngeniero.Estado = 40;
                return;
            }
            else
            {
                verificacion = fechanac.ToString().Length > 0 && fechanac.ToString().Length <= 50;
                if (!verificacion)
                {
                    objIngeniero.Estado = 4;
                    return;
                }
            }

            //validar que no exista idIngeniero repetido estado=5
            Ingeniero objIngenieroAux = new Ingeniero();
            objIngenieroAux.Id= objIngeniero.Id;
            verificacion = !objIngenieroDao.find(objIngenieroAux);
            if (!verificacion)
            {
                objIngeniero.Estado = 5;
                return;
            }
            objIngeniero.Estado = 99;
            objIngenieroDao.create(objIngeniero);

        }

        public void update(Ingeniero objIngeniero)
        {
            bool verificacion;

            //validar Nombre Ingeniero estado=2
            string nombre = objIngeniero.Nombre;
            if (nombre == null)
            {
                objIngeniero.Estado = 20;
                return;
            }
            else
            {
                nombre = objIngeniero.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    objIngeniero.Estado = 2;
                    return;
                }
            }
            //Validar edad Ingeniero estado=3
            int edad = objIngeniero.Edad;
            if (edad == 0)
            {
                objIngeniero.Estado = 30;
                return;
            }
            else
            {
                verificacion = edad > 0 && edad <= 100;
                if (!verificacion)
                {
                    objIngeniero.Estado = 3;
                    return;
                }
            }
            //validar FechaNac Ingeniero estado=4
            DateTime fechanac = objIngeniero.Fecha_nac;
            if (fechanac.ToString() == null)
            {
                objIngeniero.Estado = 40;
                return;
            }
            else
            {
                verificacion = fechanac.ToString().Length > 0 && fechanac.ToString().Length <= 50;
                if (!verificacion)
                {
                    objIngeniero.Estado = 4;
                    return;
                }
            }

            objIngeniero.Estado = 99;
            objIngenieroDao.update(objIngeniero);

        }

        public void delete(Ingeniero objIngeniero)
        {
            bool verificacion;
            Ingeniero objIngenieroAux = new Ingeniero();
            objIngenieroAux.Id = objIngeniero.Id;
            verificacion = objIngenieroDao.find(objIngenieroAux);
            if (!verificacion)
            {
                objIngeniero.Estado = 33;
                return;
            }
            objIngeniero.Estado = 99;
            objIngenieroDao.delete(objIngeniero);
        }

        public bool find(Ingeniero objIngeniero)
        {
            return objIngenieroDao.find(objIngeniero);
        }

        public List<Ingeniero> findAll()
        {
            return objIngenieroDao.findAll();
        }
    }
}
