using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();

        public ActionResult Index()
        {
            var cariler = context.Carilers.Where(x => x.Durum == true).ToList();
            return View(cariler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler cari)
        {
            cari.Durum = true;
            context.Carilers.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Carilers.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler cari)
        {
            if (!ModelState.IsValid)
                return View("CariGetir");

            var dbCari = context.Carilers.Find(cari.CariID);
            dbCari.CariAd = cari.CariAd;
            dbCari.CariSoyad = cari.CariSoyad;
            dbCari.CariSehir = cari.CariSehir;
            dbCari.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}