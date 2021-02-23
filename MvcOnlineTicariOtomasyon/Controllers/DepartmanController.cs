using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var departmanlar = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            context.Departmans.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = context.Departmans.Find(d.DepartmanId);
            departman.DepartmanAd = d.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}