using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using TestVirtualMind.Models.Interfaces;

namespace TestVirtualMind.Models.Clases
{
    public class Pesos:IMoneda
    {
        public string[] ObtenerCotizacion()
        {
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}