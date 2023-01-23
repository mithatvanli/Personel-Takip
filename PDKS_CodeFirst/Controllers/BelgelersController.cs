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
    public class BelgelersController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: Belgelers
        [Authorize]
        public ActionResult Index()
        {
            var belgelers = db.Belgelers.Include(b => b.PersonelOzluk);
            return View(belgelers.ToList());
        }

        // GET: Belgelers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belgeler belgeler = db.Belgelers.Find(id);
            if (belgeler == null)
            {
                return HttpNotFound();
            }
            return View(belgeler);
        }

        // GET: Belgelers/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi");
            return View();
        }

        // POST: Belgelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,BelgeAdi,BelgeYolu,BelgeTipi,PersonelOzlukId")] Belgeler belgeler)
        {
            if (ModelState.IsValid)
            {
                db.Belgelers.Add(belgeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", belgeler.PersonelOzlukId);
            return View(belgeler);
        }

        // GET: Belgelers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belgeler belgeler = db.Belgelers.Find(id);
            if (belgeler == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", belgeler.PersonelOzlukId);
            return View(belgeler);
        }

        // POST: Belgelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,BelgeAdi,BelgeYolu,BelgeTipi,PersonelOzlukId")] Belgeler belgeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(belgeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", belgeler.PersonelOzlukId);
            return View(belgeler);
        }

        // GET: Belgelers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belgeler belgeler = db.Belgelers.Find(id);
            if (belgeler == null)
            {
                return HttpNotFound();
            }
            return View(belgeler);
        }

        // POST: Belgelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Belgeler belgeler = db.Belgelers.Find(id);
            db.Belgelers.Remove(belgeler);
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
