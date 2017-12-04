using System;
using System.Collections.Generic;
using System.Linq;

namespace PRN2_DAPL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();

            empleados.Add(new Empleado(1, "John Doe", "Vendedor", "Ventas", new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)));
            empleados.Add(new Empleado(2, "Diego Plascencia", "Programador", "Sistemas", new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)));
            empleados.Add(new Empleado(3, "Foo Bar", "Programador", "Sistemas", new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)));
            empleados.Add(new Empleado(4, "Juan Perez", " ", "Limpieza", new TimeSpan(6, 0, 0), new TimeSpan(18, 0, 0)));
            empleados.Add(new Empleado(5, "Maria Hernandez", " ", "Limpieza", new TimeSpan(6, 0, 0), new TimeSpan(18, 0, 0)));
            empleados.Add(new Empleado(6, "Juan Ramirez", "Telefonista", "Soporte", new TimeSpan(9, 0, 0), new TimeSpan(19, 0, 0)));
            empleados.Add(new Empleado(7, "Ana Mendez", "Telefonista", "Soporte", new TimeSpan(9, 0, 0), new TimeSpan(19, 0, 0)));
            empleados.Add(new Empleado(8, "Roberto Fernandez", "Telefonista", "Soporte", new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)));

            List<ItemRegistro> registro = new List<ItemRegistro>();

            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(6, 10, 0), empleados[3]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(6, 0, 0), empleados[4]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(8, 00, 0), empleados[0]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(8, 5, 0), empleados[1]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(8, 15, 0), empleados[2]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(9, 0, 0), empleados[5]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(9, 0, 0), empleados[6]));
            registro.Add(new ItemRegistro(AccionEnum.Entrada, new TimeSpan(9, 8, 0), empleados[7]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 0, 0), empleados[0]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 0, 0), empleados[1]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 0, 0), empleados[2]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 10, 0), empleados[7]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(19, 10, 0), empleados[3]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(18, 30, 0), empleados[4]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(19, 0, 0), empleados[5]));
            registro.Add(new ItemRegistro(AccionEnum.Salida, new TimeSpan(19, 0, 0), empleados[6]));

            Console.WriteLine("Registro de Entradas y Salidas...");

            foreach (ItemRegistro item in registro)
            {
                string evento = item.Accion == AccionEnum.Entrada ? "Entrada" : "Salida";
                string empleado = item.Empleado.Nombre;
                string area = item.Empleado.Area;
                string hora = item.HoraRegistro.ToString();

                try
                {
                    Console.WriteLine(String.Format("{0} : {1} ({2}) - {3}", evento, empleado, area, hora));
                }
                catch (FormatException)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.WriteLine("\n\n\n Reporte Empleados...");

            List<ReporteEmpleado> reportes = new List<ReporteEmpleado>();

            try
            {
                foreach (Empleado empleado in empleados)
                {
                    var horasTrabajadas = registro
                        .Where(item => item.Empleado.Id == empleado.Id)
                        .Select(item => item.Accion == AccionEnum.Entrada ? item.HoraRegistro.TotalHours * -1 : item.HoraRegistro.TotalHours)
                        .Aggregate(0.0, (a, b) => a + b);

                    reportes.Add(new ReporteEmpleado(empleado, horasTrabajadas));
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Memoria insuficiente");
                Environment.Exit(1);
            }

            var reportesOrdenados = from reporte in reportes
                                    orderby reporte.horasTrabajadas descending
                                    select reporte;

            foreach (ReporteEmpleado reporte in reportesOrdenados)
            {
                Console.WriteLine(String.Format("{0} : {1} horas trabajadas", reporte.Empleado.Nombre, reporte.horasTrabajadas));
            }

            Console.ReadLine();
        }
    }
}
