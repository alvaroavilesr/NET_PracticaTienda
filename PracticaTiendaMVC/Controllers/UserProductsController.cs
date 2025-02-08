using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaTienda.Controllers
{
    public class UserProductsController : Controller
    {
        // GET: UserProducts
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserProducts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProducts/Create
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

        // GET: UserProducts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProducts/Edit/5
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

        // GET: UserProducts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProducts/Delete/5
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
