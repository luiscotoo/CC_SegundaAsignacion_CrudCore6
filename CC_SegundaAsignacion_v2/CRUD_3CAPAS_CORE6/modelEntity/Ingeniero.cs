using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelEntity
{
    public class Ingeniero
    {
        //creamos los atributos de la clase
        private int id;
        private string nombre;
        private int edad;
        private DateTime fecha_nac;
        private double altura;

        //agregamos un estado para controlar errores

        private int estado;

        //GETS y SETS
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public DateTime Fecha_nac { get => fecha_nac; set => fecha_nac = value; }
        public double Altura { get => altura; set => altura = value; }
        public int Estado { get => estado; set => estado = value; }

        public Ingeniero()
        {

        }

        public Ingeniero(int id)
        {
            this.id = id;
        }

        public Ingeniero(int id, string nombre, int edad, DateTime fecha_nac, double altura)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
            this.fecha_nac= fecha_nac;
            this.altura = altura;
        }

       


    }
}
