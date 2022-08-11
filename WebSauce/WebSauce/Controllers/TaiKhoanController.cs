using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class TaiKhoanController : Controller
    {
        QLCHNMEntities db = new QLCHNMEntities();
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string pass)
        {
            if(username==null||pass==null)
                return RedirectToAction("Login", "TaiKhoan");
            TaiKhoan taikhoan = db.TaiKhoans.Single(tk => tk.username == username && tk.password == pass);
            if (taikhoan != null)
                return RedirectToAction("laydsSP", "Admin");
            return RedirectToAction("Login", "TaiKhoan");
        }

        public ActionResult Logout()
        {

            return RedirectToAction("Index", "SanPham");
        }


    }
}