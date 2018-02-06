using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicaretProje.Models;

namespace TicaretProje.Controllers
{
    public class HomeController : Controller
    {
        TicaretDB db = new TicaretDB();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Liste = db.Kategoris.ToList();
            return View();
        }
        
        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
    }
}