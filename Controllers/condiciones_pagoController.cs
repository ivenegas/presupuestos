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
    public class condiciones_pagoController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: condiciones_pago
        public async Task<ActionResult> Index()
        {
            return View(await db.condiciones_pago.ToListAsync());
        }

        // GET: condiciones_pago/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            condiciones_pago condiciones_pago = await db.condiciones_pago.FindAsync(id);
            if (condiciones_pago == null)
            {
                return HttpNotFound();
            }
            return View(condiciones_pago);
        }

        // GET: condiciones_pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: condiciones_pago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "con_id,con_nombre")] condiciones_pago condiciones_pago)
        {
            if (ModelState.IsValid)
            {
                db.condiciones_pago.Add(condiciones_pago);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(condiciones_pago);
        }

        // GET: condiciones_pago/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            condiciones_pago condiciones_pago = await db.condiciones_pago.FindAsync(id);
            if (condiciones_pago == null)
            {
                return HttpNotFound();
            }
            return View(condiciones_pago);
        }

        // POST: condiciones_pago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "con_id,con_nombre")] condiciones_pago condiciones_pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condiciones_pago).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(condiciones_pago);
        }

        // GET: condiciones_pago/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            condiciones_pago condiciones_pago = await db.condiciones_pago.FindAsync(id);
            if (condiciones_pago == null)
            {
                return HttpNotFound();
            }
            return View(condiciones_pago);
        }

        // POST: condiciones_pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            condiciones_pago condiciones_pago = await db.condiciones_pago.FindAsync(id);
            db.condiciones_pago.Remove(condiciones_pago);
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
