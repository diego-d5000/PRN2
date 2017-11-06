using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PRN2_DAPL
{
    // se crea la clase normal Factura que hereda o es derivada de DocumentoMercantil, heredando todos sus miembros
    class Factura : DocumentoMercantil
    {
        // se define el constructor, que llama al constructor base, es decir el constructor de DocumentoMercantil
        public Factura(int numero, DateTime fecha, Cliente datosCliente, List<Articulo> detalles, float porcentajeIVA, decimal cuota) : base(numero, fecha, datosCliente, detalles)
        {
            // se asignan las propiedades de la propia clase
            PorcentajeIVA = porcentajeIVA;
            Cuota = cuota;
        }

        // se definen las propiedades de factura

        public float PorcentajeIVA
        {
            get;
            set;
        }

        public decimal BaseImponible
        {
            get { return Detalles.Select(detalle => detalle.Precio * detalle.Unidades).Aggregate(0m, (a, b) => (a + b)); }
        }

        public decimal Cuota
        {
            get;
            set;
        }

        // Se implementa la propiedad abstracta Total de DocumentoMercantil
        public override decimal Total => (BaseImponible * (1 + (decimal)PorcentajeIVA)) + Cuota;
    }
}
