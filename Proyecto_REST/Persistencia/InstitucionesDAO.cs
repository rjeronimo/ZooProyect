using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_REST.Dominio;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Proyecto_REST.Persistencia
{
    public class InstitucionesDAO
    {
        MySqlConnection connection;
        public Instituciones ObtenerPorRuc(string ruc)
        {
            Instituciones institucionencontrada = null;
            string sql = "SELECT * FROM institucion WHERE RUC=@ruc";
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);
            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.Add(new MySqlParameter("@ruc", ruc));
                    using (MySqlDataReader resultado = com.ExecuteReader())
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
            if (connection == null)
                connection = new MySqlConnection(ConexionUtil.Cadena);
            using (connection)
            {
                connection.Open();
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.Add(new MySqlParameter("@razon", razonSocial));
                    using (MySqlDataReader resultado = com.ExecuteReader())
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