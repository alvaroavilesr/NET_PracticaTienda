using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaTienda.Controllers
{
    public class PublicProductsController : Controller
    {
        // GET: PublicProducts
        public ActionResult Index()
        {
            return View();
        }

        // GET: PublicProducts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublicProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicProducts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicProducts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublicProducts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicProducts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicProducts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
