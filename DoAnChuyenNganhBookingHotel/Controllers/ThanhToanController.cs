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
    public class ThanhToanController : Controller
    {
        private QuanLyKhachSanModel db = new QuanLyKhachSanModel();
       
        public ActionResult Index()
        {
            var ThanhToan = db.ThanhToans.Include(t => t.HinhThucThanhToan);
            return View(ThanhToan.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }
        public ActionResult Create()
        {
            ViewBag.thanhtoan_id = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "thanhtoan_id,datphong_id,hinhthucthanhtoan_id,sotienthanhtoan,")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.ThanhToans.Add(thanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.payment_type_id = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan", thanhToan.hinhthucthanhtoan_id);
            return View(thanhToan);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.payment_type_id = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan", thanhToan.hinhthucthanhtoan_id);
            return View(thanhToan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "thanhtoan_id,datphong_id,hinhthucthanhtoan_id,sotienthanhtoan")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hinhthucthanhtoan_id = new SelectList(db.HinhThucThanhToans, "hinhthucthanhtoan_id", "hinhthucthanhtoan", thanhToan.hinhthucthanhtoan_id);
            return View(thanhToan);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan= db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            db.ThanhToans.Remove(thanhToan);
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