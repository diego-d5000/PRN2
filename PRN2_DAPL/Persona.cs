using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Persona
    {
        private string nombre;

        public void SetNombre(string nuevoNombre)
        {
            this.nombre = nuevoNombre;
        }

        public void Saludar()
        {
            Console.WriteLine("Hola soy " + this.nombre);
        }
    }
}
