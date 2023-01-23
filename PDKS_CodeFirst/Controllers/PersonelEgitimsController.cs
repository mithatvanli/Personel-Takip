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
    public class PersonelEgitimsController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: PersonelEgitims
        [Authorize]
        public ActionResult Index()
        {
            var personelEgitims = db.PersonelEgitims.Include(p => p.PersonelOzluk);
            return View(personelEgitims.ToList());
        }

        // GET: PersonelEgitims/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelEgitim personelEgitim = db.PersonelEgitims.Find(id);
            if (personelEgitim == null)
            {
                return HttpNotFound();
            }
            return View(personelEgitim);
        }

        // GET: PersonelEgitims/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi");
            return View();
        }

        // POST: PersonelEgitims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,EgitimBilgisi,PersonelOzlukId")] PersonelEgitim personelEgitim)
        {
            if (ModelState.IsValid)
            {
                db.PersonelEgitims.Add(personelEgitim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelEgitim.PersonelOzlukId);
            return View(personelEgitim);
        }

        // GET: PersonelEgitims/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelEgitim personelEgitim = db.PersonelEgitims.Find(id);
            if (personelEgitim == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelEgitim.PersonelOzlukId);
            return View(personelEgitim);
        }

        // POST: PersonelEgitims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,EgitimBilgisi,PersonelOzlukId")] PersonelEgitim personelEgitim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelEgitim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelEgitim.PersonelOzlukId);
            return View(personelEgitim);
        }

        // GET: PersonelEgitims/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelEgitim personelEgitim = db.PersonelEgitims.Find(id);
            if (personelEgitim == null)
            {
                return HttpNotFound();
            }
            return View(personelEgitim);
        }

        // POST: PersonelEgitims/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelEgitim personelEgitim = db.PersonelEgitims.Find(id);
            db.PersonelEgitims.Remove(personelEgitim);
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
