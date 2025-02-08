using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaTienda.Controllers
{
    public class AdminProductsController : Controller
    {
        // GET: AdminProducts
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminProducts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminProducts/Create
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

        // GET: AdminProducts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminProducts/Edit/5
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

        // GET: AdminProducts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminProducts/Delete/5
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
