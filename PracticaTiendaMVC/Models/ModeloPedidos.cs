using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaTienda.Models
{
    public class ModeloPedidos
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        [Display(Name = "Precio total (€)")]
        public decimal PrecioTotal { get; set; }
        public string Usuario { get; set; }
        public List<ModeloPedidoProducto> PedidoProductos { get; set; }
    }
}