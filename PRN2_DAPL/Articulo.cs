using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Articulo
    {
        public Articulo(int unidades, decimal precio, string descripcion)
        {
            Unidades = unidades;
            Precio = precio;
            Descripcion = descripcion;
        }

        public int Unidades
        {
            get;
        }

        public decimal Precio
        {
            get;
        }

        public string Descripcion
        {
            get;
        }

        public string Info => Unidades + " - " + Descripcion;
    }
}
