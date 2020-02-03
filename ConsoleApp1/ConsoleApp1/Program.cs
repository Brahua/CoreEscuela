using System;

namespace ConsoleApp1
{
    class Escuela
    {
        public string nombre;
        public string direccion;
        public int anoFundacion;

        public void Timbrar()
        {
            Console.Beep(3000,3000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela();
            escuela.nombre = "Escuela 1";
            escuela.direccion = "Direccion 1";
            escuela.Timbrar();
            Console.WriteLine("Hello World!");
        }
    }
}
