using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Dominio;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Proyecto.Persistencia
{
    public class ReservaDAO
    {
        public int RegistrarReserva(int coduser, int asistentes, DateTime fecha_reserva, string turno, string preferencias)
        {
            Reserva new_reserva = null;
            SqlCommand com;
            SqlDataReader miReader;
            int resrva;

            string sql = "INSERT into reservas(codpersona,asistentes,fecha_Reserva,turno,preferencia) values(@user,@asistentes,@fecha_reserva,@turno,@preferencia) " +
                "SELECT SCOPE_IDENTITY()";

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();

                com = con.CreateCommand();
                com.CommandText = sql;

                com.Parameters.Add(new SqlParameter("@user", coduser));
                com.Parameters.Add(new SqlParameter("@asistentes", asistentes));
                com.Parameters.Add(new SqlParameter("@fecha_reserva", fecha_reserva));
                com.Parameters.Add(new SqlParameter("@turno", turno));
                com.Parameters.Add(new SqlParameter("@preferencia", preferencias));
                
                resrva = (int)(decimal)com.ExecuteScalar();

            }
            return resrva;         
                
            }
  
        public Reserva ObtenerReservaUsuario(int usuario)
        {
            Reserva reservaencontrada  = null;
            string sql = "SELECT r.codreserva FROM reservas r inner join usuario u on r.codpersona = u.cod_user where u.usuario = @usuario";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@usuario", usuario));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            reservaencontrada = new Reserva()
                            {
                                CodigoReserva = int.Parse(resultado["codreserva"].ToString()),
                                CodigoUsuario = int.Parse(resultado["codpersona"].ToString()),
                                Asistentes = int.Parse(resultado["asistentes"].ToString()),
                                Fecha_reserva = DateTime.Parse(resultado["fecha_Reserva"].ToString()),
                                Turno = resultado["turno"].ToString(),
                                Preferencias = resultado["preferencia"].ToString()
                                
                            };
                        }
                    }
                }
            }

            return reservaencontrada;
        }

        public List<Reserva> ListarReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            string sql = "SELECT * FROM reserva";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            reservas.Add(new Reserva()
                            {
                                CodigoReserva = int.Parse(resultado["codreserva"].ToString()),
                                CodigoUsuario = int.Parse(resultado["codpersona"].ToString()),
                                Asistentes = int.Parse(resultado["asistentes"].ToString()),
                                Fecha_reserva = DateTime.Parse(resultado["fecha_Reserva"].ToString()),
                                Turno = resultado["turno"].ToString(),
                                Preferencias = resultado["preferencia"].ToString()
                            });
                        }
                    }
                }
            }
            return reservas;
        }

        public Auditoria RegistrarAuditoria(int codpersona, int codreserva, DateTime fecha_auditoria)
        {
            Auditoria newauditoria = null;

            string auditoria = "INSERT into auditoria(codpersona,codreserva,fecha) values (@codpersona,@codreserva,@fecha)";

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(auditoria, con))
                {
                    com.Parameters.Add(new SqlParameter("@codpersona", codpersona));
                    com.Parameters.Add(new SqlParameter("@codreserva", codreserva));
                    com.Parameters.Add(new SqlParameter("@fecha", fecha_auditoria));
           
                    using (SqlDataReader results = com.ExecuteReader())
                    {
                        if (results.Read())
                        {

                            newauditoria = new Auditoria()
                            {
                                CodigoAuditoria = int.Parse(results["codauditoria"].ToString()),
                                Codpersona = int.Parse(results["codpersona"].ToString()),
                                Codreserva = int.Parse(results["codreserva"].ToString()),
                                Fecha_auditoria = DateTime.Parse(results["fecha"].ToString())

                            };
     
                        }
                    }

                }
            }
            return newauditoria;
        }

    }
}