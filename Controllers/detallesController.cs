using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using espaciodiseno.Models;

namespace espaciodiseno.Controllers
{
    [Authorize]
    public class detallesController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: detalles
        public async Task<ActionResult> Index()
        {
            return View(await db.detalles.ToListAsync());
        }

        // GET: detalles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles detalles = await db.detalles.FindAsync(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // GET: detalles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: detalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "det_id,det_nombre")] detalles detalles)
        {
            if (ModelState.IsValid)
            {
                db.detalles.Add(detalles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(detalles);
        }

        // GET: detalles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles detalles = await db.detalles.FindAsync(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // POST: detalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "det_id,det_nombre")] detalles detalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detalles);
        }

        // GET: detalles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles detalles = await db.detalles.FindAsync(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // POST: detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            detalles detalles = await db.detalles.FindAsync(id);
            db.detalles.Remove(detalles);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
