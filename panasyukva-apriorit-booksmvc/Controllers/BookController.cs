using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using panasyukva_apriorit_booksmvc.DomainModel.Domains;
using panasyukva_apriorit_booksmvc.ViewModel;

namespace panasyukva_apriorit_booksmvc.Controllers
{
    public class BookController : Controller
    {
        DomainModelBook model;
        
        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

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
        // GET: /Book/Edit/5

        public ActionResult Edit(int id)
        {
            model = new DomainModelBook();
            return View("_Book", model.GetBook(id));
        }

        //
        // POST: /Book/Edit/5

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
        // GET: /Book/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Book/Delete/5

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
