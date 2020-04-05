using System;
using System.Collections.Generic;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Brahua Escuela", 1992);
            escuela.Pais = "Perú";
            escuela.Ciudad = "Lima";
            escuela.TipoEscuela = TiposEscuela.Primaria;

            var curso1 = new Curso() { Nombre = "101" };
            var curso2 = new Curso() { Nombre = "201" };
            var curso3 = new Curso() { Nombre = "301" };

            /* 
             * Formas de llenar un arreglo
             * 
             * var arregloCursos = new Curso[] { curso1, curso2, curso3 };
             * Curso[] arregloCursos = { curso1, curso2, curso3 };
             */

            escuela.Cursos = new List<Curso>() { curso1, curso2, curso3 };
            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Mañana });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });


            //Predicate
            escuela.Cursos.RemoveAll(Predicado);
            //Delegate
            escuela.Cursos.RemoveAll(delegate (Curso curso)
                                    {
                                        return curso.Nombre == "101";
                                    });
            //Lambda
            escuela.Cursos.RemoveAll((curso) => curso.Nombre == "101" && curso.Jornada == TiposJornada.Noche);


            /* EscuelaEngine */
            EscuelaEngine EscuelaEngine = new EscuelaEngine();
            EscuelaEngine.Inicializar();
            Printer.ImprimirTitulo("BIENVENIDOS");
            ImprimirInformacionEscuela(EscuelaEngine.Escuela);
            
        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre == "101";
        }

        /// <summary>
        /// Imprime en consola todos los cursos de una escuela
        /// </summary>
        /// <param name="escuela"></param>
        public static void ImprimirInformacionEscuela(Escuela escuela)
        {
            Printer.ImprimirTitulo($"ESCUELA {escuela.Nombre.ToUpper()} \n");
            if (escuela?.Cursos != null)
            {
                ImprimirCursos(escuela.Cursos);
            }
            else
            {
                WriteLine("No existe cursos registrados");
            }
        }

        public static void ImprimirCursos(List<Curso> listaCursos) 
        {
            Printer.ImprimirTitulo("\nCURSOS");
            foreach (Curso curso in listaCursos)
            {
                WriteLine($"\n\nNombre: {curso.Nombre} | Jornada: {curso.Jornada}");
                ImprimirAsignaturas(curso.Asignaturas);
                ImprimirAlumnos(curso.Alumnos);
            }
        }

        private static void ImprimirAlumnos(List<Alumno> alumnos)
        {
            Printer.ImprimirTitulo("ALUMNOS");
            foreach (Alumno alumno in alumnos)
            {
                WriteLine($"\nNombre: {alumno.Nombre}");
                ImprimirEvaluaciones(alumno.Evaluaciones);
            }
        }

        private static void ImprimirAsignaturas(List<Asignatura> asignaturas)
        {
            Printer.ImprimirTitulo("ASIGNATURAS");
            foreach (Asignatura asignatura in asignaturas)
            {
                WriteLine($"Codigo: {asignatura.UniqueId} | Nombre: {asignatura.Nombre}");
            }
        }

        private static void ImprimirEvaluaciones(List<Evaluacion> evaluaciones) 
        {
            Printer.ImprimirTitulo("NOTAS", 20, 20);
            foreach (Evaluacion evaluacion in evaluaciones)
            {
                WriteLine($"Evaluacion: {evaluacion.Nombre} | Asignatura: {evaluacion.Asignatura.Nombre} | Nota: {evaluacion.Nota}");
            }
        }
    }
}
