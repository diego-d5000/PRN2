using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class ItemRegistro
    {
        public ItemRegistro(AccionEnum accion, TimeSpan horaRegistro, Empleado empleado)
        {
            Accion = accion;
            HoraRegistro = horaRegistro;
            Empleado = empleado;
        }

        public AccionEnum Accion
        {
            get;
        }

        public TimeSpan HoraRegistro
        {
            get;
        }

        public Empleado Empleado
        {
            get;
        }

        public override string ToString()
        {
            return "[ " +
                "Acción: " + Accion.ToString() +
                " Hora Registro: " + HoraRegistro.ToString() +
                " Empleado: " + Empleado.ToString() +
                "]";
        }
    }
}
