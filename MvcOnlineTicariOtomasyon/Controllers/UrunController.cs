using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = context.Uruns.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}