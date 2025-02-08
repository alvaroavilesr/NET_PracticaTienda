using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaTienda.Models
{
    public class ModeloProductos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> CantidadDisponible { get; set; }
        public string ImagenAsociada { get; set; }
        public Nullable<decimal> Precio { get; set; }
    }
}