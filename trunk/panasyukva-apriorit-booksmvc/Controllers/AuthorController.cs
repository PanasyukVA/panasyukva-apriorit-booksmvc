using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using panasyukva_apriorit_booksmvc.DomainModel.Domains;

namespace panasyukva_apriorit_booksmvc.Controllers
{
    public class AuthorController : Controller
    {
        DomainModelAuthor model;

        //
        // GET: /Author/

        public string Index()
        {
            return "this is a author";
        }

        //
        // GET: /Author/Details/5

        public ActionResult Details(int id)
        {
            model = new DomainModelAuthor();
            return View(model.GetAuthor(id));
        }

        //
        // GET: /Author/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Author/Create

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
        // GET: /Author/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Author/Edit/5

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
        // GET: /Author/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Author/Delete/5

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
