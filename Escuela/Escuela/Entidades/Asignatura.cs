using System;
namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Asignatura()
        {
            this.UniqueId = Guid.NewGuid().ToString();
        }
    }
}
