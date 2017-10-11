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
    public class mano_obrasController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: mano_obras
        public async Task<ActionResult> Index()
        {
            return View(await db.mano_obras.ToListAsync());
        }

        // GET: mano_obras/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mano_obras mano_obras = await db.mano_obras.FindAsync(id);
            if (mano_obras == null)
            {
                return HttpNotFound();
            }
            return View(mano_obras);
        }

        // GET: mano_obras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mano_obras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "man_id,man_nombre,man_valor")] mano_obras mano_obras)
        {
            if (ModelState.IsValid)
            {
                db.mano_obras.Add(mano_obras);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mano_obras);
        }

        // GET: mano_obras/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mano_obras mano_obras = await db.mano_obras.FindAsync(id);
            if (mano_obras == null)
            {
                return HttpNotFound();
            }
            return View(mano_obras);
        }

        // POST: mano_obras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "man_id,man_nombre,man_valor")] mano_obras mano_obras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mano_obras).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mano_obras);
        }

        // GET: mano_obras/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mano_obras mano_obras = await db.mano_obras.FindAsync(id);
            if (mano_obras == null)
            {
                return HttpNotFound();
            }
            return View(mano_obras);
        }

        // POST: mano_obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mano_obras mano_obras = await db.mano_obras.FindAsync(id);
            db.mano_obras.Remove(mano_obras);
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
