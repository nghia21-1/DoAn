using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnChuyenNganhBookingHotel.Models.DB;

namespace DoAnChuyenNganhBookingHotel.Controllers
{
    public class PhongController : Controller
    {
        private QuanLyKhachSanModel db = new QuanLyKhachSanModel();
        // GET: Phong

        public ActionResult Index()
        {
            var phongs = db.Phongs.Include(t => t.TrangThaiPhong).Include(t => t.TheLoaiPhong);
            return View(phongs.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        public ActionResult Create()
        {
            ViewBag.trangthaiphong_id = new SelectList(db.TrangThaiPhongs, "trangthaiphong_id", "trangthaiphong");
            ViewBag.theloaiphong_id = new SelectList(db.TheLoaiPhongs, "theloaiphong_id", "tenphong");
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phong_id,sophong,theloaiphong_id,trangthaiphong_id")] Phong phong)
        {
            if (ModelState.IsValid)
            {
              

                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.trangthaiphong_id = new SelectList(db.TrangThaiPhongs, "trangthaiphong_id", "trangthaiphong",phong.trangthaiphong_id);
            ViewBag.theloaiphong_id = new SelectList(db.TheLoaiPhongs, "theloaiphong_id", "tenphong");
            return View(phong);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong= db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.trangthaiphong_id = new SelectList(db.TrangThaiPhongs, "trangthaiphong_id", "trangthaiphong", phong.trangthaiphong_id);
            ViewBag.theloaiphong_id= new SelectList(db.TheLoaiPhongs, "theloaiphong_id", "sophong", phong.theloaiphong_id);
            return View(phong);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phong_id,sophongtheloaiphong_id,trangthaiphong_id")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trangthaiphong_id = new SelectList(db.TrangThaiPhongs, "trangthaiphong_id", "trangthaiphong", phong.trangthaiphong_id);
            ViewBag.theloaiphong_id = new SelectList(db.TheLoaiPhongs, "theloaiphong_id", "sophong", phong.theloaiphong_id);
            return View(phong);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
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
