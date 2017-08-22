using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolSystem_Helsinki.Web.Models;

namespace SchoolSystem_Helsinki.Web.Controllers
{
    public class PersonelsController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

      
        // GET: Personels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = await db.Personels.FindAsync(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personels/Create
        public ActionResult Create()
        {
            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi");
            ViewBag.ref_okul = new SelectList(db.Okuls, "id", "adi");
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,adi,soyad,yas,mezun_tarih,sinif,ref_bolum,ref_okul,active")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                personel.active = 1;
                db.Personels.Add(personel);
                await db.SaveChangesAsync();
                return RedirectToAction("PersonnelList", "Home");
            }

            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi", personel.ref_bolum);
            ViewBag.ref_okul = new SelectList(db.Okuls, "id", "adi", personel.ref_okul);
            return View(personel);
        }

        // GET: Personels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = await db.Personels.FindAsync(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi", personel.ref_bolum);
            ViewBag.ref_okul = new SelectList(db.Okuls, "id", "adi", personel.ref_okul);
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,adi,soyad,yas,mezun_tarih,sinif,ref_bolum,ref_okul,active")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                if (personel.active == null)
                {
                    personel.active = 1;
                }
                db.Entry(personel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("PersonnelList", "Home");
            }
            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi", personel.ref_bolum);
            ViewBag.ref_okul = new SelectList(db.Okuls, "id", "adi", personel.ref_okul);
            return View(personel);
        }

        // GET: Personels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = await db.Personels.FindAsync(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Personel personel = await db.Personels.FindAsync(id);
            if (personel.active == (int)EnumHelperData.Satatus.Aktif)
            {
                personel.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Personels.Remove(personel);
            await db.SaveChangesAsync();
            return RedirectToAction("PersonnelList", "Home");
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
