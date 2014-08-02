﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto_REST.Dominio;
using Proyecto_REST.Persistencia;

namespace Proyecto_REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Institucion" in code, svc and config file together.
    public class Institucion : IInstitucion
    {

        InstitucionesDAO dao = new InstitucionesDAO();

        public Instituciones ObtenerInstitucionRuc(string ruc)
        {
          return  dao.ObtenerPorRuc(ruc);
        }

        public Instituciones ObtenerInstitucionRazon(string razon)
        {
            return dao.ObtenerPorRazonsocial(razon);
        }

        public List<Instituciones> ListarInstituciones()
        {
            return dao.ListarInstitucions();
        }
    }
}
