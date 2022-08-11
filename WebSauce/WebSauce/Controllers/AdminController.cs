using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class AdminController : Controller
    {
        QLCHNMEntities db = new QLCHNMEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult laydsSP()
        {
            var sp = from s in db.SANPHAMs select s;
            return View(sp);
        }
        [HttpGet]
        public SANPHAM laySP(int msp)
        {
            return db.SANPHAMs.FirstOrDefault(x => x.MASP == msp);
        }
        [HttpPost]
        public ActionResult Details(int msp)
        {
            var dtpd = db.SANPHAMs.Where(s => s.MASP == msp).First();
            return View(dtpd);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, SANPHAM sp)
        {
            var s = collection["TENSP"];

            sp.TENSP = s;
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("laydsSP");
        }

        public ActionResult Edit(int msp)
        {
            var sp = db.SANPHAMs.First(m => m.MASP == msp);
            return View(sp);
        }

        [HttpPost]
        public ActionResult Edit(int msp, FormCollection collection)
        {

            var bh = db.SANPHAMs.First(m => m.MASP == msp);
            var tensp = collection["TENSP"];
            bh.MASP = msp;
            bh.TENSP = tensp;

            UpdateModel(bh);
            db.SaveChanges();
            return RedirectToAction("laydsSP");

        }

        public ActionResult Delete(int msp)
        {
            var sp = db.SANPHAMs.First(m => m.MASP == msp);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Delete(int msp, FormCollection collection)
        {
            var sp = db.SANPHAMs.Where(m => m.MASP == msp).First();
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("laydsSP");
        }
    }
}