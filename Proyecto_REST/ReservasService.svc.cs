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
    public class ReservasService : IReservasService
    {
        ReservasDAO dao = new ReservasDAO();

        public Reservas CrearReserva(Reservas reserva)
        {
            Reservas resrva = null;

            resrva = dao.Obtener(reserva.CodigoReserva);

            if (resrva != null)
            {
                // validacion duplicado
                throw new FaultException<DuplicadoException>(new DuplicadoException() { DataError = "La reserva ya existe" }, new FaultReason("La reserva ya existe"));
            }
            else
            {
                // validacion no mas de 4 preferencias de zonas 
                string[] reservas = reserva.Preferencias.Split(new Char[] { ','});

                int reservalist = reservas.Count();

                if (reservalist <= 4)
                {
                    return dao.Crear(reserva);
                }
                else
                {
                    throw new FaultException<DuplicadoException>(new DuplicadoException() { DataError = "No puedes ingresar mas de 4 preferencias" }, new FaultReason("No puedes ingresar mas de 4 preferencias"));

                }
            }
        }

        public List<Reservas> ListarReservas()

        {

            return dao.Listar();
        }
    }
    //{
    //    Reservas re = new Reservas();

    //    re.CodigoReserva = "3443";
    //    re.CodigoUsuario = "33";
    //    re.Asistentes = "3";
    //    re.Fecha_reserva = "12-12-2012";
    //    re.Preferencias = "1,2,3,4,5";
    //    re.Turno = "mñn";

    //    CrearReserva(re);
}


