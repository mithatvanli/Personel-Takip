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
    public class PersonelPuantaJsController : Controller
    {
        private PDKSContext db = new PDKSContext();

        // GET: PersonelPuantaJs
        [Authorize]
        public ActionResult Index()
        {
            var personelPuantaJs = db.PersonelPuantaJs.Include(p => p.PersonelOzluk);
            return View(personelPuantaJs.ToList());
        }

        // GET: PersonelPuantaJs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelPuantaJ personelPuantaJ = db.PersonelPuantaJs.Find(id);
            if (personelPuantaJ == null)
            {
                return HttpNotFound();
            }
            return View(personelPuantaJ);
        }

        // GET: PersonelPuantaJs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi");
            return View();
        }

        // POST: PersonelPuantaJs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,CalısmaSaati,GirisSaati,CıkısSaati,Mazeret,PersonelOzlukId")] PersonelPuantaJ personelPuantaJ)
        {
            if (ModelState.IsValid)
            {
                db.PersonelPuantaJs.Add(personelPuantaJ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelPuantaJ.PersonelOzlukId);
            return View(personelPuantaJ);
        }

        // GET: PersonelPuantaJs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelPuantaJ personelPuantaJ = db.PersonelPuantaJs.Find(id);
            if (personelPuantaJ == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelPuantaJ.PersonelOzlukId);
            return View(personelPuantaJ);
        }

        // POST: PersonelPuantaJs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,CalısmaSaati,GirisSaati,CıkısSaati,Mazeret,PersonelOzlukId")] PersonelPuantaJ personelPuantaJ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelPuantaJ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelOzlukId = new SelectList(db.PersonelOzluks, "Id", "Adi","Soyadi", personelPuantaJ.PersonelOzlukId);
            return View(personelPuantaJ);
        }

        // GET: PersonelPuantaJs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelPuantaJ personelPuantaJ = db.PersonelPuantaJs.Find(id);
            if (personelPuantaJ == null)
            {
                return HttpNotFound();
            }
            return View(personelPuantaJ);
        }

        // POST: PersonelPuantaJs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelPuantaJ personelPuantaJ = db.PersonelPuantaJs.Find(id);
            db.PersonelPuantaJs.Remove(personelPuantaJ);
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
