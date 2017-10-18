using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Programa
    {

        // se crea un metodo llamado suma que recibe dos enteros y devuelve la suma de estos
        private static int suma(int a, int b)
        {
            return a + b;
        }

        // se sobrecarga el metodo suma, esta vez recibe 2 cadenas y decvuelve la suma de estas
        private static string suma(string a, string b)
        {
            return a + b;
        }

        // funcion main
        public static void Main(string[] args)
        {
            // se prueba el metodo sobrecargado
            Console.WriteLine("Metodo sobrecargado suma con parametros int:");
            int resultadoUno = suma(11, 12);
            Console.WriteLine("suma(11, 12) = " + resultadoUno);

            Console.WriteLine("Metodo sobrecargado suma con parametros string:");
            string resultadoDos = suma("Hola", "Mundo!");
            Console.WriteLine("suma(\"Hola\", \"Mundo!\") = " + resultadoDos);

            // se evita el cierre automatico del programa y la ventana
            Console.ReadLine();
        }

    }
}
