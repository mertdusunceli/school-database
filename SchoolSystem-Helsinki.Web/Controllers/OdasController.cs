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
    public class OdasController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

     

        // GET: Odas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda oda = await db.Odas.FindAsync(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        // GET: Odas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Odas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,oda_numara,kat,active")] Oda oda)
        {
            if (ModelState.IsValid)
            {
                oda.active = 1;
                db.Odas.Add(oda);
                await db.SaveChangesAsync();
                return RedirectToAction("RoomList", "Home");
            }

            return View(oda);
        }

        // GET: Odas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda oda = await db.Odas.FindAsync(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        // POST: Odas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,oda_numara,kat,active")] Oda oda)
        {
            if (ModelState.IsValid)
            {
                if (oda.active==null)
                {
                    oda.active = 1;
                }
                db.Entry(oda).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("RoomList", "Home");
            }
            return View(oda);
        }

        // GET: Odas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda oda = await db.Odas.FindAsync(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        // POST: Odas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Oda oda = await db.Odas.FindAsync(id);
            if (oda.active == (int)EnumHelperData.Satatus.Aktif)
            {
                oda.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Odas.Remove(oda);
            await db.SaveChangesAsync();
            return RedirectToAction("RoomList", "Home");
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
