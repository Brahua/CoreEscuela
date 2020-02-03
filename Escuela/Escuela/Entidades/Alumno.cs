using System;
namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Alumno()
        {
            this.UniqueId = Guid.NewGuid().ToString();
        }

    }
}
