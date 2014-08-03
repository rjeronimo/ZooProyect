using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Proyecto_REST.Dominio
{
     [DataContract]
    public class DuplicadoException
    {
        [DataMember]
        public string DataError { get; set; }
    }
}