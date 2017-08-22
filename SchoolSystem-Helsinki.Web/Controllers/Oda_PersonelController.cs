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
    public class Oda_PersonelController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

        // GET: Oda_Personel/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda_Personel oda_Personel = await db.Oda_Personel.FindAsync(id);
            if (oda_Personel == null)
            {
                return HttpNotFound();
            }
            return View(oda_Personel);
        }

        // GET: Oda_Personel/Create
        public ActionResult Create()
        {
            ViewBag.ref_OdaId = new SelectList(db.Odas, "id", "oda_numara");
            ViewBag.ref_PersonelId = new SelectList(db.Personels, "id", "adi");
            return View();
        }

        // POST: Oda_Personel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ref_OdaId,ref_PersonelId,active")] Oda_Personel oda_Personel)
        {
            if (ModelState.IsValid)
            {
                oda_Personel.active = 1; 
                db.Oda_Personel.Add(oda_Personel);
                await db.SaveChangesAsync();
                return RedirectToAction("RoomPersonnelList", "Home");
            }

            ViewBag.ref_OdaId = new SelectList(db.Odas, "id", "oda_numara", oda_Personel.ref_OdaId);
            ViewBag.ref_PersonelId = new SelectList(db.Personels, "id", "adi", oda_Personel.ref_PersonelId);
            return View(oda_Personel);
        }

        // GET: Oda_Personel/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda_Personel oda_Personel = await db.Oda_Personel.FindAsync(id);
            if (oda_Personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_OdaId = new SelectList(db.Odas, "id", "oda_numara", oda_Personel.ref_OdaId);
            ViewBag.ref_PersonelId = new SelectList(db.Personels, "id", "adi", oda_Personel.ref_PersonelId);
            return View(oda_Personel);
        }

        // POST: Oda_Personel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ref_OdaId,ref_PersonelId,active")] Oda_Personel oda_Personel)
        {
            if (ModelState.IsValid)
            {
                if (oda_Personel.active == null)
                {
                    oda_Personel.active = 1;
                }
                db.Entry(oda_Personel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("RoomPersonnelList", "Home");
            }
            ViewBag.ref_OdaId = new SelectList(db.Odas, "id", "oda_numara", oda_Personel.ref_OdaId);
            ViewBag.ref_PersonelId = new SelectList(db.Personels, "id", "adi", oda_Personel.ref_PersonelId);
            return View(oda_Personel);
        }

        // GET: Oda_Personel/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda_Personel oda_Personel = await db.Oda_Personel.FindAsync(id);
            if (oda_Personel == null)
            {
                return HttpNotFound();
            }
            return View(oda_Personel);
        }

        // POST: Oda_Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Oda_Personel oda_Personel = await db.Oda_Personel.FindAsync(id);
            if (oda_Personel.active == (int)EnumHelperData.Satatus.Aktif)
            {
                oda_Personel.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Oda_Personel.Remove(oda_Personel);
            await db.SaveChangesAsync();
            return RedirectToAction("RoomPersonnelList", "Home");
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
