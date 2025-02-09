using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaTienda.Models
{
    public class CarritoModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            List<ModeloProductos> carrito =
               (List<ModeloProductos>)controllerContext.HttpContext
                                           .Session["carrito"];
            if (carrito == null)
            {
                carrito = new List<ModeloProductos>();
                controllerContext.HttpContext
                                .Session["carrito"] = carrito;
            }

            return carrito;
        }
    }
}