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
    public class OkulsController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();
    
       
       

        // GET: Okuls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Okul okul = await db.Okuls.FindAsync(id);
            if (okul == null)
            {
                return HttpNotFound();
            }
            return View(okul);
        }

        // GET: Okuls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Okuls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,adi,adres,telefon,email")] Okul okul)
        {
            if (ModelState.IsValid)
            {
                okul.active = 1;
                db.Okuls.Add(okul);
                await db.SaveChangesAsync();
                return RedirectToAction("SchoolList", "Home");
            }

            return View(okul);
        }

        // GET: Okuls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Okul okul = await db.Okuls.FindAsync(id);
            if (okul == null)
            {
                return HttpNotFound();
            }
            return View(okul);
        }

        // POST: Okuls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,adi,adres,telefon,email,active")] Okul okul)
        {
            if (ModelState.IsValid)
            {
                if (okul.active==null)
                {
                    okul.active = 1;
                }
                db.Entry(okul).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("SchoolList", "Home");
            }
            return View(okul);
        }

        // GET: Okuls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Okul okul = await db.Okuls.FindAsync(id);
            if (okul == null)
            {
                return HttpNotFound();
            }
            return View(okul);
        }

        // POST: Okuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Okul okul = await db.Okuls.FindAsync(id);
            if (okul.active== (int)EnumHelperData.Satatus.Aktif)
            {
                okul.active = (int)EnumHelperData.Satatus.Pasif;
            }
            //db.Okuls.Remove(okul);
            await db.SaveChangesAsync();
            return RedirectToAction("SchoolList", "Home");
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
