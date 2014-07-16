using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Dominio;
using System.Data.SqlClient;

namespace Proyecto.Persistencia
{
    public class InstitucionDAO 

    {

        public Institucions ObtenerPorRuc(string ruc)
        {
            Institucions institucionencontrada = null;
            string sql = "SELECT * FROM institucion WHERE RUC=@ruc";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ruc", ruc));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            institucionencontrada = new Institucions()
                            {
                                Codigo = int.Parse(resultado["codigo"].ToString()),
                                RUC = resultado["RUC"].ToString(),
                                Nombre = resultado["Nombre"].ToString(),
                                
                            };
                        }
                    }
                }
            }
            return institucionencontrada;
        }

        public Institucions ObtenerPorRazonsocial(string razonSocial)
        {
            Institucions institucionencontrada = null;
            string sql = "SELECT * FROM institucion WHERE Nombre=@razon";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@razon", razonSocial));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            institucionencontrada = new Institucions()
                            {
                                Codigo = int.Parse(resultado["codigo"].ToString()),
                                RUC = resultado["RUC"].ToString(),
                                Nombre = resultado["Nombre"].ToString(),

                            };
                        }
                    }
                }
            }
            return institucionencontrada;
        }

        public List<Institucions> ListarInstitucions()
        {
            List<Institucions> pedidos = new List<Institucions>();
            string sql = "SELECT * FROM institucion";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            pedidos.Add(new Institucions()
                            {
                                Codigo = int.Parse(resultado["codigo"].ToString()),
                                RUC = resultado["RUC"].ToString(),
                                Nombre = resultado["Nombre"].ToString()
                            });
                        }
                    }
                }
            }
            return pedidos;
        }
    }
}