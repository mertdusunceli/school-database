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
    public class DersController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

        
        // GET: Ders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Der der = await db.Ders.FindAsync(id);
            if (der == null)
            {
                return HttpNotFound();
            }
            return View(der);
        }

        // GET: Ders/Create
        public ActionResult Create()
        {
            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi");
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ders_adi,ders_referans,kredi,ref_bolum")] Der der)
        {
            if (ModelState.IsValid)
            {
                der.active = 1;
                db.Ders.Add(der);
                await db.SaveChangesAsync();
                return RedirectToAction("LectureList", "Home");
            }

            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi", der.ref_bolum);
            return View(der);
        }

        // GET: Ders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Der der = await db.Ders.FindAsync(id);
            if (der == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi", der.ref_bolum);
            return View(der);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ders_adi,ders_referans,kredi,ref_bolum,active")] Der der)
        {
            if (ModelState.IsValid)
            {
                if (der.active == null)
                {
                    der.active = 1;
                }
                db.Entry(der).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("LectureList", "Home");
            }
            ViewBag.ref_bolum = new SelectList(db.Bolums, "id", "adi", der.ref_bolum);
            return View(der);
        }

        // GET: Ders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Der der = await db.Ders.FindAsync(id);
            if (der == null)
            {
                return HttpNotFound();
            }
            return View(der);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Der der = await db.Ders.FindAsync(id);
            if (der.active == (int)EnumHelperData.Satatus.Aktif)
            {
                der.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Ders.Remove(der);
            await db.SaveChangesAsync();
            return RedirectToAction("LectureList", "Home");
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
