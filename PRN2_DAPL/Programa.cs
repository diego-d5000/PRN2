using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Programa
    {
        // funcion main
        public static void Main(string[] args)
        {
            decimal cuotaFija;
            Console.WriteLine("Añada la cuota fija:");
            try
            {
                cuotaFija = decimal.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Numero no valido");
                cuotaFija = 0;
            }

            List<Articulo> articulosUno = new List<Articulo>();
            articulosUno.Add(new Articulo(8, 35.50m, "Articulo A"));
            articulosUno.Add(new Articulo(10, 5.30m, "Articulo B"));
            articulosUno.Add(new Articulo(1, decimal.MaxValue, "Articulo Z"));

            Cliente cliente = new Cliente("Diego Plascencia", "Manzana 43", "PALDxxxxxx");

            Factura facturaUno = new Factura(1, DateTime.Today, cliente, articulosUno, 0.16f, cuotaFija);

            Console.WriteLine("Factura " + facturaUno.Numero + ": \n" +
                "Total: " + facturaUno.BaseImponible + "\n" +
                "IVA: 16% " + "Cuota: " + facturaUno.Cuota + "\n" +
                "Total + IVA + Cuota: " + facturaUno.Total);

            Console.WriteLine("\n\n\n");


            List<Articulo> articulosDos = new List<Articulo>();
            articulosDos.Add(new Articulo(8, 35.50m, "Articulo N"));
            articulosDos.Add(new Articulo(10, 5.30m, "Articulo M"));
            articulosDos.Add(new Articulo(1, 10m, "Articulo O"));

            Cliente clienteDos = new Cliente("Diego Lara", "Pera 21", "PALDxxxxxx");

            Factura facturaDos = new Factura(2, DateTime.Today, clienteDos, articulosDos, 0.15f, cuotaFija);

            Console.WriteLine("Factura " + facturaDos.Numero + ": \n" +
                "Total: " + facturaDos.BaseImponible + "\n" +
                "IVA: 15% " + "Cuota: " + facturaDos.Cuota + "\n" +
                "Total + IVA + Cuota: " + facturaDos.Total);

            List<Articulo> articulosTres = new List<Articulo>();
            articulosTres.Add(new Articulo(50, 2.50m, "Articulo B"));
            articulosTres.Add(new Articulo(1, decimal.MaxValue, "Articulo C"));
            articulosTres.Add(new Articulo(15, 19.90m, "Articulo X"));

            Console.WriteLine("\n\n\n");

            Presupuesto presupuestoUno = new Presupuesto(1, DateTime.Today, cliente, articulosTres, DateTime.Today.AddMilliseconds(5 * 24 * 60 * 60 * 1000));

            Console.WriteLine("Presupuesto " + presupuestoUno.Numero + ": \n" +
                "Vencimiento: " + presupuestoUno.FechaCaducidad + "\n" +
                "Total: " + presupuestoUno.Total);

            Console.ReadLine();
        }
    }
}
