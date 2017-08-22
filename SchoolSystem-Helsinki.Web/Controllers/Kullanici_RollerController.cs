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
    public class Kullanici_RollerController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

       
        // GET: Kullanici_Roller/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici_Roller kullanici_Roller = await db.Kullanici_Roller.FindAsync(id);
            if (kullanici_Roller == null)
            {
                return HttpNotFound();
            }
            return View(kullanici_Roller);
        }

        // GET: Kullanici_Roller/Create
        public ActionResult Create()
        {
            ViewBag.Kullanici_ref = new SelectList(db.Kullanicis, "id", "adi");
            ViewBag.Rol_ref = new SelectList(db.Rols, "id", "adi");
            return View();
        }

        // POST: Kullanici_Roller/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Kullanici_ref,Rol_ref,active")] Kullanici_Roller kullanici_Roller)
        {
            if (ModelState.IsValid)
            {
                kullanici_Roller.active = 1;
                db.Kullanici_Roller.Add(kullanici_Roller);
                await db.SaveChangesAsync();
                return RedirectToAction("UserTaskList", "Home");
            }

            ViewBag.Kullanici_ref = new SelectList(db.Kullanicis, "id", "adi", kullanici_Roller.Kullanici_ref);
            ViewBag.Rol_ref = new SelectList(db.Rols, "id", "adi", kullanici_Roller.Rol_ref);
            return View(kullanici_Roller);
        }

        // GET: Kullanici_Roller/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici_Roller kullanici_Roller = await db.Kullanici_Roller.FindAsync(id);
            if (kullanici_Roller == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kullanici_ref = new SelectList(db.Kullanicis, "id", "adi", kullanici_Roller.Kullanici_ref);
            ViewBag.Rol_ref = new SelectList(db.Rols, "id", "adi", kullanici_Roller.Rol_ref);
            return View(kullanici_Roller);
        }

        // POST: Kullanici_Roller/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Kullanici_ref,Rol_ref,active")] Kullanici_Roller kullanici_Roller)
        {
            if (ModelState.IsValid)
            {
                if (kullanici_Roller.active == null)
                {
                    kullanici_Roller.active = 1;
                }
                db.Entry(kullanici_Roller).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("UserTaskList", "Home");
            }
            ViewBag.Kullanici_ref = new SelectList(db.Kullanicis, "id", "adi", kullanici_Roller.Kullanici_ref);
            ViewBag.Rol_ref = new SelectList(db.Rols, "id", "adi", kullanici_Roller.Rol_ref);
            return View(kullanici_Roller);
        }

        // GET: Kullanici_Roller/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici_Roller kullanici_Roller = await db.Kullanici_Roller.FindAsync(id);
            if (kullanici_Roller == null)
            {
                return HttpNotFound();
            }
            return View(kullanici_Roller);
        }

        // POST: Kullanici_Roller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kullanici_Roller kullanici_Roller = await db.Kullanici_Roller.FindAsync(id);
            if (kullanici_Roller.active == (int)EnumHelperData.Satatus.Aktif)
            {
                kullanici_Roller.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Kullanici_Roller.Remove(kullanici_Roller);
            await db.SaveChangesAsync();
            return RedirectToAction("UserTaskList", "Home");
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
