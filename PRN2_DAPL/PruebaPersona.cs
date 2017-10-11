using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class PruebaPersona
    {
        static void Main(string[] args)
        {
            // Se crean dos objetos de tipo persona
            Persona personaUno = new Persona();
            Persona personaDos = new Persona();

            // Se les asigna un nombre a cada uno
            personaUno.SetNombre("Juan");
            personaDos.SetNombre("Pedro");

            // Se les pide que saluden
            personaUno.Saludar();
            personaDos.Saludar();

            // para prevenir el cierre de la ventana
            Console.ReadLine();
        }
    }
}
