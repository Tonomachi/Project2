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
    public class SinhviensController : Controller
    {
        private Quanlysinhvienpj2Entities db = new Quanlysinhvienpj2Entities();

        // GET: Sinhviens
        public ActionResult Index()
        {
            var sinhviens = db.Sinhviens.Include(s => s.Nganhhoc1).Include(s => s.Truong);
            return View(sinhviens.ToList());
        }

        // GET: Sinhviens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // GET: Sinhviens/Create
        public ActionResult Create()
        {
            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc");
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong");
            return View();
        }

        // POST: Sinhviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSv,HoSv,TenSv,Diachi,Email,Sdt,NgaySinh,Nganh,Tentruong")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Sinhviens.Add(sinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc", sinhvien.Nganh);
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong", sinhvien.Tentruong);
            return View(sinhvien);
        }

        // GET: Sinhviens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc", sinhvien.Nganh);
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong", sinhvien.Tentruong);
            return View(sinhvien);
        }

        // POST: Sinhviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSv,HoSv,TenSv,Diachi,Email,Sdt,NgaySinh,Nganh,Tentruong")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc", sinhvien.Nganh);
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong", sinhvien.Tentruong);
            return View(sinhvien);
        }

        // GET: Sinhviens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // POST: Sinhviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            db.Sinhviens.Remove(sinhvien);
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
