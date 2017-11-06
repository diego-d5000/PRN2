using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    // se crea una clase abstracta, es decir contiene miembros "sin cuerpo"
    // contendra los campos comunes entre la clase Factura y Presupuesto
    abstract class DocumentoMercantil
    {
        // se definen los campos comunes de factura y presupuesto
        // con acceso 'protected' para que las clases derivadas puedan manipularlos
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente DatosCliente { get; set; }
        public List<Articulo> Detalles { get; set; }

        // se genera el constructor, que posteriormente sera utilizado en las clases derivadas
        public DocumentoMercantil(int numero, DateTime fecha, Cliente datosCliente, List<Articulo> detalles)
        {
            this.Numero = numero;
            this.Fecha = fecha;
            this.DatosCliente = datosCliente;
            this.Detalles = detalles;
        }


        // se define una propiedad abstracta Total, para que sea implementada por los documentos mercantiles
        abstract public decimal Total
        { get; }
    }
}
