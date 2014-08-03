using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto.Dominio;

namespace Proyecto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGestionarReserva" in both code and config file together.
    [ServiceContract]
    public interface IGestionarReserva
    {
        [FaultContract(typeof(DataException))]
        [OperationContract]
        int RegistrarReserva(int asistentes, int coduser, DateTime fecha_reserva, string turno, string preferencias);

        [OperationContract]
        Reserva ObtenerReserva(string usuario);

        [OperationContract]
        List<Reserva> ListarReserva();

    }
}
