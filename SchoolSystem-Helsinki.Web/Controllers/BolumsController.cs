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
    public class BolumsController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();
        
     
        // GET: Bolums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = await db.Bolums.FindAsync(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // GET: Bolums/Create
        public ActionResult Create()
        {
            ViewBag.ref_Fakulte = new SelectList(db.Fakultes, "id", "fakulteAdi");
            return View();
        }

        // POST: Bolums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,adi,ref_Fakulte")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                bolum.active = 1;
                db.Bolums.Add(bolum);
                await db.SaveChangesAsync();
                return RedirectToAction("DepartmentList", "Home");
            }

            ViewBag.ref_Fakulte = new SelectList(db.Fakultes, "id", "fakulteAdi", bolum.ref_Fakulte);
            return View(bolum);
        }

        // GET: Bolums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = await db.Bolums.FindAsync(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_Fakulte = new SelectList(db.Fakultes, "id", "fakulteAdi", bolum.ref_Fakulte);
            return View(bolum);
        }

        // POST: Bolums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,adi,ref_Fakulte, active")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                if (bolum.active == null)
                {
                    bolum.active = 1;
                }
                db.Entry(bolum).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("DepartmentList", "Home");
            }
            ViewBag.ref_Fakulte = new SelectList(db.Fakultes, "id", "fakulteAdi", bolum.ref_Fakulte);
            return View(bolum);
        }

        // GET: Bolums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = await db.Bolums.FindAsync(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // POST: Bolums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bolum bolum = await db.Bolums.FindAsync(id);
            if (bolum.active == (int)EnumHelperData.Satatus.Aktif)
            {
                bolum.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Bolums.Remove(bolum);
            await db.SaveChangesAsync();
            return RedirectToAction("DepartmentList", "Home");
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
