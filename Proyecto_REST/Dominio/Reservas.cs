using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Proyecto_REST.Dominio
{
    [DataContract]
    public class Reservas
    {
        [DataMember]
        public int codigoReserva { get; set; }
        [DataMember]
        public string codigoUsuario { get; set; }
        [DataMember]
        public string asistentes { get; set; }
        [DataMember]
        public string fecha_reserva { get; set; }
        [DataMember]
        public string turno { get; set; }
        [DataMember]
        public string preferencias { get; set; }
    }
}