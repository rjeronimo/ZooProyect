using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto.Dominio;

namespace Proyecto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGestionarSede" in both code and config file together.
    [ServiceContract]
    public interface IGestionarInstitucion
    {
        [FaultContract(typeof(DataException))]
        [OperationContract]
        Institucions ObtenerInstitucionRUC(string ruc);

        [OperationContract]
        Institucions ObtenerInstitucionRazon(string razon);

        [OperationContract]
        List<Institucions> ListaInstitucion();

    }
}
