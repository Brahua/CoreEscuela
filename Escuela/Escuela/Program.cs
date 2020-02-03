using System;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Brahua Escuela", 1992);
            escuela.Pais = "Perú";
            escuela.Ciudad = "Lima";
            Console.WriteLine(escuela.CodigoEscuela);
            Console.WriteLine(escuela.Ciudad);
        }
    }
}
