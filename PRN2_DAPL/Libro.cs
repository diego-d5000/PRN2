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

        // constructor con los tres argumentos
        public Libro(string autor, string titulo, string ubicacion)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.ubicacion = ubicacion;
        }

        // se utiliza la estrategia de la sobrecarga de constructores llamada "chaining constructors"
        public Libro(string autor) : this(autor, null, null)
        {
        }

        public Libro(string autor, string titulo) : this(autor, titulo, null)
        {
        }

        ~Libro()
        {

            this.titulo = null;
            this.autor = null;
            this.ubicacion = null;

            Console.WriteLine(String.Format("Valores al terminar la destruccion:" +
                " titulo: {0}." +
                " autor: {1}." +
                " ubicacion: {2}", titulo, autor, ubicacion));
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

        public void MostrarDatos()
        {
            Console.WriteLine(String.Format(" titulo: {0}. \n" +
                " autor: {1}. \n" +
                " ubicacion: {2} \n", titulo, autor, ubicacion));
        }
    }
}
