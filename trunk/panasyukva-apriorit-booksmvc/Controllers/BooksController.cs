using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using panasyukva_apriorit_booksmvc.DomainModel.Domains;

namespace panasyukva_apriorit_booksmvc.Controllers
{
    public class BooksController : Controller
    {
        DomainModelBooks model;

        //
        // GET: /Books/

        public ActionResult Index()
        {
            model = new DomainModelBooks();
            return View(model);
        }

        //
        // GET: /Books/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create

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

        //
        // GET: /Books/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Books/Edit/5

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

        //
        // GET: /Books/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Books/Delete/5

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
