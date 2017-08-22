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
    public class Oda_DersleriController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

        

        // GET: Oda_Dersleri/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda_Dersleri oda_Dersleri = await db.Oda_Dersleri.FindAsync(id);
            if (oda_Dersleri == null)
            {
                return HttpNotFound();
            }
            return View(oda_Dersleri);
        }

        // GET: Oda_Dersleri/Create
        public ActionResult Create()
        {
            ViewBag.ref_DersId = new SelectList(db.Ders, "id", "ders_adi");
            ViewBag.ref_OdId = new SelectList(db.Odas, "id", "oda_numara");
            return View();
        }

        // POST: Oda_Dersleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ref_DersId,ref_OdId,active")] Oda_Dersleri oda_Dersleri)
        {
            if (ModelState.IsValid)
            {
                oda_Dersleri.active = 1;
                db.Oda_Dersleri.Add(oda_Dersleri);
                await db.SaveChangesAsync();
                return RedirectToAction("RoomLectureList", "Home");
            }

            ViewBag.ref_DersId = new SelectList(db.Ders, "id", "ders_adi", oda_Dersleri.ref_DersId);
            ViewBag.ref_OdId = new SelectList(db.Odas, "id", "oda_numara", oda_Dersleri.ref_OdId);
            return View(oda_Dersleri);
        }

        // GET: Oda_Dersleri/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda_Dersleri oda_Dersleri = await db.Oda_Dersleri.FindAsync(id);
            if (oda_Dersleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_DersId = new SelectList(db.Ders, "id", "ders_adi", oda_Dersleri.ref_DersId);
            ViewBag.ref_OdId = new SelectList(db.Odas, "id", "oda_numara", oda_Dersleri.ref_OdId);
            return View(oda_Dersleri);
        }

        // POST: Oda_Dersleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ref_DersId,ref_OdId,active")] Oda_Dersleri oda_Dersleri)
        {
            if (ModelState.IsValid)
            {
                if (oda_Dersleri.active == null)
                {
                    oda_Dersleri.active = 1;
                }
                db.Entry(oda_Dersleri).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("RoomLectureList", "Home");
            }
            ViewBag.ref_DersId = new SelectList(db.Ders, "id", "ders_adi", oda_Dersleri.ref_DersId);
            ViewBag.ref_OdId = new SelectList(db.Odas, "id", "oda_numara", oda_Dersleri.ref_OdId);
            return View(oda_Dersleri);
        }

        // GET: Oda_Dersleri/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda_Dersleri oda_Dersleri = await db.Oda_Dersleri.FindAsync(id);
            if (oda_Dersleri == null)
            {
                return HttpNotFound();
            }
            return View(oda_Dersleri);
        }

        // POST: Oda_Dersleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Oda_Dersleri oda_Dersleri = await db.Oda_Dersleri.FindAsync(id);
            if (oda_Dersleri.active == (int)EnumHelperData.Satatus.Aktif)
            {
                oda_Dersleri.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Oda_Dersleri.Remove(oda_Dersleri);
            await db.SaveChangesAsync();
            return RedirectToAction("RoomLectureList", "Home");
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
