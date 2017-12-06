using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

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
            int selectedOption = 0;
            ConsoleKey keyPressed;

            // se inicia un bucle que solo sale con la tecla esc. para terminar el programa
            do
            {
                // se borra la consola y se imprime el menu
                Console.Clear();
                Console.WriteLine(" ____ ___                       _________                \r\n|    |   \\______ ___________   /   _____/__.__. ______   \r\n|    |   /  ___// __ \\_  __ \\  \\_____  <   |  |/  ___/   \r\n|    |  /\\___ \\\\  ___/|  | \\/  /        \\___  |\\___ \\    \r\n|______//____  >\\___  >__|    /_______  / ____/____  > /\\\r\n             \\/     \\/                \\/\\/         \\/  \\/\r\n\r\n");
                Console.WriteLine("    ----------- Biblioteca \"Los Arboles\" ---------- \n\n\n\n");

                WriteLineWithFormat("Ingresar Usuario \n\n", selectedOption == 0 ? ConsoleColor.Blue : ConsoleColor.Black);
                WriteLineWithFormat("Registrar Usuario \n\n", selectedOption == 1 ? ConsoleColor.Blue : ConsoleColor.Black);
                WriteLineWithFormat("Cargar Base de Datos \n", selectedOption == 2 ? ConsoleColor.Blue : ConsoleColor.Black);
                WriteLineWithFormat("Guardar Reporte", selectedOption == 3 ? ConsoleColor.Blue : ConsoleColor.Black);

                keyPressed = Console.ReadKey().Key;

                int add = keyPressed == ConsoleKey.UpArrow ? -1 : keyPressed == ConsoleKey.DownArrow ? 1 : 0;
                if (add != 0)
                {
                    selectedOption = ((selectedOption + add) % 4);
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        case 0:
                            ShowViewUserFlow();
                            break;
                        case 1:
                            ShowRegisterUserFlow();
                            break;
                        case 2:
                            try
                            {
                                LoadDatabaseFromCsv();
                                Console.WriteLine("Hecho!");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Archivos con formato Erroneo");
                            }
                            Console.ReadLine();
                            break;
                        case 3:
                            SaveReportFile();
                            Console.WriteLine("Hecho!");
                            Console.ReadLine();
                            break;
                    }
                }
            } while (keyPressed != ConsoleKey.Escape);
        }

        private static void LoadDatabaseFromCsv()
        {
            InMemoryDB db = InMemoryDB.Instance;
            Dictionary<Guid, object> users = new Dictionary<Guid, object>();
            Dictionary<Guid, object> fines = new Dictionary<Guid, object>();


            using (StreamReader csv = new StreamReader(@"users.csv"))
            {
                while (!csv.EndOfStream)
                {
                    string line = csv.ReadLine();
                    string[] values = line.Split(',');

                    LibUser user = new RegisteredUser(Guid.Parse(values[0]), values[1], values[2], values[3]);
                    users.Add(user.AccountNumber, user);
                }
            }

            using (StreamReader csv = new StreamReader(@"fines.csv"))
            {
                while (!csv.EndOfStream)
                {
                    string line = csv.ReadLine();
                    string[] values = line.Split(',');

                    Fine fine = new Fine(Guid.Parse(values[0]), DateTime.Parse(values[1]), decimal.Parse(values[2]), Guid.Parse(values[3]));
                    fines.Add(fine.Id, fine);
                }
            }

            db.LoadDatabase(users, fines);
        }

        private static void SaveReportFile()
        {
            InMemoryDB db = InMemoryDB.Instance;
            Dictionary<Guid, object> users = db.GetAllUsers();
            List<string> lines;

            foreach (LibUser user in users.Values)
            {
                lines = new List<string>();
                List<Fine> fines = db.GetUserFines(user as RegisteredUser);
                lines.Add("No. de Cuenta: " + user.AccountNumber);
                lines.Add("Usuario: " + user.Username);
                lines.Add("Nombre: " + user.FullName);
                if (fines != null && fines.Count > 0)
                {
                    lines.Add("Total de Multas: " + fines.Select(fine => fine.Ammount).Aggregate(0m, (a, b) => a + b));
                    lines.Add(" ");
                    foreach (Fine fine in fines)
                    {
                        string fineText = String.Format("${0}   {1}", fine.Ammount, fine.CreationDate.ToShortDateString());
                        lines.Add(fineText);
                    }
                }
                lines.Add("--------------------------------------------------------------------------");

                File.AppendAllLines(@"report.txt", lines);
            }
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

            if (user != null)
            {
                List<Fine> fines = db.GetUserFines(user as RegisteredUser);

                do
                {

                    Console.Clear();

                    RegisteredUser registeredUser = (RegisteredUser)user;

                    Console.WriteLine(registeredUser.GeneralInfo);
                    if (fines != null && fines.Count > 0)
                    {
                        Console.WriteLine("Total de Multas: " + fines.Select(fine => fine.Ammount).Aggregate(0m, (a, b) => a + b));
                    }
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
                                fines = db.GetUserFines(user as RegisteredUser);
                            }
                            else if (selectedOption == 2)
                            {
                                ShowAPayFineFlow(registeredUser);
                                fines = db.GetUserFines(user as RegisteredUser);
                            }
                            break;
                    }

                } while (keyPressed != ConsoleKey.Escape);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado!");
                Console.ReadLine();
                keyPressed = ConsoleKey.Escape;
            }
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

            db.SaveUser(nextUser);
        }

        private static void ShowAddFineFlow(RegisteredUser user)
        {
            Console.Clear();
            WriteLineWithFormat("Monto: ", ConsoleColor.Black, ConsoleColor.Cyan);
            try
            {
                decimal ammount = Decimal.Parse(Console.ReadLine());

                Fine nextFine = new Fine(DateTime.Today, ammount, user.AccountNumber);

                InMemoryDB db = InMemoryDB.Instance;
                db.SaveFine(nextFine);
            }
            catch (FormatException)
            {
                Console.WriteLine("Cantidad no valida");
                Console.ReadLine();
            }
        }

        private static void ShowAPayFineFlow(RegisteredUser user)
        {
            InMemoryDB db = InMemoryDB.Instance;
            List<Fine> fines = db.GetUserFines(user);
            int selectedIndex = 0;
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione multa a pagar: \n\n ");
                Console.WriteLine("Numero   Monto     Fecha");

                try
                {
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
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Usuario sin multas");
                    Console.ReadLine();
                    break;
                }

                keyPressed = Console.ReadKey().Key;

                int add = keyPressed == ConsoleKey.UpArrow ? -1 : keyPressed == ConsoleKey.DownArrow ? 1 : 0;
                if (add != 0)
                {
                    selectedIndex = ((selectedIndex + add) % fines.Count);
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    db.DeleteFine(fines[selectedIndex]);
                    db.SaveUser(user);

                    Console.WriteLine("Multa pagada, presione ESC para salir");
                    keyPressed = Console.ReadKey().Key;
                }

            } while (keyPressed != ConsoleKey.Escape);
        }

    }
}
