using EmlakSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;//ekledim
namespace EmlakSitesi.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ilan = db.Ilans.Include(m => m.Mahalle).Include(e => e.Tip);
            return View(ilan.ToList());
        }
        public ActionResult MenuFiltre(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var filtre=db.Ilans.Where(i=>i.TipId==id).Include(m => m.Mahalle).Include(e => e.Tip).ToList();
            return View(filtre);
        }
        public PartialViewResult PartialFiltre()
        {
            ViewBag.sehirlist = new SelectList(sehirGetir(), "SehirId", "SehirAd");
            ViewBag.durumlist = new SelectList(durumGetir(), "DurumId", "DurumAd");
            return PartialView();
        }
          public ActionResult DurumList(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ilan=db.Ilans.Where(i=>i.DurumId==id).Include(m => m.Mahalle).Include(e => e.Tip);
            return View(ilan.ToList());
        }
        public ActionResult Filitre(int min,int max,int sehirid,int mahalleid,int semtid,int durumid,int tipid)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var filtre = db.Ilans.Where(i => i.Fiyat >= min && i.Fiyat <= max 
            && i.DurumId == durumid
            && i.SemtId == semtid
            && i.MahalleId == mahalleid
            && i.SehirId == sehirid 
            && i.TipId == tipid).Include(m => m.Mahalle).Include(e => e.Tip).ToList();
            return View(filtre);
        }

        public List<Sehir> sehirGetir()
        {
            List<Sehir> sehirler = db.Sehirs.ToList();
            return sehirler;
        }
        public ActionResult semtGetir(int SehirId)
        {
            List<Semt> semtler = db.Semts.Where(x => x.SemtId == SehirId).ToList();
            ViewBag.semtListesi = new SelectList(semtler, "SemtId", "SemtAd");
            return PartialView("SemtPartial");

        }
        public ActionResult mahalleGetir(int SemtId)
        {
            List<Mahalle> mahalleList = db.Mahalles.Where(x => x.SemtId == SemtId).ToList();
            ViewBag.mahallelistesi = new SelectList(mahalleList, "MahalleId", "mahalleAd");
            return PartialView("MahallePartial");
        }
        public List<Durum> durumGetir()
        {
            List<Durum> durumlar = db.Durums.ToList();
            return durumlar;
        }
    


       public ActionResult Search(string q)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ara= db.Ilans.Include(m => m.Mahalle).Include(e => e.Tip);
            if (!string .IsNullOrEmpty(q))
            {
                ara = ara.Where(i => i.Aciklama.Contains(q) || i.Mahalle.MahalleAd.Contains(q) || i.Tip.TipAd.Contains(q));
            }
            return View(ara.ToList());
        }

        public ActionResult Detay(int  id)
        {
            var ilan = db.Ilans.Where(i => i.IlanID == id).Include(m => m.Mahalle).Include(e => e.Tip).FirstOrDefault();
            var imgs =  db.Resims.Where(i => i.IlanId == id).ToList();//ilan Id ye göre resim gelecek
            ViewBag.imgs = imgs;
            return View(ilan);
        }
        public PartialViewResult slider()
        {
            var ilan = db.Ilans.ToList().Take(5);//sadece 5 resim gelecek
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            return PartialView(ilan);
        }
   }
}
