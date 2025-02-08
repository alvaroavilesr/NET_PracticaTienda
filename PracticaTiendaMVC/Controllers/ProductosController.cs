using PracticaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PracticaTienda.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            IEnumerable<ModeloProductos> productosList;

            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Productos").Result;
            productosList = response.Content.ReadAsAsync<IEnumerable<ModeloProductos>>().Result;

            return View(productosList);
        }
    }
}