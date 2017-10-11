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
    public class estados_proyectosController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: estados_proyectos
        public async Task<ActionResult> Index()
        {
            return View(await db.estados_proyectos.ToListAsync());
        }

        // GET: estados_proyectos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estados_proyectos estados_proyectos = await db.estados_proyectos.FindAsync(id);
            if (estados_proyectos == null)
            {
                return HttpNotFound();
            }
            return View(estados_proyectos);
        }

        // GET: estados_proyectos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estados_proyectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "est_id,est_nombre")] estados_proyectos estados_proyectos)
        {
            if (ModelState.IsValid)
            {
                db.estados_proyectos.Add(estados_proyectos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(estados_proyectos);
        }

        // GET: estados_proyectos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estados_proyectos estados_proyectos = await db.estados_proyectos.FindAsync(id);
            if (estados_proyectos == null)
            {
                return HttpNotFound();
            }
            return View(estados_proyectos);
        }

        // POST: estados_proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "est_id,est_nombre")] estados_proyectos estados_proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estados_proyectos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estados_proyectos);
        }

        // GET: estados_proyectos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estados_proyectos estados_proyectos = await db.estados_proyectos.FindAsync(id);
            if (estados_proyectos == null)
            {
                return HttpNotFound();
            }
            return View(estados_proyectos);
        }

        // POST: estados_proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            estados_proyectos estados_proyectos = await db.estados_proyectos.FindAsync(id);
            db.estados_proyectos.Remove(estados_proyectos);
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
