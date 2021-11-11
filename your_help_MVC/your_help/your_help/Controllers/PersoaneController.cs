using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace your_help.Controllers
{
    public class PersoaneController : Controller
    {
        // GET: Persoane
        public ActionResult Index()
        {
            return View();
        }

        // GET: Persoane/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Persoane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persoane/Create
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

        // GET: Persoane/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Persoane/Edit/5
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

        // GET: Persoane/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Persoane/Delete/5
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
