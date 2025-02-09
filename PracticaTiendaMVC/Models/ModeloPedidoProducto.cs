using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaTienda.Models
{
    public class ModeloPedidoProducto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public ModeloProductos Productos { get; set; }
    }
}