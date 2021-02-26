﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmlakSitesi.Models;

namespace EmlakSitesi.Controllers
{
    public class TipController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Tip
        public ActionResult Index()
        {
            var tips = db.Tips.Include(t => t.Durum);
            return View(tips.ToList());
        }

        public PartialViewResult DurumAd1()
        {
            var durumad1 = db.Tips.Where(i => i.DurumID == 1).FirstOrDefault();
            return PartialView(durumad1);
        }
        public PartialViewResult DurumAd2()
        {
            var durumad2 = db.Tips.Where(i => i.DurumID == 2).FirstOrDefault();
            return PartialView(durumad2);
        }
        public PartialViewResult DurumTip1()
        {
            var durumtip1 = db.Tips.Where(i => i.DurumID == 1).ToList();
            return PartialView(durumtip1);
        }
        public PartialViewResult DurumTip2()
        {
            var durumtip2 = db.Tips.Where(i => i.DurumID == 2).ToList();
            return PartialView(durumtip2);
        }
        // GET: Tip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // GET: Tip/Create
        public ActionResult Create()
        {
            ViewBag.DurumID = new SelectList(db.Durums, "DurumID", "DurumAd");
            return View();
        }

        // POST: Tip/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipID,TipAd,DurumID")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Tips.Add(tip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurumID = new SelectList(db.Durums, "DurumID", "DurumAd", tip.DurumID);
            return View(tip);
        }

        // GET: Tip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurumID = new SelectList(db.Durums, "DurumID", "DurumAd", tip.DurumID);
            return View(tip);
        }

        // POST: Tip/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipID,TipAd,DurumID")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumID = new SelectList(db.Durums, "DurumID", "DurumAd", tip.DurumID);
            return View(tip);
        }

        // GET: Tip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // POST: Tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tip tip = db.Tips.Find(id);
            db.Tips.Remove(tip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
