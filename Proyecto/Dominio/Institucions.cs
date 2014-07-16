using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Proyecto.Dominio
{
    [DataContract]
    public class Institucions
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}