using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Proyecto_REST.Dominio;
using MySql.Data.MySqlClient;

namespace Proyecto_REST.Persistencia
{
    public class ReservasDAO
    {
        MySqlConnection connection;

        public Reservas Crear(Reservas reservaARegistrar)
        {
            Reservas reservaRegistrado = null;
            string sql = "INSERT into reservas(codreserva,codpersona,asistentes,fecha_Reserva,turno,preferencia) values(null,@user,@asistentes,@fecha_reserva,@turno,@preferencia)";
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);
            int codigoRespuesta = 0;
            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))

                {

                    //com.Parameters.Add(new MySqlParameter("@codreserva", reservaARegistrar.codigoReserva));
                    com.Parameters.Add(new MySqlParameter("@user", reservaARegistrar.codigoUsuario));
                    com.Parameters.Add(new MySqlParameter("@asistentes", reservaARegistrar.asistentes));
                    com.Parameters.Add(new MySqlParameter("@fecha_reserva", reservaARegistrar.fecha_reserva));
                    com.Parameters.Add(new MySqlParameter("@turno", reservaARegistrar.turno));
                    com.Parameters.Add(new MySqlParameter("@preferencia", reservaARegistrar.preferencias));
                    codigoRespuesta = com.ExecuteNonQuery();
                    reservaARegistrar.codigoReserva = codigoRespuesta;
                }
            }
            reservaRegistrado = reservaARegistrar; 
           
            return reservaRegistrado;
        }

        public Reservas Actualizar(Reservas reservarAActualizar)
        {
            Reservas presupuestoActualizado = null;
            string sql = "UPDATE reservas SET codpersona=@user, fecha_Reserva=@fecha_reserva, turno = @turno, preferencia = @preferencia WHERE codreserva=@codreserva";
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);

            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.Add(new MySqlParameter("@codreserva", reservarAActualizar.codigoReserva));
                    com.Parameters.Add(new MySqlParameter("@user", reservarAActualizar.codigoUsuario));
                    com.Parameters.Add(new MySqlParameter("@asistentes", reservarAActualizar.asistentes));
                    com.Parameters.Add(new MySqlParameter("@fecha_reserva", reservarAActualizar.fecha_reserva));
                    com.Parameters.Add(new MySqlParameter("@turno", reservarAActualizar.turno));
                    com.Parameters.Add(new MySqlParameter("@preferencia", reservarAActualizar.preferencias));
                    com.ExecuteNonQuery();
                }
            }
            presupuestoActualizado = Obtener(reservarAActualizar.codigoReserva);
             return presupuestoActualizado;
        }


        public List<Reservas> Listar()
        {
            List<Reservas> items = new List<Reservas>();
            string sql = "SELECT * FROM reservas";
            
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);

            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                     using (MySqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            items.Add(new Reservas()
                            {
                                codigoReserva = Convert.ToInt32(resultado["codreserva"].ToString()),
                                codigoUsuario = resultado["codpersona"].ToString(),
                                asistentes = resultado["asistentes"].ToString(),
                                fecha_reserva = resultado["fecha_reserva"].ToString(),
                                turno = resultado["turno"].ToString(),
                                preferencias = resultado["preferencia"].ToString()
                            });
                        }
                    }
                }
            }
          return items;
        }

        public Reservas Obtener(int codigo)
        {
            Reservas presupuestoEncontrado = null;
            string sql = "SELECT * FROM reservas WHERE codreserva=@codreserva";
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);

            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.Add(new MySqlParameter("@codreserva", codigo));
                    using (MySqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            presupuestoEncontrado = new Reservas()
                            {
                                codigoReserva = Convert.ToInt32(resultado["codreserva"].ToString()),
                                codigoUsuario = resultado["codpersona"].ToString(),
                                asistentes = resultado["asistentes"].ToString(),
                                fecha_reserva = resultado["fecha_Reserva"].ToString(),
                                turno = resultado["turno"].ToString(),
                                preferencias = resultado["preferencia"].ToString()
                            };
                        }
                    }
                }
            }

            return presupuestoEncontrado;
        }
    
    
      // Clase Auditoria !! 

        public class Auditoria
        {
            public string codigoreserva { get; set; }
            public string codigousuario { get; set; }
            public string fecha { get; set; }
            public string asistentes { get; set; }
            public string estado { get; set; }
        }

        public Auditoria CrearAudtoria(Auditoria auditoriaARegistrar)
        {
            Auditoria auditoriaRegistrado = null;
            string sql = "INSERT into auditoria(codigoreserva,codigousuario,fecha,asistentes,estado)values(@codigoreserva,@codigousuario,@fecha,@asistentes,@estado)";
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);
            int codigoRespuesta = 0;
            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.Add(new MySqlParameter("@codigoreserva", auditoriaARegistrar.codigoreserva));
                    com.Parameters.Add(new MySqlParameter("@codigousuario", auditoriaARegistrar.codigousuario));
                    com.Parameters.Add(new MySqlParameter("@fecha", auditoriaARegistrar.fecha));
                    com.Parameters.Add(new MySqlParameter("@asistentes", auditoriaARegistrar.asistentes));
                    com.Parameters.Add(new MySqlParameter("@estado", auditoriaARegistrar.estado));
                    codigoRespuesta = com.ExecuteNonQuery();

                    auditoriaARegistrar.codigoreserva = codigoRespuesta.ToString();
                }
            }

            auditoriaRegistrado = auditoriaARegistrar;
            return auditoriaRegistrado;
        }
    }
}