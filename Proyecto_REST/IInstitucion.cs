using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto_REST.Dominio;
using System.ServiceModel.Web;

namespace Proyecto_REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInstitucion" in both code and config file together.
    [ServiceContract]
    public interface IInstitucion
    {
        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="Instituciones/{ruc}",ResponseFormat=WebMessageFormat.Json)]
        Instituciones ObtenerInstitucionRuc(string ruc);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "InstitucionesRazon/{razon}", ResponseFormat = WebMessageFormat.Json)]
        Instituciones ObtenerInstitucionRazon(string razon);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Instituciones", ResponseFormat = WebMessageFormat.Json)]
        List<Instituciones> ListarInstituciones();
    }
}
