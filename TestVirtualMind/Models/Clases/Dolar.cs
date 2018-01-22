using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestVirtualMind.Models.Interfaces;

namespace TestVirtualMind.Models.Clases
{
    public class Dolar:IMoneda
    {
        public string[] ObtenerCotizacion()
        {
            return this.ObtenerCotizacionExterno("https://www.bancoprovincia.com.ar/Principal/Dolar").Result;

        }

        async Task<string[]> ObtenerCotizacionExterno(string url)
        {
            Uri uriUrl = new Uri("https://www.bancoprovincia.com.ar/Principal/Dolar");
            HttpClient client = new HttpClient();
            client.BaseAddress = uriUrl;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string[] product = new string[0];
            HttpResponseMessage response = client.GetAsync(uriUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<string[]>();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            return product;
        }
    }
}