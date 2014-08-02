using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Proyecto_REST.Dominio
{
    [DataContract]
    public class Instituciones
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
    }
}