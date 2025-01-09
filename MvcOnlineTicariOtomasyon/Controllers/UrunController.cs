using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }



        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult UrunSil(int id)
        {
            var value = c.Uruns.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urunDeger= c.Uruns.Find(id);
            return View("UrunGetir",urunDeger);
        }

       
        public ActionResult UrunGuncelle(Urun p)
        {
            var urun= c.Uruns.Find(p.UrunId);
            urun.UrunAd = p.UrunAd;
            urun.UrunGorsel = p.UrunGorsel;
            urun.AlisFiyat = p.AlisFiyat;
            urun.Durum = p.Durum;
            urun.KategoriId = p.KategoriId;
            urun.Marka=p.Marka;
            urun.SatisFiyat=p.SatisFiyat;
            urun.Stok = p.Stok;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}