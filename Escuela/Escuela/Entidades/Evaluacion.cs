using System;
namespace CoreEscuela.Entidades
{
    public class Evaluacion: ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public double Nota { get; set; }

    }
}
