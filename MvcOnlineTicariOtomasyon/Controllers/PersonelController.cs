﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context context = new Context();

        public ActionResult Index()
        {
            var personeller = context.Personels.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanList = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd, // Kullaniciya dropdownda gosterilecek deger
                                                     Value = x.DepartmanId.ToString() // Arka planda secilen itemin istenilen degeri, id ile islem yapilacagi icin id degerini burada value olarak aliyoruz
                                                 }).ToList();

            ViewBag.departmanlar = departmanList;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}