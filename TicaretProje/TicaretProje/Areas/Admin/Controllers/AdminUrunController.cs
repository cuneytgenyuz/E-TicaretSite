using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicaretProje.Areas.Admin.Models;

namespace TicaretProje.Areas.Admin.Controllers
{
    public class AdminUrunController : Controller
    {
        Ticaret db = new Ticaret();
        // GET: Admin/AdminUrun
        public ActionResult Index()
        {
            var data=db.Uruns.ToList();
            return View(data);
        }

        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = db.Kategoris.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            db.Uruns.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGuncelle(int id)
        {
            ViewBag.kategoriler = db.Kategoris.ToList();
            var data = db.Uruns.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun u)
        {
            var gnc = db.Uruns.Find(u.urunId);
            gnc.urunAdi = u.urunAdi;
            gnc.aciklama = u.aciklama;
            gnc.alısFiyat = u.alısFiyat;
            gnc.satisFiyat = u.satisFiyat;
            gnc.kategoriID = u.kategoriID;
                        
            db.SaveChanges();
            return RedirectToAction("Index");
                        
        }

       [HttpPost]
        public void UrunSil(int id)
        {
            Urun data= db.Uruns.FirstOrDefault(x => x.urunId == id);
            db.Uruns.Remove(data);
            db.SaveChanges();
            
        }
    }
}