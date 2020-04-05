using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    //La palabra clave sealed indica que esta clase no puede ser heredada por otra
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine() { }

        public void Inicializar()
        {
            this.Escuela = new Escuela
            {
                Nombre = "Brahua Escuela",
                AnioCreacion = 1996,
                Pais = "Perú",
                Ciudad = "Lima",
                TipoEscuela = TiposEscuela.Secundaria
            };
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private List<Alumno> GenerarAlumnosAlAzar(int Cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1    
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((Alumno Alumno) => Alumno.UniqueId).Take(Cantidad).ToList();
        }

        #region Metodos de carga
        private void CargarEvaluaciones()
        {
            this.Escuela.Cursos.ForEach((Curso curso) =>
            {
                curso.Asignaturas.ForEach((Asignatura asignatura) =>
                {
                    curso.Alumnos.ForEach((Alumno alumno) =>
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            Evaluacion evaluacion = new Evaluacion
                            {
                                Nombre = $"EVA0{i}",
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nota = (new Random().NextDouble()) * 5.0
                            };
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    });

                });
            });
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in this.Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura { Nombre = "Matemáticas" },
                    new Asignatura { Nombre = "Educación Física" },
                    new Asignatura { Nombre = "Castellano" },
                    new Asignatura { Nombre = "Historia" }
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private void CargarCursos()
        {
            this.Escuela.Cursos = new List<Curso> {
                new Curso { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso { Nombre = "301", Jornada = TiposJornada.Mañana },
                new Curso { Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso { Nombre = "501", Jornada = TiposJornada.Tarde }
            };
            
            foreach (var curso in this.Escuela.Cursos)
            {
                var CantidadRandom = new Random().Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(CantidadRandom);
            }
        }
        #endregion

    }
}
