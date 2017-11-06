using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Cliente
    {
        public Cliente(string nombre, string direccion, string RFC)
        {
            Nombre = nombre;
            Direccion = direccion;
            this.RFC = RFC;
        }

        public string Nombre
        {
            get;
        }

        public string Direccion
        {
            get;
            set;
        }

        public string RFC
        {
            get;
        }

        public string Info => Nombre + ". " + Direccion + ". " + RFC;
    }
}
