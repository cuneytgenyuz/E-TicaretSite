using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicaretProje.Models;

namespace TicaretProje.App_Classes
{
    public class Sepet
    {
        public static Sepet sepet
        {
            get
            {
                HttpContext ctx = HttpContext.Current;
                if (ctx.Session["sepet"] == null)
                {
                    ctx.Session["sepet"] = new Sepet();
                }
                return (Sepet)ctx.Session["sepet"];
            }
        }

        private List<SepetItem> Urunler = new List<SepetItem>();

        public List<SepetItem> urunler
        {
            get { return Urunler; }
            set { Urunler = value; }
        }

        public void SepeteAt(SepetItem si)
        {
            if (HttpContext.Current.Session["sepet"] != null)
            {
                Sepet s = (Sepet)HttpContext.Current.Session["sepet"];

                if (s.urunler.Any(x => x.urun.urunId == si.urun.urunId))
                {
                    s.urunler.FirstOrDefault(x => x.urun.urunId == si.urun.urunId).adet++;
                }
                else
                {
                    s.urunler.Add(si);
                }
            }
            else
            {
                Sepet s = new Sepet();
                s.urunler.Add(si);
                HttpContext.Current.Session["sepet"] = s;
            }

        }

        public decimal toplamTutar
        {
            get
            {
                return urunler.Sum(x => x.tutar);
            }
        }


        public class SepetItem
        {
            public Urun urun { get; set; }

            public int adet { get; set; }

            public double indirim { get; set; }

            public decimal tutar
            {
                get
                {
                    return (int)urun.satisFiyat * adet * (decimal)(1 - indirim);
                }
            }
        }

    }
}