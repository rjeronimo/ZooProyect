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
    [ServiceContract]
    public interface IInstitucion
    {
        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="Instituciones/{ruc}",ResponseFormat=WebMessageFormat.Json)]
        Instituciones ObtenerInstitucionRuc(string ruc);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Instituciones", ResponseFormat = WebMessageFormat.Json)]
        List<Instituciones> ListarInstituciones();
    }
}
