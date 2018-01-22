using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using TestVirtualMind.Models.Clases;
using TestVirtualMind.Models.Enums;

namespace TestVirtualMind.Controllers
{
    public class CotizacionController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [Route("Cotizacion/{moneda}")]
        public IEnumerable<string> Get(string moneda)
        {
            Monedas monedaEnum;

            try
            {
                monedaEnum=(Monedas)Enum.Parse(typeof(Monedas),moneda);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            

            return MonedaFactory.Crear(monedaEnum).ObtenerCotizacion();
        }

        //// POST api/values
        //public void Post([FromBody]int value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
