using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DoAnChuyenNganhBookingHotel.Models;
using DoAnChuyenNganhBookingHotel.Models.DB;

namespace DoAnChuyenNganhBookingHotel.Controllers
{
    

    public class HomeController : Controller
    {
        public ActionResult Index()
        {        
            return View();
        }
        public ActionResult sendmail()
        {


            return View();
        }     
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung objuser)
        {
            QuanLyKhachSanModel obj = new QuanLyKhachSanModel();

            var user = obj.NguoiDungs.Where(x => x.email == objuser.email && x.matkhuaunguoidung == objuser.matkhuaunguoidung).FirstOrDefault();
            ViewBag.u = user;
            try
            {
                ViewBag.email = user.email;
                ViewBag.password = user.matkhuaunguoidung;
                Session["Name"] = user.tennguoidung;
            }
            catch (Exception)
            {


            }
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
