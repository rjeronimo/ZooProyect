using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Proyecto.Dominio
{
    [DataContract]
    public class DataException
    {
        [DataMember]
        public string DataError { get; set; }
    }
}