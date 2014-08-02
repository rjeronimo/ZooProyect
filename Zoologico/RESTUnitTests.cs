using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace Zoologico
{
    [TestClass]
    public class RESTUnitTests
    {
        [TestMethod]
        public void ListarReserva()
        {
            HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create("http://localhost:8539/ReservasService.svc/Reservas");
            req1.Method = "GET";
            HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string reservasJSON = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            List<Reserva> reservaObtenida = js1.Deserialize<List<Reserva>>(reservasJSON);

            int listavalor = reservaObtenida.Count;

            Assert.AreEqual(3, listavalor);
        }
        [TestMethod]

        public void CrearReserva()
        {

            string presupuestoData = "{\"CodigoReserva\":\"5\",\"CodigoUsuario\":\"4\",\"Asistentes\":\"59\",\"Fecha_reserva\":\"12-12-2012\",\"Turno\":\"Mañana\",\"Preferencias\":\"mamiferos\"}";
            byte[] data = Encoding.UTF8.GetBytes(presupuestoData);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:8539/ReservasService.svc/Reservas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Reserva reservaCreada = js.Deserialize<Reserva>(reservaJson);
                Assert.AreEqual("5", reservaCreada.CodigoReserva);
                Assert.AreEqual("4", reservaCreada.CodigoUsuario);
                Assert.AreEqual("59", reservaCreada.Asistentes);
                Assert.AreEqual("12-12-2012", reservaCreada.Fecha_reserva);
                Assert.AreEqual("Mañana", reservaCreada.Turno);
                Assert.AreEqual("mamiferos", reservaCreada.Preferencias);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No se creo la reserva, =(", mensaje);
            }

        }
    }
}
