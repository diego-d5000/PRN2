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
            List<Articulo> articulosUno = new List<Articulo>();
            articulosUno.Add(new Articulo(8, 35.50m, "Articulo A"));
            articulosUno.Add(new Articulo(10, 5.30m, "Articulo B"));
            articulosUno.Add(new Articulo(30, 1.20m, "Articulo Z"));

            Cliente cliente = new Cliente("Diego Plascencia", "Manzana 43", "PALDxxxxxx");

            Factura facturaUno = new Factura(1, DateTime.Today, cliente, articulosUno, 0.16f, 100);

            Console.WriteLine("Factura " + facturaUno.Numero + ": \n" +
                "Total: " + facturaUno.BaseImponible + "\n" +
                "IVA: 16% " + "Cuota: " + facturaUno.Cuota + "\n" +
                "Total + IVA + Cuota: " + facturaUno.Total);

            List<Articulo> articulosDos = new List<Articulo>();
            articulosDos.Add(new Articulo(50, 2.50m, "Articulo B"));
            articulosDos.Add(new Articulo(2, 10000, "Articulo C"));
            articulosDos.Add(new Articulo(15, 19.90m, "Articulo X"));

            Console.WriteLine("\n\n\n");

            Presupuesto presupuestoUno = new Presupuesto(1, DateTime.Today, cliente, articulosDos, DateTime.Today.AddMilliseconds(5 * 24 * 60 * 60 * 1000));

            Console.WriteLine("Presupuesto " + presupuestoUno.Numero + ": \n" +
                "Vencimiento: " + presupuestoUno.FechaCaducidad + "\n" +
                "Total: " + presupuestoUno.Total);

            Console.ReadLine();
        }
    }
}
