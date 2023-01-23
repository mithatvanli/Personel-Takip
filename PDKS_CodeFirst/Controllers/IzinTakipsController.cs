using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PDKS_CodeFirst.DAL;
using PDKS_CodeFirst.Entity;

namespace PDKS_CodeFirst.Controllers
{
    public class IzinTakipsController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: IzinTakips
        [Authorize]
        public ActionResult Index()
        {
            var izinTakip = db.IzinTakip.Include(i => i.PersonelOzluk);
            return View(izinTakip.ToList());
        }

        // GET: IzinTakips/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTakip izinTakip = db.IzinTakip.Find(id);
            if (izinTakip == null)
            {
                return HttpNotFound();
            }
            return View(izinTakip);
        }

        // GET: IzinTakips/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi");
            return View();
        }

        // POST: IzinTakips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,IzinTalepTarihi,IzinBaslangıcTarihi,IzinBitisTarihi,IzinGunSayisi,IzinTipi,PersonelOzlukId")] IzinTakip izinTakip)
        {
            if (ModelState.IsValid)
            {
                db.IzinTakip.Add(izinTakip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", izinTakip.PersonelOzlukId);
            return View(izinTakip);
        }

        // GET: IzinTakips/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTakip izinTakip = db.IzinTakip.Find(id);
            if (izinTakip == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", izinTakip.PersonelOzlukId);
            return View(izinTakip);
        }

        // POST: IzinTakips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,IzinTalepTarihi,IzinBaslangıcTarihi,IzinBitisTarihi,IzinGunSayisi,IzinTipi,PersonelOzlukId")] IzinTakip izinTakip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izinTakip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", izinTakip.PersonelOzlukId);
            return View(izinTakip);
        }

        // GET: IzinTakips/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTakip izinTakip = db.IzinTakip.Find(id);
            if (izinTakip == null)
            {
                return HttpNotFound();
            }
            return View(izinTakip);
        }

        // POST: IzinTakips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            IzinTakip izinTakip = db.IzinTakip.Find(id);
            db.IzinTakip.Remove(izinTakip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
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
