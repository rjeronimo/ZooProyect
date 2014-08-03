using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Proyecto.Dominio
{
    [DataContract]
    public class Auditoria
    {
        [DataMember]
        public int CodigoAuditoria { get; set; }
        [DataMember]
        public int Codpersona { get; set; }
        [DataMember]
        public int Codreserva { get; set; }
        [DataMember]
        public DateTime Fecha_auditoria { get; set; }
    }
}