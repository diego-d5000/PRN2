using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class ReporteEmpleado
    {
        public ReporteEmpleado(Empleado empleado, double horasTrabajadas)
        {
            Empleado = empleado;
            this.horasTrabajadas = horasTrabajadas;
        }

        public Empleado Empleado
        {
            get;
        }

        public double horasTrabajadas
        {
            get;
        }
    }
}
