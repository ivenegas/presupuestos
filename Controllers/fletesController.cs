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
    public class fletesController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: fletes
        public async Task<ActionResult> Index()
        {
            return View(await db.fletes.ToListAsync());
        }

        // GET: fletes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fletes fletes = await db.fletes.FindAsync(id);
            if (fletes == null)
            {
                return HttpNotFound();
            }
            return View(fletes);
        }

        // GET: fletes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "fle_id,fle_nombre,fle_valor,fle_telefono")] fletes fletes)
        {
            if (ModelState.IsValid)
            {
                db.fletes.Add(fletes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fletes);
        }

        // GET: fletes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fletes fletes = await db.fletes.FindAsync(id);
            if (fletes == null)
            {
                return HttpNotFound();
            }
            return View(fletes);
        }

        // POST: fletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "fle_id,fle_nombre,fle_valor,fle_telefono")] fletes fletes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fletes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fletes);
        }

        // GET: fletes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fletes fletes = await db.fletes.FindAsync(id);
            if (fletes == null)
            {
                return HttpNotFound();
            }
            return View(fletes);
        }

        // POST: fletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            fletes fletes = await db.fletes.FindAsync(id);
            db.fletes.Remove(fletes);
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
