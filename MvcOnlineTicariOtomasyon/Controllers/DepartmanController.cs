using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            c.Departmans.Add(departman);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        public ActionResult DepartmanSil(int id)
        {
            var value = c.Departmans.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var value = c.Departmans.Find(id);
            return View("DepartmanGetir", value);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var value = c.Departmans.FirstOrDefault(x => x.DepartmanId == d.DepartmanId);
            value.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.Departman = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var values = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personel = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.Personel = personel;
            return View(values);
        }
    }
}