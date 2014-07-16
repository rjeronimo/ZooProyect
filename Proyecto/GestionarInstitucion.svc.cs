using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proyecto.Dominio;
using Proyecto.Persistencia;

namespace Proyecto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GestionarSede" in code, svc and config file together.
    public class GestionarSede : IGestionarSede
    {

        private InstitucionDAO dao = new InstitucionDAO();
        public Institucions ObtenerInstitucionRUC(string ruc)
        {
            Institucions institucionRUC = null;
            
            institucionRUC = dao.ObtenerPorRuc(ruc);
            if (institucionRUC != null)
            {
                return institucionRUC;
            }
            else
            {
                throw new FaultException<DataException>(new DataException() { DataError = "La institucion con el RUC ingresado no existe" }, new FaultReason("Validation Failed"));
               
            }
            
        }

        public Institucions ObtenerInstitucionRazon(string razon)
        {
            Institucions institucionRazon = null;
            institucionRazon = dao.ObtenerPorRazonsocial(razon);

            if (institucionRazon != null)
            {
                return institucionRazon;         
            }
            else
            {

              throw new FaultException<DataException>(new DataException() { DataError = "La institucion con la Razon Social ingresad no existe" }, new FaultReason("Validation Failed"));
                
            }
             
        }


        public List<Institucions> ListaInstitucion()
        {

            return dao.ListarInstitucions();
        }
    }
}
