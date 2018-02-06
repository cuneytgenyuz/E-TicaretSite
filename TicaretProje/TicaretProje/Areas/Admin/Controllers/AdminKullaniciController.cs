using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicaretProje.Models;

namespace TicaretProje.Areas.Admin.Controllers
{
    public class AdminKullaniciController : Controller
    {
        TicaretDB db = new TicaretDB();
        // GET: Admin/AdminKullanici
        public ActionResult Index()
        {
            var data = db.Kullanicis.ToList();
            return View(data);
        }
    }
}