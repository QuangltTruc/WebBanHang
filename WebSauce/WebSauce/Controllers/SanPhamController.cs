using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class SanPhamController : Controller
    {
        QLCHNMEntities db = new QLCHNMEntities();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPhamPartial()
        {
            var listSP = db.SANPHAMs.OrderBy(sp => sp.TENSP).ToList();
            return View(listSP);
        }
        public ActionResult XemChiTiet(int msp)
        {
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == msp);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

    }
}