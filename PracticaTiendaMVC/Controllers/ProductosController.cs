using PracticaTienda.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        // GET: Productos/Create
        public ActionResult Create()
        {
            var images = Directory.GetFiles(Server.MapPath("~/Images"))
                              .Select(Path.GetFileName)
                              .ToList();
            ViewBag.Images = new SelectList(images);
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloProductos producto)
        {
            var images = Directory.GetFiles(Server.MapPath("~/Images"))
                              .Select(Path.GetFileName)
                              .ToList();
            ViewBag.Images = new SelectList(images);
            HttpResponseMessage response = GlobalVariables.WebAPIClient.PostAsJsonAsync("Productos", producto).Result;
            return RedirectToAction("Index");
        }
    }
}