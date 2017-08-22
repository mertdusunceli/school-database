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
    public class FakultesController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

        // GET: Fakultes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = await db.Fakultes.FindAsync(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // GET: Fakultes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakultes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,fakulteAdi")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                fakulte.active = 1;
                db.Fakultes.Add(fakulte);
                await db.SaveChangesAsync();
                return RedirectToAction("FacultyList", "Home");
            }

            return View(fakulte);
        }

        // GET: Fakultes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = await db.Fakultes.FindAsync(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // POST: Fakultes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,fakulteAdi, active")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                if (fakulte.active == null)
                {
                    fakulte.active = 1;
                }
                db.Entry(fakulte).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("FacultyList", "Home");
            }
            return View(fakulte);
        }

        // GET: Fakultes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = await db.Fakultes.FindAsync(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // POST: Fakultes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fakulte fakulte = await db.Fakultes.FindAsync(id);
            if (fakulte.active == (int)EnumHelperData.Satatus.Aktif)
            {
                fakulte.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Fakultes.Remove(fakulte);
            await db.SaveChangesAsync();
            return RedirectToAction("FacultyList", "Home");
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
