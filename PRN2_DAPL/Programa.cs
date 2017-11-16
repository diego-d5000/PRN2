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
                        (selectedOption == 1 ? (Action)ShowViewUserFlow : ShowRegisterUserFlow)();
                        break;
                }
            } while (keyPressed != ConsoleKey.Escape);
        }

        // el primer flujo pide el nombre de usuario y muestra sus datos
        private static void ShowViewUserFlow()
        {

            int selectedOption = 1;
            ConsoleKey keyPressed;

            Console.Clear();
            WriteLineWithFormat("Nombre de Usuario: ", ConsoleColor.Black, ConsoleColor.Green);
            string username = Console.ReadLine();

            InMemoryDB db = InMemoryDB.Instance;

            LibUser user = db.GetUserByUsername(username);

            do
            {
                Console.Clear();
                if (user != null)
                {
                    RegisteredUser registeredUser = (RegisteredUser)user;

                    Console.WriteLine(registeredUser.GeneralInfo);
                    Console.WriteLine("\n\n\n");
                    WriteLineWithFormat("Ingresar Multa \n\n", selectedOption == 1 ? ConsoleColor.Blue : ConsoleColor.Black);
                    WriteLineWithFormat("Pagar Multa", selectedOption == 2 ? ConsoleColor.Blue : ConsoleColor.Black);

                    keyPressed = Console.ReadKey().Key;

                    switch (keyPressed)
                    {
                        case ConsoleKey.UpArrow:
                            selectedOption = 1;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedOption = 2;
                            break;
                        case ConsoleKey.Enter:
                            if (selectedOption == 1)
                            {
                                ShowAddFineFlow(registeredUser);
                            }
                            else if (selectedOption == 2)
                            {
                                ShowAPayFineFlow(registeredUser);
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado!");
                    Console.ReadLine();
                    keyPressed = ConsoleKey.Escape;
                }
            } while (keyPressed != ConsoleKey.Escape);

        }

        // El segundo flujo registra un usuario pidiendo sus datos.
        private static void ShowRegisterUserFlow()
        {
            Console.Clear();
            WriteLineWithFormat("Nombre de usuario: ", ConsoleColor.Black, ConsoleColor.Cyan);
            string username = Console.ReadLine();
            WriteLineWithFormat("Nombre: ", ConsoleColor.Black, ConsoleColor.Cyan);
            string name = Console.ReadLine();
            WriteLineWithFormat("Apellido: ", ConsoleColor.Black, ConsoleColor.Cyan);
            string lastname = Console.ReadLine();

            RegisteredUser nextUser = new RegisteredUser(name, lastname, username);

            InMemoryDB db = InMemoryDB.Instance;

            db.saveUser(nextUser);
        }

        private static void ShowAddFineFlow(RegisteredUser user)
        {
            Console.Clear();
            WriteLineWithFormat("Monto: ", ConsoleColor.Black, ConsoleColor.Cyan);
            decimal ammount = Decimal.Parse(Console.ReadLine());

            Fine nextFine = new Fine(DateTime.Today, ammount);

            user.AddFine(nextFine);
        }

        private static void ShowAPayFineFlow(RegisteredUser user)
        {
            List<Fine> fines = user.Fines;
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione multa a pagar: \n\n ");
                Console.WriteLine("Numero   Monto     Fecha");

                for (int i = 0; i < fines.Count; i++)
                {
                    Fine fine = fines[i];
                    string fineText = String.Format("{0}.     ${1}   {2}", i + 1, fine.Ammount, fine.CreationDate.ToShortDateString());

                    if (i != selectedIndex)
                    {
                        Console.WriteLine(fineText);
                    }
                    else
                    {
                        WriteLineWithFormat(fineText, ConsoleColor.Red, ConsoleColor.White);

                    }
                }

                keyPressed = Console.ReadKey().Key;

                int add = keyPressed == ConsoleKey.UpArrow ? -1 : keyPressed == ConsoleKey.DownArrow ? 1 : 0;
                if (add != 0)
                {
                    selectedIndex = ((selectedIndex + add) % fines.Count);
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    user.RemoveFine(selectedIndex);
                    InMemoryDB db = InMemoryDB.Instance;
                    db.saveUser(user);

                    Console.WriteLine("Multa pagada, presione ESC para salir");
                    keyPressed = Console.ReadKey().Key;
                }

            } while (keyPressed != ConsoleKey.Escape);
        }

    }
}
