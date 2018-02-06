using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicaretProje.App_Classes;
using TicaretProje.Models;
using static TicaretProje.App_Classes.Sepet;

namespace TicaretProje.Controllers
{
    public class UrunController : Controller
    {
        TicaretDB db = new TicaretDB();
        // GET: Urun
        public ActionResult Index()
        {
            var data = db.Uruns.ToList();
            return View(data);
        }

        public ActionResult KategorilereGore(int id)
        {
            ViewBag.ktgler = db.Kategoris.ToList();
            var data = db.Kategoris.Find(id).Uruns.ToList();
            return View("Index",data);
        }

        public PartialViewResult YeniUrunler()
        {
            var data = db.Uruns.ToList();
            return PartialView(data);
        }

        public ActionResult Detay(int id)
        {
            Urun u = db.Uruns.FirstOrDefault(x => x.urunId == id);

            return View(u);
        }


        public PartialViewResult Sepet()
        {
            return PartialView();
        }

        public void SepeteEkle(int id)
        {
            SepetItem si = new SepetItem();
            Urun u = db.Uruns.FirstOrDefault(x => x.urunId == id);
            si.urun = u;
            si.adet = 1;
            //si.indirim = 0;
            Sepet s = new Sepet();
            s.SepeteAt(si);

        }

        public ActionResult SepetDetay()
        {
            return View();
        }
    }
}