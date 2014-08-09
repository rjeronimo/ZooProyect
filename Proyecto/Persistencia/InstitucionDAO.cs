using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.Dominio;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Proyecto.Persistencia
{
    public class InstitucionDAO 

    {
        private MySqlConnection con;

        public Institucions ObtenerPorRuc(string ruc)
        {
            Institucions institucionencontrada = null;
            string sql = "SELECT * FROM institucion WHERE RUC=@ruc";
            if (con == null)
                con = new MySqlConnection(ConexionUtil.Cadena);
            using (con)
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@ruc", ruc));
                    using (MySqlDataReader resultado = com.ExecuteReader())
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
            if (con == null)
                con = new MySqlConnection(ConexionUtil.Cadena);
            using (con)
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@razon", razonSocial));
                    using (MySqlDataReader resultado = com.ExecuteReader())
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
            if (con == null)
                con = new MySqlConnection(ConexionUtil.Cadena);
            using (con)
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader resultado = com.ExecuteReader())
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