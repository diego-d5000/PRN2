using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Libro
    {
        // se crean los campos
        private string autor;
        private string titulo;
        private string ubicacion;

        // funcion main
        public static void Main(string[] args)
        {
            Libro miLibro = new Libro();
            miLibro.Autor = "Martin, Robert Cecil";
            miLibro.Titulo = "The Clean Coder: A Code of Conduct for Professional Programmers";
            miLibro.Ubicacion = "Upper Saddle River, NJ";

            Console.WriteLine(miLibro.Autor + " (2011). " + miLibro.Titulo + "." + miLibro.Ubicacion);

            // para prevenir el cierre de la ventana
            Console.ReadLine();
        }

        // Se crean las propiedades con los respectivos get y sets

        public string Autor
        {
            // regresando los respectivos valores del campo
            get { return autor; }
            // asignando el valor a el respectivo campo
            set { autor = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }
    }
}
