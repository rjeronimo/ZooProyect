using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_REST.Dominio;
using System.Data.SqlClient;

namespace Proyecto_REST.Persistencia
{
    public class InstitucionesDAO
    {
        public Instituciones ObtenerPorRuc(string ruc)
        {
            Instituciones institucionencontrada = null;
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
                            institucionencontrada = new Instituciones()
                            {
                                Codigo = int.Parse(resultado["codigo"].ToString()),
                                RUC = resultado["RUC"].ToString(),
                                RazonSocial = resultado["Nombre"].ToString(),

                            };
                        }
                    }
                }
            }
            return institucionencontrada;
        }

        public Instituciones ObtenerPorRazonsocial(string razonSocial)
        {
            Instituciones institucionencontrada = null;
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
                            institucionencontrada = new Instituciones()
                            {
                                Codigo = int.Parse(resultado["codigo"].ToString()),
                                RUC = resultado["RUC"].ToString(),
                                RazonSocial = resultado["Nombre"].ToString(),

                            };
                        }
                    }
                }
            }
            return institucionencontrada;
        }

        public List<Instituciones> ListarInstitucions()
        {
            List<Instituciones> pedidos = new List<Instituciones>();
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
                            pedidos.Add(new Instituciones()
                            {
                                Codigo = int.Parse(resultado["codigo"].ToString()),
                                RUC = resultado["RUC"].ToString(),
                                RazonSocial = resultado["Nombre"].ToString()
                            });
                        }
                    }
                }
            }
            return pedidos;
        }
    }

}