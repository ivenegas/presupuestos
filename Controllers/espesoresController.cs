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
    public class espesoresController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: espesores
        public async Task<ActionResult> Index()
        {
            return View(await db.espesores.ToListAsync());
        }

        // GET: espesores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            espesores espesores = await db.espesores.FindAsync(id);
            if (espesores == null)
            {
                return HttpNotFound();
            }
            return View(espesores);
        }

        // GET: espesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: espesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "esp_id,esp_nombre")] espesores espesores)
        {
            if (ModelState.IsValid)
            {
                db.espesores.Add(espesores);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(espesores);
        }

        // GET: espesores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            espesores espesores = await db.espesores.FindAsync(id);
            if (espesores == null)
            {
                return HttpNotFound();
            }
            return View(espesores);
        }

        // POST: espesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "esp_id,esp_nombre")] espesores espesores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(espesores).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(espesores);
        }

        // GET: espesores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            espesores espesores = await db.espesores.FindAsync(id);
            if (espesores == null)
            {
                return HttpNotFound();
            }
            return View(espesores);
        }

        // POST: espesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            espesores espesores = await db.espesores.FindAsync(id);
            db.espesores.Remove(espesores);
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
