using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestVirtualMind;
using TestVirtualMind.Controllers;
using System.Net;

namespace TestVirtualMind.Tests.Controllers
{
    [TestClass]
    public class CotizacionControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void PesosTest()
        {
            CotizacionController controller = new CotizacionController();

            try
            {
                IEnumerable<string> result = controller.Get("Pesos");
            }
            catch (HttpResponseException ex)
            {
                // assert
                Assert.AreEqual(HttpStatusCode.Unauthorized, ex.Response.StatusCode);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void RealTest()
        {
            CotizacionController controller = new CotizacionController();

            try
            {
                IEnumerable<string> result = controller.Get("Real");
            }
            catch (HttpResponseException ex)
            {
                // assert
                Assert.AreEqual(HttpStatusCode.Unauthorized, ex.Response.StatusCode);
                throw;
            }
        }

        [TestMethod]
        public void DolarTest()
        {
            CotizacionController controller = new CotizacionController();

            IEnumerable<string> result = controller.Get("Dolar");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void OtroTest()
        {
            CotizacionController controller = new CotizacionController();

            try
            {
                IEnumerable<string> result = controller.Get("Euro");
            }
            catch (HttpResponseException ex)
            {
                // assert
                Assert.AreEqual(HttpStatusCode.ServiceUnavailable, ex.Response.StatusCode);
                throw;
            }
        }
        //[TestMethod]
        //public void GetById()
        //{
        //    // Disponer
        //    CotizacionController controller = new CotizacionController();

        //    // Actuar
        //    string result = controller.Get(5);

        //    // Declarar
        //    Assert.AreEqual("value", result);
        //}

        //[TestMethod]
        //public void Post()
        //{
        //    // Disponer
        //    CotizacionController controller = new CotizacionController();

        //    // Actuar
        //    controller.Post("value");

        //    // Declarar
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Disponer
        //    CotizacionController controller = new CotizacionController();

        //    // Actuar
        //    controller.Put(5, "value");

        //    // Declarar
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Disponer
        //    CotizacionController controller = new CotizacionController();

        //    // Actuar
        //    controller.Delete(5);

        //    // Declarar
        //}
    }
}
