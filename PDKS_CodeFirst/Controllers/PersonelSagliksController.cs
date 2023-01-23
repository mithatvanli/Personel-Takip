using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PDKS_CodeFirst.DAL;

namespace PDKS_CodeFirst.Controllers
{
    public class PersonelSagliksController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: PersonelSagliks
        [Authorize]
        public ActionResult Index()
        {
            return View(db.PersonelSagliks.ToList());
        }

        // GET: PersonelSagliks/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelSaglik personelSaglik = db.PersonelSagliks.Find(id);
            if (personelSaglik == null)
            {
                return HttpNotFound();
            }
            return View(personelSaglik);
        }

        // GET: PersonelSagliks/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonelSagliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,AlerJi,KalpRahatsizligi,KasEklem,GorneDurumu,IsitmeKaybi,BagisiklikGuclugu,KronikHastalik,AstimKoa,SindiriRahasizliklari,Aciklama,RuhsalRahatsizlik,ZihinselHastalik,KanGrubu,PersonelId")] PersonelSaglik personelSaglik)
        {
            if (ModelState.IsValid)
            {
                db.PersonelSagliks.Add(personelSaglik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personelSaglik);
        }

        // GET: PersonelSagliks/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelSaglik personelSaglik = db.PersonelSagliks.Find(id);
            if (personelSaglik == null)
            {
                return HttpNotFound();
            }
            return View(personelSaglik);
        }

        // POST: PersonelSagliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,AlerJi,KalpRahatsizligi,KasEklem,GorneDurumu,IsitmeKaybi,BagisiklikGuclugu,KronikHastalik,AstimKoa,SindiriRahasizliklari,Aciklama,RuhsalRahatsizlik,ZihinselHastalik,KanGrubu,PersonelId")] PersonelSaglik personelSaglik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelSaglik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personelSaglik);
        }

        // GET: PersonelSagliks/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelSaglik personelSaglik = db.PersonelSagliks.Find(id);
            if (personelSaglik == null)
            {
                return HttpNotFound();
            }
            return View(personelSaglik);
        }

        // POST: PersonelSagliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelSaglik personelSaglik = db.PersonelSagliks.Find(id);
            db.PersonelSagliks.Remove(personelSaglik);
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
