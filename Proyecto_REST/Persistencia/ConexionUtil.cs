using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_REST.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
              //  return "Data Source=(local);Initial Catalog=instituciones;Integrated Security=SSPI;";
                //return "Data Source=(local);Initial Catalog=zoologico;Integrated Security=SSPI;";
                return "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=zoologico";
            }
        }
    }
}