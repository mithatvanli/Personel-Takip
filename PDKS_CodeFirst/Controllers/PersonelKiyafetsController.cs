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
    public class PersonelKiyafetsController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: PersonelKiyafets
        [Authorize]
        public ActionResult Index()
        {
            var personelKiyafets = db.PersonelKiyafets.Include(p => p.Departman).Include(p => p.PersonelOzluk);
            return View(personelKiyafets.ToList());
        }

        // GET: PersonelKiyafets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelKiyafet personelKiyafet = db.PersonelKiyafets.Find(id);
            if (personelKiyafet == null)
            {
                return HttpNotFound();
            }
            return View(personelKiyafet);
        }

        // GET: PersonelKiyafets/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi");
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi");
            return View();
        }

        // POST: PersonelKiyafets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,PersonelOzlukId,DepartmanId,İstekNedeni,Renk,Model,ÜstBedenNo,AltBedenNo,KafaBedenNo,AyakkabıNo,Boy,Kilo")] PersonelKiyafet personelKiyafet)
        {
            if (ModelState.IsValid)
            {
                db.PersonelKiyafets.Add(personelKiyafet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi", personelKiyafet.DepartmanId);
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelKiyafet.PersonelOzlukId);
            return View(personelKiyafet);
        }

        // GET: PersonelKiyafets/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelKiyafet personelKiyafet = db.PersonelKiyafets.Find(id);
            if (personelKiyafet == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi", personelKiyafet.DepartmanId);
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelKiyafet.PersonelOzlukId);
            return View(personelKiyafet);
        }

        // POST: PersonelKiyafets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,PersonelOzlukId,DepartmanId,İstekNedeni,Renk,Model,ÜstBedenNo,AltBedenNo,KafaBedenNo,AyakkabıNo,Boy,Kilo")] PersonelKiyafet personelKiyafet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelKiyafet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi", personelKiyafet.DepartmanId);
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelKiyafet.PersonelOzlukId);
            return View(personelKiyafet);
        }

        // GET: PersonelKiyafets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelKiyafet personelKiyafet = db.PersonelKiyafets.Find(id);
            if (personelKiyafet == null)
            {
                return HttpNotFound();
            }
            return View(personelKiyafet);
        }

        // POST: PersonelKiyafets/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelKiyafet personelKiyafet = db.PersonelKiyafets.Find(id);
            db.PersonelKiyafets.Remove(personelKiyafet);
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
