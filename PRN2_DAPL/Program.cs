using System;
using System.Linq;

namespace PRN2_DAPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado[] empleados =
            {
                new Empleado(1, "John Doe", "Vendedor", "Ventas", new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)),
                new Empleado(2, "Diego Plascencia", "Programador", "Sistemas", new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)),
                new Empleado(3, "Foo Bar", "Programador", "Sistemas", new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)),
                new Empleado(4, "Juan Perez", " ", "Limpieza", new TimeSpan(6, 0, 0), new TimeSpan(18, 0, 0)),
                new Empleado(5, "Maria Hernandez", " ", "Limpieza", new TimeSpan(6, 0, 0), new TimeSpan(18, 0, 0)),
                new Empleado(6, "Juan Ramirez", "Telefonista", "Soporte", new TimeSpan(9, 0, 0), new TimeSpan(19, 0, 0)),
                new Empleado(7, "Ana Mendez", "Telefonista", "Soporte", new TimeSpan(9, 0, 0), new TimeSpan(19, 0, 0)),
                new Empleado(8, "Roberto Fernandez", "Telefonista", "Soporte", new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0))
            };

            ItemRegistro[] registro =
            {
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(6, 10, 0), empleados[3]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(6, 0, 0), empleados[4]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(8, 00, 0), empleados[0]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(8, 5, 0), empleados[1]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(8, 15, 0), empleados[2]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(9, 0, 0), empleados[5]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(9, 0, 0), empleados[6]),
                new ItemRegistro(AccionEnum.Entrada, new TimeSpan(9, 8, 0), empleados[7]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 0, 0), empleados[0]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 0, 0), empleados[1]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 0, 0), empleados[2]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(17, 10, 0), empleados[7]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(19, 10, 0), empleados[3]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(18, 30, 0), empleados[4]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(19, 0, 0), empleados[5]),
                new ItemRegistro(AccionEnum.Salida, new TimeSpan(19, 0, 0), empleados[6]),
            };

            Console.WriteLine("Registro de Entradas y Salidas...");

            foreach (ItemRegistro item in registro)
            {
                string evento = item.Accion == AccionEnum.Entrada ? "Entrada" : "Salida";
                string empleado = item.Empleado.Nombre;
                string area = item.Empleado.Area;
                string hora = item.HoraRegistro.ToString();

                Console.WriteLine(String.Format("{0} : {1} ({2}) - {3}", evento, empleado, area, hora));
            }

            Console.WriteLine("\n\n\n Reporte Empleados...");

            ReporteEmpleado[] reportes = new ReporteEmpleado[empleados.Length];

            for (int i = 0; i < empleados.Length; i++)
            {
                Empleado empleado = empleados[i];
                var horasTrabajadas = registro
                    .Where(item => item.Empleado.Id == empleado.Id)
                    .Select(item => item.Accion == AccionEnum.Entrada ? item.HoraRegistro.TotalHours * -1 : item.HoraRegistro.TotalHours)
                    .Aggregate(0.0, (a, b) => a + b);

                reportes[i] = new ReporteEmpleado(empleado, horasTrabajadas);
            }

            var reportesOrdenados = from reporte in reportes
                                    orderby reporte.horasTrabajadas descending
                                    select reporte;

            foreach(ReporteEmpleado reporte in reportesOrdenados)
            {
                Console.WriteLine(String.Format("{0} : {1} horas trabajadas", reporte.Empleado.Nombre, reporte.horasTrabajadas));
            }

            Console.ReadLine();
        }
    }
}
