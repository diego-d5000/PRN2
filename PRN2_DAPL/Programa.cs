using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Programa
    {

        // funcion main
        public static void Main(string[] args)
        {
            Console.WriteLine("Constructor un argumento: ");
            // constructor con un argumento
            Libro libro = new Libro("Martin, Robert Cecil");
            libro.MostrarDatos();
            // eliminar la referencia
            libro = null;
            // se llama al recolector de basura manualmente
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Constructor dos argumentos: ");
            // se prueban los otros constructores
            libro = new Libro("Martin, Robert Cecil", "The Clean Coder: A Code of Conduct for Professional Programmers");
            libro.MostrarDatos();
            libro = null;
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Constructor tres argumentos: ");
            libro = new Libro("Martin, Robert Cecil", "The Clean Coder: A Code of Conduct for Professional Programmers", "Upper Saddle River, NJ");
            libro.MostrarDatos();
            libro = null;
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            // para prevenir el cierre de la ventana
            Console.ReadLine();
        }


    }
}
