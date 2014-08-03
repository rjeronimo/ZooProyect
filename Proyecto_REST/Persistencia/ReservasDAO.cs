using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Proyecto_REST.Dominio;

namespace Proyecto_REST.Persistencia
{
    public class ReservasDAO
    {

        public Reservas Crear(Reservas reservaARegistrar)
        {
            Reservas reservaRegistrado = null;
            string sql = "INSERT into reservas(codreserva,codpersona,asistentes,fecha_Reserva,turno,preferencia) values(@codreserva,@user,@asistentes,@fecha_reserva,@turno,@preferencia)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {

                    com.Parameters.Add(new SqlParameter("@codreserva", reservaARegistrar.CodigoReserva));
                    com.Parameters.Add(new SqlParameter("@user", reservaARegistrar.CodigoUsuario));
                    com.Parameters.Add(new SqlParameter("@asistentes", reservaARegistrar.Asistentes));
                    com.Parameters.Add(new SqlParameter("@fecha_reserva", reservaARegistrar.Fecha_reserva));
                    com.Parameters.Add(new SqlParameter("@turno", reservaARegistrar.Turno));
                    com.Parameters.Add(new SqlParameter("@preferencia", reservaARegistrar.Preferencias));
                    com.ExecuteNonQuery();
                }
            }
            reservaRegistrado = Obtener(reservaARegistrar.CodigoUsuario); 
           
            return reservaRegistrado;
        }

        public Reservas Actualizar(Reservas reservarAActualizar)
        {
            Reservas presupuestoActualizado = null;
            string sql = "UPDATE reservas SET codpersona=@user, fecha_Reserva=@fecha_reserva, turno = @turno, preferencia = @preferencia WHERE codreserva=@codreserva";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codreserva", reservarAActualizar.CodigoReserva));
                    com.Parameters.Add(new SqlParameter("@user", reservarAActualizar.CodigoUsuario));
                    com.Parameters.Add(new SqlParameter("@asistentes", reservarAActualizar.Asistentes));
                    com.Parameters.Add(new SqlParameter("@fecha_reserva", reservarAActualizar.Fecha_reserva));
                    com.Parameters.Add(new SqlParameter("@turno", reservarAActualizar.Turno));
                    com.Parameters.Add(new SqlParameter("@preferencia", reservarAActualizar.Preferencias));
                    com.ExecuteNonQuery();
                }
            }
            presupuestoActualizado = Obtener(reservarAActualizar.CodigoReserva);
             return presupuestoActualizado;
        }


        public List<Reservas> Listar()
        {
            List<Reservas> items = new List<Reservas>();
            string sql = "SELECT * FROM reservas";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                     using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            items.Add(new Reservas()
                            {
                                CodigoReserva = resultado["codreserva"].ToString(),
                                CodigoUsuario = resultado["codpersona"].ToString(),
                                Asistentes = resultado["asistentes"].ToString(),
                                Fecha_reserva = resultado["fecha_Reserva"].ToString(),
                                Turno = resultado["turno"].ToString(),
                                Preferencias = resultado["preferencia"].ToString()
                            });
                        }
                    }
                }
            }
          return items;
        }

        public Reservas Obtener(string codigo)
        {
            Reservas presupuestoEncontrado = null;
            string sql = "SELECT * FROM reservas WHERE codreserva=@codreserva";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codreserva", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            presupuestoEncontrado = new Reservas()
                            {
                                CodigoReserva = resultado["codreserva"].ToString(),
                                CodigoUsuario = resultado["codpersona"].ToString(),
                                Asistentes = resultado["asistentes"].ToString(),
                                Fecha_reserva = resultado["fecha_Reserva"].ToString(),
                                Turno = resultado["turno"].ToString(),
                                Preferencias = resultado["preferencia"].ToString()
                            };
                        }
                    }
                }
            }

            return presupuestoEncontrado;
        }
    }
}