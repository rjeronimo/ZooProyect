using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto_REST.Persistencia;
using Proyecto_REST.Dominio;
using System.Messaging;

namespace Proyecto_REST
{
    public class ReservasService : IReservasService
    {
        ReservasDAO dao = new ReservasDAO();

        public Reservas CrearReserva(Reservas reserva)
        {
            Reservas resrva = null;

            /*resrva = dao.Obtener(reserva.codigoReserva);

            if (resrva != null)
            {
                // validacion duplicado
                throw new FaultException<DuplicadoException>(new DuplicadoException() { DataError = "La reserva ya existe" }, new FaultReason("La reserva ya existe"));
            }
            else
            {*/
                // validacion no mas de 4 preferencias de zonas 
                string[] reservas = reserva.preferencias.Split(new Char[] { ','});
                Reservas resrvacreada = new Reservas();
                int reservalist = reservas.Count();

                if (reservalist <= 4)
                {
                    try
                    {
                       
                        resrvacreada = dao.Crear(reserva);
                    }
                    catch (Exception)
                    {
                        
                         MessageQueue colaIn = null;
                        string rutaColaIn = @".\private$\rjeronimo";
                        if (!MessageQueue.Exists(rutaColaIn))
                            MessageQueue.Create(rutaColaIn);

                        colaIn = new MessageQueue(rutaColaIn);

                        Message messajeIn = new Message();
                        messajeIn.Label = "Enviando Cola Reservas";
                        messajeIn.Body = new Reservas() { codigoUsuario = reserva.codigoUsuario, asistentes = reserva.asistentes, fecha_reserva = reserva.fecha_reserva, turno = reserva.turno, preferencias = reserva.preferencias };
                        Reservas reservascola = (Reservas)messajeIn.Body;

                        colaIn.Send(messajeIn);
                    }
                }
                else
                {
                    throw new FaultException<DuplicadoException>(new DuplicadoException() { DataError = "No puedes ingresar mas de 4 preferencias" }, new FaultReason("No puedes ingresar mas de 4 preferencias"));

                }

                return resrvacreada;
        }

        public List<Reservas> ListarReservas()

        {

            string rutaColaIn = @".\private$\rjeronimo";
            if (!MessageQueue.Exists(rutaColaIn))
                MessageQueue.Create(rutaColaIn);

            MessageQueue cola = new MessageQueue(rutaColaIn);

           
            int cantidad = cola.GetAllMessages().Count();

            if (cantidad > 0)
            {
                cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Reservas) });

                Reservas new_colareserva = new Reservas();
                for (int i = 0; i < cantidad; i++)
                {
                    Message mensaje = cola.Receive();
                    Reservas colareservas = (Reservas)mensaje.Body;

                    if (colareservas.codigoUsuario != "")
                    {

                        new_colareserva.codigoUsuario = colareservas.codigoUsuario;
                        new_colareserva.asistentes = colareservas.asistentes;
                        new_colareserva.fecha_reserva = colareservas.fecha_reserva;
                        new_colareserva.turno = colareservas.turno;
                        new_colareserva.preferencias = colareservas.preferencias;

                        dao.Crear(new_colareserva);

                        Proyecto_REST.Persistencia.ReservasDAO.Auditoria auditoria = new Proyecto_REST.Persistencia.ReservasDAO.Auditoria();

                        auditoria.codigoreserva = new_colareserva.codigoReserva.ToString();
                        auditoria.codigousuario = new_colareserva.codigoUsuario;
                        auditoria.fecha = DateTime.Now.ToString();
                        auditoria.asistentes = new_colareserva.asistentes;
                        auditoria.estado = "registrada - vigente";

                        dao.CrearAudtoria(auditoria);
                    }
                    else
                    {
                        // validacion si la reserva no se reserva correctamente 

                        Proyecto_REST.Persistencia.ReservasDAO.Auditoria auditoria = new Proyecto_REST.Persistencia.ReservasDAO.Auditoria();

                        auditoria.codigoreserva = new_colareserva.codigoReserva.ToString();
                        auditoria.codigousuario = new_colareserva.codigoUsuario;
                        auditoria.fecha = DateTime.Now.ToString();
                        auditoria.asistentes = new_colareserva.asistentes;
                        auditoria.estado = "no registrada";

                        dao.CrearAudtoria(auditoria);
                    }
                }
            }

        
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


