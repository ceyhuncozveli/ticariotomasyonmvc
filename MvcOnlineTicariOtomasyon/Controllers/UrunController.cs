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
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> kategoriList = (from x in context.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd, // KUllaniciya dropdownda gosterilecek deger
                                               Value = x.KategoriID.ToString() // Arka planda secilen itemin istenilen degeri, id ile islem yapilacagi icin id degerini burada value olarak aliyoruz
                                           }).ToList();

            ViewBag.kategoriler = kategoriList;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = context.Uruns.Find(id);
            urun.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> kategoriList = (from x in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd, // KUllaniciya dropdownda gosterilecek deger
                                                     Value = x.KategoriID.ToString() // Arka planda secilen itemin istenilen degeri, id ile islem yapilacagi icin id degerini burada value olarak aliyoruz
                                                 }).ToList();

            ViewBag.kategoriler = kategoriList;

            var urun = context.Uruns.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = context.Uruns.Find(urun.UrunID);
            urn.AlisFiyat = urun.AlisFiyat;
            urn.Durum = urun.Durum;
            urn.KategoriId = urun.KategoriId;
            urn.Marka = urun.Marka;
            urn.SatisFiyat = urun.SatisFiyat;
            urn.Stok = urun.Stok;
            urn.UrunAd = urun.UrunAd;
            urn.UrunGorsel = urun.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}