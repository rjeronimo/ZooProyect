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
        public string CodigoReserva { get; set; }
        [DataMember]
        public string CodigoUsuario { get; set; }
        [DataMember]
        public string Asistentes { get; set; }
        [DataMember]
        public string Fecha_reserva { get; set; }
        [DataMember]
        public string Turno { get; set; }
        [DataMember]
        public string Preferencias { get; set; }
    }
}