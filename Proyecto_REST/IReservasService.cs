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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservasService" in both code and config file together.
    [ServiceContract]
    public interface IReservasService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        Reservas CrearReserva(Reservas reserva);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        List<Reservas> ListarReservas(); 
    }
}
