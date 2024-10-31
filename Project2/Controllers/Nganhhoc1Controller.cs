using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2.Models;

namespace Project2.Controllers
{
    public class Nganhhoc1Controller : Controller
    {
        private Quanlysinhvienpj2Entities db = new Quanlysinhvienpj2Entities();

        // GET: Nganhhoc1
        public ActionResult Index()
        {
            return View(db.Nganhhoc1.ToList());
        }

        // GET: Nganhhoc1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganhhoc1 nganhhoc1 = db.Nganhhoc1.Find(id);
            if (nganhhoc1 == null)
            {
                return HttpNotFound();
            }
            return View(nganhhoc1);
        }

        // GET: Nganhhoc1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nganhhoc1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nganh,Monhoc")] Nganhhoc1 nganhhoc1)
        {
            if (ModelState.IsValid)
            {
                db.Nganhhoc1.Add(nganhhoc1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nganhhoc1);
        }

        // GET: Nganhhoc1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganhhoc1 nganhhoc1 = db.Nganhhoc1.Find(id);
            if (nganhhoc1 == null)
            {
                return HttpNotFound();
            }
            return View(nganhhoc1);
        }

        // POST: Nganhhoc1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nganh,Monhoc")] Nganhhoc1 nganhhoc1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganhhoc1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nganhhoc1);
        }

        // GET: Nganhhoc1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganhhoc1 nganhhoc1 = db.Nganhhoc1.Find(id);
            if (nganhhoc1 == null)
            {
                return HttpNotFound();
            }
            return View(nganhhoc1);
        }

        // POST: Nganhhoc1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nganhhoc1 nganhhoc1 = db.Nganhhoc1.Find(id);
            db.Nganhhoc1.Remove(nganhhoc1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
