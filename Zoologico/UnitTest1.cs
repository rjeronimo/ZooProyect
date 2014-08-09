using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zoologico
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {

        // Casos Positivos
        [TestMethod]
        public void listar()
        {
            // 1. Instanciar el objeto a ser probado
            InstitucionesWS.GestionarInstitucionClient proxy = new InstitucionesWS.GestionarInstitucionClient();
            // 2. Invocar el método con los argumentos de prueba

            IList<InstitucionesWS.Institucions> institucions;
            institucions = proxy.ListaInstitucion();

            int total = institucions.Count;

            // 3. Realizar la validación de los criterios de prueba
            Assert.IsNotNull(institucions);
        }

        [TestMethod]
        public void obtenerInstitucionRUC()
        {
            // 1. Instanciar el objeto a ser probado
            InstitucionesWS.GestionarInstitucionClient proxy = new InstitucionesWS.GestionarInstitucionClient();
            // 2. Invocar el método con los argumentos de prueba

            InstitucionesWS.Institucions institucion;

            institucion = proxy.ObtenerInstitucionRUC("3457435673");

            // 3. Realizar la validación de los criterios de prueba
            Assert.AreEqual("LOS PODEROSOS", institucion.Nombre);
        }

        //[TestMethod]
        //public void obtenerInstitucionRazon()
        //{
        //    // 1. Instanciar el objeto a ser probado
        //    InstitucionesWS.GestionarSedeClient proxy = new InstitucionesWS.GestionarSedeClient();
        //    // 2. Invocar el método con los argumentos de prueba

        //    InstitucionesWS.Institucions institucion;

        //    institucion = proxy.ObtenerInstitucionRazon("CON FE Y APRENDES");

        //    // 3. Realizar la validación de los criterios de prueba
        //    Assert.AreEqual("CON FE Y APRENDES", institucion.Nombre);
        //}

   
       
    }

}
