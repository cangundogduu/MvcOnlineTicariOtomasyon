using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c= new Context();
        public ActionResult Index()
        {
            var values= c.Kategoris.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            c.Kategoris.Add(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id) 
        {
            var deger= c.Kategoris.Find(id);
            c.Kategoris.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var value= c.Kategoris.Find(id);
            return View("KategoriGetir",value);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var value= c.Kategoris.FirstOrDefault(x=>x.KategoriId==kategori.KategoriId);
            value.KategoriAd=kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}