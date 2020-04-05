using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase
    {
        /*private string uniqueId;
        public string UniqueId
        {
            get { return "Codigo: " + uniqueId; }
            set { uniqueId = value.ToUpper(); }
        }*/
        public int AnioCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela() { }

        public Escuela(string Nombre, int AnioCreacion) => (this.Nombre, this.AnioCreacion) = (Nombre, AnioCreacion);

        public Escuela(string Nombre, int AnioCreacion, TiposEscuela TipoEscuela, string Pais = "", string Ciudad = "")
        {
            (this.Nombre, this.AnioCreacion) = (Nombre, AnioCreacion);
            this.TipoEscuela = TipoEscuela;
            this.Pais = Pais;
            this.Ciudad = Ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {this.Nombre}, Tipo: {this.TipoEscuela} \n Pais: {this.Pais}, Ciudad: {this.Ciudad} "; 
        }
    }
}
