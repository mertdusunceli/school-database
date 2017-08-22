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
    public class RolsController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();


        // GET: Rols/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol rol = await db.Rols.FindAsync(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // GET: Rols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,adi,yetki,active")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                rol.active = 1;
                db.Rols.Add(rol);
                await db.SaveChangesAsync();
                return RedirectToAction("TaskList", "Home");
            }

            return View(rol);
        }

        // GET: Rols/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol rol = await db.Rols.FindAsync(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,adi,yetki,active")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                if (rol.active == null)
                {
                    rol.active = 1;
                }
                db.Entry(rol).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("TaskList", "Home");
            }
            return View(rol);
        }

        // GET: Rols/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol rol = await db.Rols.FindAsync(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rol rol = await db.Rols.FindAsync(id);
            if (rol.active == (int)EnumHelperData.Satatus.Aktif)
            {
                rol.active = (int)EnumHelperData.Satatus.Pasif;
            }

            //db.Rols.Remove(rol);
            await db.SaveChangesAsync();
            return RedirectToAction("TaskList", "Home");
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
