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
    public class lophocsController : Controller
    {
        private Quanlysinhvienpj2Entities db = new Quanlysinhvienpj2Entities();

        // GET: lophocs
        public ActionResult Index()
        {
            var lophocs = db.lophocs.Include(l => l.Giangvien).Include(l => l.Sinhvien);
            return View(lophocs.ToList());
        }

        // GET: lophocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lophoc lophoc = db.lophocs.Find(id);
            if (lophoc == null)
            {
                return HttpNotFound();
            }
            return View(lophoc);
        }

        // GET: lophocs/Create
        public ActionResult Create()
        {
            ViewBag.MaGv = new SelectList(db.Giangviens, "MaGv", "HoGv");
            ViewBag.MaSv = new SelectList(db.Sinhviens, "MaSv", "HoSv");
            return View();
        }

        // POST: lophocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Malop,MaGv,MaSv,Monhoc")] lophoc lophoc)
        {
            if (ModelState.IsValid)
            {
                db.lophocs.Add(lophoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGv = new SelectList(db.Giangviens, "MaGv", "HoGv", lophoc.MaGv);
            ViewBag.MaSv = new SelectList(db.Sinhviens, "MaSv", "HoSv", lophoc.MaSv);
            return View(lophoc);
        }

        // GET: lophocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lophoc lophoc = db.lophocs.Find(id);
            if (lophoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGv = new SelectList(db.Giangviens, "MaGv", "HoGv", lophoc.MaGv);
            ViewBag.MaSv = new SelectList(db.Sinhviens, "MaSv", "HoSv", lophoc.MaSv);
            return View(lophoc);
        }

        // POST: lophocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Malop,MaGv,MaSv,Monhoc")] lophoc lophoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lophoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGv = new SelectList(db.Giangviens, "MaGv", "HoGv", lophoc.MaGv);
            ViewBag.MaSv = new SelectList(db.Sinhviens, "MaSv", "HoSv", lophoc.MaSv);
            return View(lophoc);
        }

        // GET: lophocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lophoc lophoc = db.lophocs.Find(id);
            if (lophoc == null)
            {
                return HttpNotFound();
            }
            return View(lophoc);
        }

        // POST: lophocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lophoc lophoc = db.lophocs.Find(id);
            db.lophocs.Remove(lophoc);
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
