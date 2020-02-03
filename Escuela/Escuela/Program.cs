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

            var curso1 = new Curso()
            {
                Nombre = "101"
            };
            var curso2 = new Curso()
            {
                Nombre = "201"
            };
            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            //var arregloCursos = new Curso[] { curso1, curso2, curso3 };
            //Curso[] arregloCursos = { curso1, curso2, curso3 };
            //escuela.Cursos = new Curso[] { curso1, curso2, curso3 };


            escuela.Cursos = new List<Curso>() { curso1, curso2, curso3 };
            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Mañana });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            escuela.Cursos.RemoveAll(Predicado);
            //delegate
            escuela.Cursos.RemoveAll(delegate (Curso curso)
            {
                return curso.Nombre == "101";
            });
            //expresion lambda
            escuela.Cursos.RemoveAll((curso) => curso.Nombre == "101" && curso.Jornada == TiposJornada.Noche);

            //Console.WriteLine(new Escuela("Escuela 62", 1996, TiposEscuela.Secundaria, "Peru"));
            //Console.WriteLine(new Escuela("Escuela 62", 1996, TiposEscuela.Secundaria, Ciudad: "Iquitos"));



            /* EscuelaEngine */
            EscuelaEngine EscuelaEngine = new EscuelaEngine();
            EscuelaEngine.Inicializar();
            Printer.ImprimirTitulo("BIENVENIDOS");
            ImprimirCursosEscuela(EscuelaEngine.Escuela);
        
            
        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre == "101";
        }

        /// <summary>
        /// Imprime en consola todos los cursos de una escuela
        /// </summary>
        /// <param name="escuela"></param>
        public static void ImprimirCursosEscuela(Escuela escuela)
        {
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }

    }
}
