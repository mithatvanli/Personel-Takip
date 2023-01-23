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
    public class PersonelOzluksController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: PersonelOzluks
        [Authorize]
        public ActionResult Index()
        {
            var personelOzluks = db.PersonelOzluks.Include(p => p.Departman);
            return View(personelOzluks.ToList());
        }

        // GET: PersonelOzluks/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelOzluk personelOzluk = db.PersonelOzluks.Find(id);
            if (personelOzluk == null)
            {
                return HttpNotFound();
            }
            return View(personelOzluk);
        }

        // GET: PersonelOzluks/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi");
            return View();
        }

        // POST: PersonelOzluks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Adi,Soyadi,TcKimlik,Telefon,DogumTarihi,DepartmanId,Unvan,KurumSicil,EPosta,MedeniDurum,EvAdresi,Askerlik,IseGiris,Ehliyet,Engelli")] PersonelOzluk personelOzluk)
        {
            if (ModelState.IsValid)
            {
                db.PersonelOzluks.Add(personelOzluk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi", personelOzluk.DepartmanId);
            return View(personelOzluk);
        }

        // GET: PersonelOzluks/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelOzluk personelOzluk = db.PersonelOzluks.Find(id);
            if (personelOzluk == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi", personelOzluk.DepartmanId);
            return View(personelOzluk);
        }

        // POST: PersonelOzluks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,Soyadi,TcKimlik,Telefon,DogumTarihi,DepartmanId,Unvan,KurumSicil,EPosta,MedeniDurum,EvAdresi,Askerlik,IseGiris,Ehliyet,Engelli")] PersonelOzluk personelOzluk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelOzluk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmanId = new SelectList(db.Departmen, "Id", "DepartmanAdi", personelOzluk.DepartmanId);
            return View(personelOzluk);
        }

        // GET: PersonelOzluks/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelOzluk personelOzluk = db.PersonelOzluks.Find(id);
            if (personelOzluk == null)
            {
                return HttpNotFound();
            }
            return View(personelOzluk);
        }

        [Authorize]
        // POST: PersonelOzluks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelOzluk personelOzluk = db.PersonelOzluks.Find(id);
            db.PersonelOzluks.Remove(personelOzluk);
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
