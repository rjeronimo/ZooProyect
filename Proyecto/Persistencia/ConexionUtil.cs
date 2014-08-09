using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                //return "Data Source=(local);Initial Catalog=instituciones;Integrated Security=true;";
                return "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=instituciones";
            }
        }
    }
}