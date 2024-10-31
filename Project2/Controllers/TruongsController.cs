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
    public class TruongsController : Controller
    {
        private Quanlysinhvienpj2Entities db = new Quanlysinhvienpj2Entities();

        // GET: Truongs
        public ActionResult Index()
        {
            return View(db.Truongs.ToList());
        }

        // GET: Truongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truong truong = db.Truongs.Find(id);
            if (truong == null)
            {
                return HttpNotFound();
            }
            return View(truong);
        }

        // GET: Truongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Truongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tentruong")] Truong truong)
        {
            if (ModelState.IsValid)
            {
                db.Truongs.Add(truong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(truong);
        }

        // GET: Truongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truong truong = db.Truongs.Find(id);
            if (truong == null)
            {
                return HttpNotFound();
            }
            return View(truong);
        }

        // POST: Truongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tentruong")] Truong truong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(truong);
        }

        // GET: Truongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truong truong = db.Truongs.Find(id);
            if (truong == null)
            {
                return HttpNotFound();
            }
            return View(truong);
        }

        // POST: Truongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Truong truong = db.Truongs.Find(id);
            db.Truongs.Remove(truong);
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
