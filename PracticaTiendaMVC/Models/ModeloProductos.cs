using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaTienda.Models
{
    public class ModeloProductos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Cantidad Disponible")]
        public Nullable<int> CantidadDisponible { get; set; }
        [Display(Name = "Imagen Asociada")]
        public string ImagenAsociada { get; set; }
        [Display(Name = "Precio (€)")]
        public Nullable<decimal> Precio { get; set; }
    }
}