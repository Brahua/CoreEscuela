using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        private string codigoEscuela;
        public string CodigoEscuela
        {
            get { return "Codigo: " + codigoEscuela; }
            set { codigoEscuela = value; }
        }

        public string Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        /*public Escuela(string Nombre, int AnioCreacion)
        {
            this.Nombre = Nombre;
            this.AnioCreacion = AnioCreacion;
        }*/

        public Escuela(string Nombre, int AnioCreacion) => (this.Nombre, this.AnioCreacion) = (Nombre, AnioCreacion);
    }
}
