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

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync($"Productos/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var producto = response.Content.ReadAsAsync<ModeloProductos>().Result;
                var images = Directory.GetFiles(Server.MapPath("~/Images"))
                                      .Select(Path.GetFileName)
                                      .ToList();
                ViewBag.Images = new SelectList(images);
                return View(producto);
            }
            return HttpNotFound();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloProductos producto)
        {
            var images = Directory.GetFiles(Server.MapPath("~/Images"))
                                  .Select(Path.GetFileName)
                                  .ToList();
            ViewBag.Images = new SelectList(images);
            HttpResponseMessage response = GlobalVariables.WebAPIClient.PutAsJsonAsync($"Productos/{producto.Id}", producto).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Producto editado exitosamente.";
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync($"Productos/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var producto = response.Content.ReadAsAsync<ModeloProductos>().Result;
                return View(producto);
            }
            return HttpNotFound();
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.DeleteAsync($"Productos/{id}").Result;
            return RedirectToAction("Index");
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync($"Productos/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var producto = response.Content.ReadAsAsync<ModeloProductos>().Result;
                return View(producto);
            }
            return HttpNotFound();
        }
    }
}