using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto_REST.Persistencia;
using Proyecto_REST.Dominio;

namespace Proyecto_REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservasService" in code, svc and config file together.
    public class ReservasService : IReservasService
    {
        ReservasDAO dao = new ReservasDAO();

        public Reservas CrearReserva(Reservas reserva)
        {
            return dao.Crear(reserva);
        }

        public List<Reservas> ListarReservas()
        {
            return dao.Listar();
        }
    }
}
