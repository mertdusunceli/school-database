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
    public class SinavlarsController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

        // GET: Sinavlars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinavlar sinavlar = await db.Sinavlars.FindAsync(id);
            if (sinavlar == null)
            {
                return HttpNotFound();
            }
            return View(sinavlar);
        }

        // GET: Sinavlars/Create
        public ActionResult Create()
        {
            ViewBag.ref_ders = new SelectList(db.Ders, "id", "ders_adi");
            ViewBag.ref_personel = new SelectList(db.Personels, "id", "adi");
            return View();
        }

        // POST: Sinavlars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ref_ders,ref_personel,durum,puan,active")] Sinavlar sinavlar)
        {
            if (ModelState.IsValid)
            {
                sinavlar.active = 1;
                db.Sinavlars.Add(sinavlar);
                await db.SaveChangesAsync();
                return RedirectToAction("ExamList", "Home");
            }

            ViewBag.ref_ders = new SelectList(db.Ders, "id", "ders_adi", sinavlar.ref_ders);
            ViewBag.ref_personel = new SelectList(db.Personels, "id", "adi", sinavlar.ref_personel);
            return View(sinavlar);
        }

        // GET: Sinavlars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinavlar sinavlar = await db.Sinavlars.FindAsync(id);
            if (sinavlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_ders = new SelectList(db.Ders, "id", "ders_adi", sinavlar.ref_ders);
            ViewBag.ref_personel = new SelectList(db.Personels, "id", "adi", sinavlar.ref_personel);
            return View(sinavlar);
        }

        // POST: Sinavlars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ref_ders,ref_personel,durum,puan,active")] Sinavlar sinavlar)
        {
            if (ModelState.IsValid)
            {
                if (sinavlar.active == null)
                {
                    sinavlar.active = 1;

                }
                db.Entry(sinavlar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("ExamList", "Home");
            }
            ViewBag.ref_ders = new SelectList(db.Ders, "id", "ders_adi", sinavlar.ref_ders);
            ViewBag.ref_personel = new SelectList(db.Personels, "id", "adi", sinavlar.ref_personel);
            return View(sinavlar);
        }

        // GET: Sinavlars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinavlar sinavlar = await db.Sinavlars.FindAsync(id);
            if (sinavlar == null)
            {
                return HttpNotFound();
            }
            return View(sinavlar);
        }

        // POST: Sinavlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sinavlar sinavlar = await db.Sinavlars.FindAsync(id);
            if (sinavlar.active == (int)EnumHelperData.Satatus.Aktif)
            {
                sinavlar.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Sinavlars.Remove(sinavlar);
            await db.SaveChangesAsync();
            return RedirectToAction("ExamList", "Home");
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
