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
    public class GiangviensController : Controller
    {
        private Quanlysinhvienpj2Entities db = new Quanlysinhvienpj2Entities();

        // GET: Giangviens
        public ActionResult Index()
        {
            var giangviens = db.Giangviens.Include(g => g.Nganhhoc1).Include(g => g.Truong);
            return View(giangviens.ToList());
        }

        // GET: Giangviens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // GET: Giangviens/Create
        public ActionResult Create()
        {
            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc");
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong");
            return View();
        }

        // POST: Giangviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGv,HoGv,TenGv,DiaChi,Email,Sdt,Bangcap,Nganh,Namsinh,Tentruong")] Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Giangviens.Add(giangvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc", giangvien.Nganh);
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong", giangvien.Tentruong);
            return View(giangvien);
        }

        // GET: Giangviens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc", giangvien.Nganh);
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong", giangvien.Tentruong);
            return View(giangvien);
        }

        // POST: Giangviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGv,HoGv,TenGv,DiaChi,Email,Sdt,Bangcap,Nganh,Namsinh,Tentruong")] Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nganh = new SelectList(db.Nganhhoc1, "Nganh", "Monhoc", giangvien.Nganh);
            ViewBag.Tentruong = new SelectList(db.Truongs, "Tentruong", "Tentruong", giangvien.Tentruong);
            return View(giangvien);
        }

        // GET: Giangviens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // POST: Giangviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Giangvien giangvien = db.Giangviens.Find(id);
            db.Giangviens.Remove(giangvien);
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
