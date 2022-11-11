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
    public class TheLoaiPhongController : Controller
    {
        private QuanLyKhachSanModel db = new QuanLyKhachSanModel();
        // GET: TheLoaiPhong
        public ActionResult Index()
        {
            return View(db.TheLoaiPhongs.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoaiPhong theLoaiPhong = db.TheLoaiPhongs.Find(id);
            if (theLoaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(theLoaiPhong);
        }
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "theloaiphong_id,tenphong,mota,giaphong,succhua")] TheLoaiPhong theLoaiPhong)
        {
            if (ModelState.IsValid)
            {
                
                db.TheLoaiPhongs.Add(theLoaiPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theLoaiPhong);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoaiPhong theLoaiPhong = db.TheLoaiPhongs.Find(id);
            if (theLoaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(theLoaiPhong);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "theloaiphong_id,tenphong,mota,giaphong,succhua")] TheLoaiPhong theLoaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theLoaiPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theLoaiPhong);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoaiPhong theLoaiPhong = db.TheLoaiPhongs.Find(id);
            if (theLoaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(theLoaiPhong);
        }
     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheLoaiPhong theLoaiPhong = db.TheLoaiPhongs.Find(id);
            db.TheLoaiPhongs.Remove(theLoaiPhong);
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