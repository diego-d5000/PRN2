using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Ventana
    {
        public void Mostrar(string mensaje)
        {
            Console.Write(mensaje);
        }

        public void Mostrar(string mensaje, int columna, int fila)
        {
            Console.SetCursorPosition(columna, fila);
            Console.Write(mensaje);
        }

        public void Mostrar(string mensaje, int columna, int fila, ConsoleColor colorletra)
        {
            Console.ForegroundColor = colorletra;
            Mostrar(mensaje, columna, fila);
        }

        public void Mostrar(string mensaje, int columna, int fila, ConsoleColor colorletra, ConsoleColor colorfondo)
        {
            Console.BackgroundColor = colorfondo;
            Mostrar(mensaje, columna, fila, colorletra);
        }

        // nuevo metodo sobrecargado para mostrar el mensaje en mayusculas
        public void Mostrar(string mensaje, int columna, int fila, ConsoleColor colorletra, ConsoleColor colorfondo, bool uppercase)
        {
            mensaje = uppercase ? mensaje.ToUpper() : mensaje;
            Mostrar(mensaje, columna, fila, colorletra, colorfondo);
        }

        static void Main(string[] args)
        {
            Ventana v = new Ventana();
            v.Mostrar("Hola Mundo");
            v.Mostrar("Hola Mundo", 30, 10);
            v.Mostrar("Hola Mundo", 30, 12, ConsoleColor.Red);
            v.Mostrar("Hola Mundo", 30, 14, ConsoleColor.Red, ConsoleColor.Blue);

            // se coloca el color de letra en negro y el fondo blanco con mayusculas
            v.Mostrar("Hola Mundo", 30, 16, ConsoleColor.Black, ConsoleColor.White, true);

            Console.ReadKey();

        }
    }
}
