using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicaretProje.Models;

namespace TicaretProje.Areas.Admin
{
    public class AdminKategoriController : Controller
    {
        TicaretDB db = new TicaretDB();
        // GET: Admin/AdminKategori
        public ActionResult Index()
        {
            var data = db.Kategoris.ToList();
            return View(data);
        }

        public ActionResult KategoriEkle()
        {
            var data = db.Kategoris.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGuncelle(int id)
        {

            var data = db.Kategoris.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var gnc = db.Kategoris.Find(k.kategoriId);
            gnc.kategoriAdi = k.kategoriAdi;
            gnc.aciklama = k.aciklama;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void KategoriSil(int id)
        {
            Kategori data = db.Kategoris.FirstOrDefault(x => x.kategoriId == id);
            db.Kategoris.Remove(data);
            db.SaveChanges();
        }
    }
}