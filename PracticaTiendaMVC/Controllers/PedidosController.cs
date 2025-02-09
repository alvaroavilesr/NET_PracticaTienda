using Newtonsoft.Json;
using PracticaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticaTienda.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public async Task<ActionResult> Index()
        {
            IEnumerable<ModeloPedidos> pedidosList = new List<ModeloPedidos>();

            HttpResponseMessage response = await GlobalVariables.WebAPIClient.GetAsync("Pedidos");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                pedidosList = JsonConvert.DeserializeObject<IEnumerable<ModeloPedidos>>(jsonString);
            }

            return View(pedidosList);
        }

        public async Task<ActionResult> Details(int id)
        {
            ModeloPedidos pedido = null;

            HttpResponseMessage response = await GlobalVariables.WebAPIClient.GetAsync($"Pedidos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                pedido = JsonConvert.DeserializeObject<ModeloPedidos>(jsonString);
            }

            if (pedido == null)
            {
                return HttpNotFound();
            }

            return View(pedido);
        }
    }
}