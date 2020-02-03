using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        
        private static void DibujarLinea(int Tamanio = 10)
        {
            WriteLine("".PadLeft(Tamanio, '='));
        }

        public static void ImprimirTitulo (string Titulo, int TamanioMargenSuperior, int TamanioMargenInferior)
        {
            DibujarLinea(TamanioMargenSuperior);
            WriteLine(Titulo);
            DibujarLinea(TamanioMargenInferior);
        }

        public static void ImprimirTitulo(string Titulo)
        {
            DibujarLinea(Titulo.Length);
            WriteLine(Titulo);
            DibujarLinea(Titulo.Length);
        }


    }
}
