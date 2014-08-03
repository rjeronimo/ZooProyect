using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto.Dominio;
using Proyecto.Persistencia;

namespace Proyecto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GestionarReserva" in code, svc and config file together.
    public class GestionarReserva : IGestionarReserva
    {

        private ReservaDAO dao = new ReservaDAO();
       
        public int RegistrarReserva(int asistentes, int coduser, DateTime fecha_reserva, string turno, string preferencias)
        {
 
             int ingreso;

             ingreso= dao.RegistrarReserva(coduser, asistentes, fecha_reserva, turno, preferencias);


             return ingreso;

        }

        public Reserva  ObtenerReserva(string usuario)
        {
 	        throw new NotImplementedException();
        }

        public List<Reserva>  ListarReserva()
        {
 	        throw new NotImplementedException();
        }
        }

        
    }
 