﻿using System;
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
        public int CodigoReserva { get; set; }
        [DataMember]
        public int CodigoUsuario { get; set; }
        [DataMember]
        public int Asistentes { get; set; }
        [DataMember]
        public DateTime Fecha_reserva { get; set; }
        [DataMember]
        public string Turno { get; set; }
        [DataMember]
        public string Preferencias { get; set; }
    }
}