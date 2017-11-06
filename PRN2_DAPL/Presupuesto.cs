using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PRN2_DAPL
{
    class Presupuesto : DocumentoMercantil
    {
        // se genera el constructor que asigna los campos de DocumentoMercantil y la propiedad de la clase
        public Presupuesto(int numero, DateTime fecha, Cliente datosCliente, List<Articulo> detalles, DateTime fechaCaducidad) : base(numero, fecha, datosCliente, detalles)
        {
            FechaCaducidad = fechaCaducidad;
        }

        // se agrega la propiedad FechaCaducidad
        public DateTime FechaCaducidad
        {
            get;
        }

        // Se implementa la propiedad abstracta Total de DocumentoMercantil
        public override decimal Total { get => Detalles.Select(detalle => detalle.Precio * detalle.Unidades).Aggregate(0m, (a, b) => (a + b)); }
    }
}
