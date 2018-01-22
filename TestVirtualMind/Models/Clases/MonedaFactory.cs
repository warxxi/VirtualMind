using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using TestVirtualMind.Models.Enums;
using TestVirtualMind.Models.Interfaces;

namespace TestVirtualMind.Models.Clases
{
    public static class MonedaFactory
    {
        public static IMoneda Crear(Monedas moneda)
        {
            IMoneda monedaObj = null;

            switch (moneda)
            {
                case Monedas.Pesos:
                    monedaObj = new Pesos();
                    break;
                case Monedas.Real:
                    monedaObj = new Real();
                    break;
                case Monedas.Dolar:
                    monedaObj = new Dolar();
                    break;
            }

            return monedaObj;
        }
    }
}