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
    public class KullanicisController : Controller
    {
        private OkulSistemEntities db = new OkulSistemEntities();

        // GET: Kullanicis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = await db.Kullanicis.FindAsync(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanicis/Create
        public ActionResult Create()
        {
            ViewBag.ref_Personel = new SelectList(db.Personels, "id", "adi");
            return View();
        }

        // POST: Kullanicis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,adi,sifre,email,telefon,ref_Personel,active")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                kullanici.active = 1;
                db.Kullanicis.Add(kullanici);
                await db.SaveChangesAsync();
                return RedirectToAction("UserList","Home");
            }

            ViewBag.ref_Personel = new SelectList(db.Personels, "id", "adi", kullanici.ref_Personel);
            return View(kullanici);
        }

        // GET: Kullanicis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = await db.Kullanicis.FindAsync(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.ref_Personel = new SelectList(db.Personels, "id", "adi", kullanici.ref_Personel);
            return View(kullanici);
        }

        // POST: Kullanicis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,adi,sifre,email,telefon,ref_Personel,active")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                if (kullanici.active == null)
                {
                    kullanici.active = 1;
                }
                db.Entry(kullanici).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("UserList", "Home");
            }
            ViewBag.ref_Personel = new SelectList(db.Personels, "id", "adi", kullanici.ref_Personel);
            return View(kullanici);
        }

        // GET: Kullanicis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = await db.Kullanicis.FindAsync(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kullanici kullanici = await db.Kullanicis.FindAsync(id);
            if (kullanici.active == (int)EnumHelperData.Satatus.Aktif)
            {
                kullanici.active = (int)EnumHelperData.Satatus.Pasif;
            }
            // db.Kullanicis.Remove(kullanici);
            await db.SaveChangesAsync();
            return RedirectToAction("UserList", "Home");
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
