using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicaretProje.Models;

namespace TicaretProje.Controllers
{
    public class KullaniciController : Controller
    {
        TicaretDB db = new TicaretDB();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(Kullanici kl)
        {
            kl.dogumTarihi = kl.dogumTarihi.Value.Date;
            db.Kullanicis.Add(kl);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}