using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class Empleado : Persona
    {
        public Empleado(int id, string nombre, string puesto, string area, TimeSpan horaEntrada, TimeSpan horaSalida): base(nombre)
        {
            Id = id;
            Puesto = puesto;
            Area = area;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
        }

        public int Id
        {
            get;
        }

        public string Puesto
        {
            get;
        }

        public string Area
        {
            get;
        }

        public TimeSpan HoraEntrada
        {
            get;
        }

        public TimeSpan HoraSalida
        {
            get;
        }
    }
}
