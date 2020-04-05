using System;

namespace CoreEscuela.Entidades
{
    //La palabra clave abstract indica que esta clase puede ser heredada pero no se puede instanciar.
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            this.UniqueId = Guid.NewGuid().ToString();
        }
    }
}
