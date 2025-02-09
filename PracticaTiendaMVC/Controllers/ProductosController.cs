using Newtonsoft.Json;
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
            IEnumerable<ModeloProductos> productosList = new List<ModeloProductos>();

            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Productos").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                productosList = JsonConvert.DeserializeObject<IEnumerable<ModeloProductos>>(jsonString);
            }

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

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddToCart(int id, List<ModeloProductos> carrito)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync($"Productos/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var producto = response.Content.ReadAsAsync<ModeloProductos>().Result;
                carrito.Add(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult EliminarDelCarrito(int id, List<ModeloProductos> carrito) { 
        
            var producto = carrito.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                carrito.Remove(producto);
            }

            return RedirectToAction("Carrito");
        }

        // GET: Productos/Carrito
        public ActionResult Carrito(List<ModeloProductos> carrito)
        {
            return View(carrito);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult HacerPedido(List<ModeloProductos> carrito)
        {

            var pedido = new ModeloPedidos
            {
                Fecha = DateTime.Now,
                PrecioTotal = carrito.Sum(p => p.Precio ?? 0),
                Usuario = User.Identity.Name,
                PedidoProductos = carrito.Select(p => new ModeloPedidoProducto
                {
                    ProductoId = p.Id,
                    Cantidad = 1,
                    Subtotal = p.Precio ?? 0
                }).ToList()
            };

            HttpResponseMessage response = GlobalVariables.WebAPIClient.PostAsJsonAsync("Pedidos", pedido).Result;
            if (response.IsSuccessStatusCode)
            {
                carrito.Clear();
            }
            return RedirectToAction("Index");
        }
    }
}