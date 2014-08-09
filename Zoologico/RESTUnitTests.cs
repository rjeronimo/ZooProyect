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
        public void CrearReservaBien()
        {

            // Agrega Pedido bn!
            string reserva = "{\"codigoReserva\":\"0\",\"codigoUsuario\":\"4\",\"asistentes\":\"59\",\"fecha_reserva\":\"12-12-2012\",\"turno\":\"Mañana\",\"preferencias\":\"mamiferos\"}"; 
            byte[] data = Encoding.UTF8.GetBytes(reserva);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:30000/ReservasService.svc/Reservas");
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
                //Assert.AreEqual("4", reservaCreada.CodigoReserva.ToString());
                Assert.AreEqual("59", reservaCreada.Asistentes.ToString());
                 
            }
            catch (WebException e)
            {
                Assert.AreEqual(e.Message.ToString(), "La reserva ya existe");
            }

        }


        [TestMethod]
        public void ListarReserva()
        {
            HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create("http://localhost:30000/ReservasService.svc/Reservas");
            req1.Method = "GET";
            HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string reservasJSON = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            List<Reserva> reservaObtenida = js1.Deserialize<List<Reserva>>(reservasJSON);

            int listavalor = reservaObtenida.Count;

            Assert.AreEqual(6,listavalor);
        }
    }
}
