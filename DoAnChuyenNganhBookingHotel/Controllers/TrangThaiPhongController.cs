using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using System.Data.Entity;
using DoAnChuyenNganhBookingHotel.Models.DB;

namespace DoAnChuyenNganhBookingHotel.Controllers
{
    public class TrangThaiPhongController : Controller
    {
        private QuanLyKhachSanModel db = new QuanLyKhachSanModel();
       
        public ActionResult Index()
        {
            return View(db.TrangThaiPhongs.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThaiPhong trangThaiPhong = db.TrangThaiPhongs.Find(id);
            if (trangThaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(trangThaiPhong);
        }
        public ActionResult Create()
        {
            return View();
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trangthaiphong_id,trangthaiphong")] TrangThaiPhong trangThaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.TrangThaiPhongs.Add(trangThaiPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trangThaiPhong);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThaiPhong trangThaiPhong = db.TrangThaiPhongs.Find(id);
            if (trangThaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(trangThaiPhong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trangthaiphong_id,trangthaiphong")] TrangThaiPhong trangThaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trangThaiPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trangThaiPhong);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThaiPhong trangThaiPhong = db.TrangThaiPhongs.Find(id);
            if (trangThaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(trangThaiPhong);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrangThaiPhong trangThaiPhong = db.TrangThaiPhongs.Find(id);
            db.TrangThaiPhongs.Remove(trangThaiPhong);
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