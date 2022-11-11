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
    
    public class DatPhongController : Controller
    {

        private QuanLyKhachSanModel db = new QuanLyKhachSanModel();

        // GET: DatPhong
        public ActionResult Index()
        {
            var datPhongs= db.DatPhongs.Include(t => t.Phong).Include(t => t.HinhThucThanhToan);
            return View(datPhongs.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatPhong datPhong= db.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return HttpNotFound();
            }
            return View(datPhong);
        }
        public ActionResult Create()
        {
            ViewBag.assigned_room = new SelectList(db.Phongs, "phong_id", "sophong");
            ViewBag.payment_type = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Phong_id,tenphong,diachi,email,sdt,ngaydacphong,ngaytraphong,thanhtoan,phongchidinh,succhua")] DatPhong datPhong)
        {
            if (ModelState.IsValid)
            {
                db.DatPhongs.Add(datPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.assigned_room = new SelectList(db.Phongs, "phong_id", "sophong", datPhong.phongchidinh);
            ViewBag.payment_type = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan", datPhong.thanhtoan);
            return View(datPhong);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatPhong datPhong = db.DatPhongs.Find(id);
            if ( datPhong== null)
            {
                return HttpNotFound();
            }
            ViewBag.assigned_room = new SelectList(db.Phongs, "phong_id", "sophong", datPhong.phongchidinh);
            ViewBag.payment_type = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan", datPhong.thanhtoan);
            return View(datPhong);
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phong_id,tenphong,diachi,email,sdt,ngaydacphong,ngaytraphong,thanhtoan,phongchidinh,succhua")] DatPhong datPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.assigned_room = new SelectList(db.Phongs, "phong_id", "sophong", datPhong.phongchidinh);
            ViewBag.payment_type = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan", datPhong.thanhtoan);
            return View(datPhong);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatPhong datPhong = db.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return HttpNotFound();
            }
            return View(datPhong);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatPhong datPhong= db.DatPhongs.Find(id);
            db.DatPhongs.Remove(datPhong);
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