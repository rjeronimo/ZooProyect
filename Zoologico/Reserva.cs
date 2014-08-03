using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoologico
{
    class Reserva
    {
        public int CodigoReserva { get; set; }
        public int CodigoUsuario { get; set; }
        public int Asistentes { get; set; }
        public DateTime Fecha_reserva { get; set; }
        public string Turno { get; set; }
        public string Preferencias { get; set; }
    }
}
