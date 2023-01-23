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
    public class PersonelCocuksController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: PersonelCocuks
        [Authorize]
        public ActionResult Index()
        {
            var personelCocuk = db.PersonelCocuk.Include(p => p.PersonelOzluk);
            return View(personelCocuk.ToList());
        }

        // GET: PersonelCocuks/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelCocuk personelCocuk = db.PersonelCocuk.Find(id);
            if (personelCocuk == null)
            {
                return HttpNotFound();
            }
            return View(personelCocuk);
        }

        // GET: PersonelCocuks/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi", "Soyadi");
            return View();
        }

        // POST: PersonelCocuks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,CocukAdı,CocukDogumTarihi,CocukCinsiyet,PersonelOzlukId")] PersonelCocuk personelCocuk)
        {
            if (ModelState.IsValid)
            {
                db.PersonelCocuk.Add(personelCocuk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelCocuk.PersonelOzlukId);
            return View(personelCocuk);
        }

        // GET: PersonelCocuks/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelCocuk personelCocuk = db.PersonelCocuk.Find(id);
            if (personelCocuk == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelCocuk.PersonelOzlukId);
            return View(personelCocuk);
        }

        // POST: PersonelCocuks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,CocukAdı,CocukDogumTarihi,CocukCinsiyet,PersonelOzlukId")] PersonelCocuk personelCocuk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelCocuk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelCocuk.PersonelOzlukId);
            return View(personelCocuk);
        }

        // GET: PersonelCocuks/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelCocuk personelCocuk = db.PersonelCocuk.Find(id);
            if (personelCocuk == null)
            {
                return HttpNotFound();
            }
            return View(personelCocuk);
        }

        // POST: PersonelCocuks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelCocuk personelCocuk = db.PersonelCocuk.Find(id);
            db.PersonelCocuk.Remove(personelCocuk);
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
