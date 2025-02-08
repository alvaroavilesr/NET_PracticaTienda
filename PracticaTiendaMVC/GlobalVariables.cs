using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PracticaTienda
{
    public static class GlobalVariables
    {
        public static HttpClient WebAPIClient = new HttpClient();

        static GlobalVariables()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            WebAPIClient = new HttpClient(handler);

            WebAPIClient.BaseAddress = new Uri("https://localhost:44388/api/");
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}