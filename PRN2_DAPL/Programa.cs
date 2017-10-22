using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Programa
    {
        // metodo utilidad para darle color de fondo y texto a una impresion de consola
        static private void WriteLineWithFormat(string text, ConsoleColor background, ConsoleColor textColor)
        {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor originalTextColor = Console.ForegroundColor;
            Console.BackgroundColor = background;
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ForegroundColor = originalTextColor;
            Console.BackgroundColor = originalBackgroundColor;
        }

        // metodo sobrecargado para imprimir un texto en consolo solo cambiando el fondo
        static private void WriteLineWithFormat(string text, ConsoleColor background)
        {
            WriteLineWithFormat(text, background, ConsoleColor.White);
        }

        // funcion main
        public static void Main(string[] args)
        {
            int selectedOption = 1;
            ConsoleKey keyPressed;

            // se inicia un bucle que solo sale con la tecla esc. para terminar el programa
            do
            {
                // se borra la consola y se imprime el menu
                Console.Clear();
                Console.WriteLine(" ____ ___                       _________                \r\n|    |   \\______ ___________   /   _____/__.__. ______   \r\n|    |   /  ___// __ \\_  __ \\  \\_____  <   |  |/  ___/   \r\n|    |  /\\___ \\\\  ___/|  | \\/  /        \\___  |\\___ \\    \r\n|______//____  >\\___  >__|    /_______  / ____/____  > /\\\r\n             \\/     \\/                \\/\\/         \\/  \\/\r\n\r\n");
                Console.WriteLine("    ----------- Biblioteca \"Los Arboles\" ---------- \n\n\n\n");

                WriteLineWithFormat("Ingresar Usuario \n\n", selectedOption == 1 ? ConsoleColor.Blue : ConsoleColor.Black);
                WriteLineWithFormat("Registrar Usuario", selectedOption == 2 ? ConsoleColor.Blue : ConsoleColor.Black);

               keyPressed = Console.ReadKey().Key;

                // se cambia la opciion con la flecha y se selecciona con enter
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = 2;
                        break;
                    case ConsoleKey.Enter:
                        ShowNextMenu(selectedOption);
                        break;
                }
            } while(keyPressed != ConsoleKey.Escape);
        }

        // se ejecuta un flujo especifico dependiendo de la opcion seleccionada
        private static void ShowNextMenu(int option)
        {
            switch (option)
            {
                case 1:
                    ShowViewUserFlow();
                    break;
                case 2:
                    ShowRegisterUserFlow();
                    break;
            }
        }

        // el primer flujo pide el nombre de usuario y muestra sus datos
        private static void ShowViewUserFlow()
        {
            Console.Clear();
            WriteLineWithFormat("Nombre de Usuario: ", ConsoleColor.Black, ConsoleColor.Green);
            string username = Console.ReadLine();

            InMemoryDB db = InMemoryDB.Instance;

            User user = db.GetUserByUsername(username);

            Console.WriteLine("\n\n\n");

            if(user != null)
            {
                Console.WriteLine(user.GeneralInfo);
                Console.ReadLine();
            } else
            {
                Console.WriteLine("Usuario no encontrado!");
                Console.ReadLine();
            }
        }

        // El segundo flujo registra un usuario pidiendo sus datos.
        private static void ShowRegisterUserFlow()
        {
            Console.Clear();
            WriteLineWithFormat("Nombre de usuario: ", ConsoleColor.Black, ConsoleColor.Blue);
            string username = Console.ReadLine();
            WriteLineWithFormat("Nombre: ", ConsoleColor.Black, ConsoleColor.Blue);
            string name = Console.ReadLine();
            WriteLineWithFormat("Apellido: ", ConsoleColor.Black, ConsoleColor.Blue);
            string lastname = Console.ReadLine();

            User nextUser = new User(name, lastname, username);

            InMemoryDB db = InMemoryDB.Instance;

            db.saveUser(nextUser);
        }

    }
}
