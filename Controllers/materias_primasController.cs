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
    public class materias_primasController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: materias_primas
        public async Task<ActionResult> Index()
        {
            return View(await db.materias_primas.ToListAsync());
        }

        // GET: materias_primas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materias_primas materias_primas = await db.materias_primas.FindAsync(id);
            if (materias_primas == null)
            {
                return HttpNotFound();
            }
            return View(materias_primas);
        }

        // GET: materias_primas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: materias_primas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "mat_id,mat_nombre")] materias_primas materias_primas)
        {
            if (ModelState.IsValid)
            {
                db.materias_primas.Add(materias_primas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(materias_primas);
        }

        // GET: materias_primas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materias_primas materias_primas = await db.materias_primas.FindAsync(id);
            if (materias_primas == null)
            {
                return HttpNotFound();
            }
            return View(materias_primas);
        }

        // POST: materias_primas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "mat_id,mat_nombre")] materias_primas materias_primas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materias_primas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(materias_primas);
        }

        // GET: materias_primas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materias_primas materias_primas = await db.materias_primas.FindAsync(id);
            if (materias_primas == null)
            {
                return HttpNotFound();
            }
            return View(materias_primas);
        }

        // POST: materias_primas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            materias_primas materias_primas = await db.materias_primas.FindAsync(id);
            db.materias_primas.Remove(materias_primas);
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
