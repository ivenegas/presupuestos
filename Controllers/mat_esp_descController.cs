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
    public class mat_esp_descController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: mat_esp_desc
        public async Task<ActionResult> Index()
        {
            var mat_esp_desc = db.mat_esp_desc.Include(m => m.detalles).Include(m => m.espesores).Include(m => m.materias_primas);
            return View(await mat_esp_desc.ToListAsync());
        }

        // GET: mat_esp_desc/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mat_esp_desc mat_esp_desc = await db.mat_esp_desc.FindAsync(id);
            if (mat_esp_desc == null)
            {
                return HttpNotFound();
            }
            return View(mat_esp_desc);
        }

        // GET: mat_esp_desc/Create
        public ActionResult Create()
        {
            ViewBag.msd_id_detalle = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.msd_id_espesor = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.msd_id_material = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            return View();
        }

        // POST: mat_esp_desc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "msd_id,msd_codigo,msd_id_material,msd_id_espesor,msd_id_detalle,msd_valor")] mat_esp_desc mat_esp_desc)
        {
            if (ModelState.IsValid)
            {
                db.mat_esp_desc.Add(mat_esp_desc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.msd_id_detalle = new SelectList(db.detalles, "det_id", "det_nombre", mat_esp_desc.msd_id_detalle);
            ViewBag.msd_id_espesor = new SelectList(db.espesores, "esp_id", "esp_nombre", mat_esp_desc.msd_id_espesor);
            ViewBag.msd_id_material = new SelectList(db.materias_primas, "mat_id", "mat_nombre", mat_esp_desc.msd_id_material);
            return View(mat_esp_desc);
        }

        // GET: mat_esp_desc/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mat_esp_desc mat_esp_desc = await db.mat_esp_desc.FindAsync(id);
            if (mat_esp_desc == null)
            {
                return HttpNotFound();
            }
            ViewBag.msd_id_detalle = new SelectList(db.detalles, "det_id", "det_nombre", mat_esp_desc.msd_id_detalle);
            ViewBag.msd_id_espesor = new SelectList(db.espesores, "esp_id", "esp_nombre", mat_esp_desc.msd_id_espesor);
            ViewBag.msd_id_material = new SelectList(db.materias_primas, "mat_id", "mat_nombre", mat_esp_desc.msd_id_material);
            return View(mat_esp_desc);
        }

        // POST: mat_esp_desc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "msd_id,msd_codigo,msd_id_material,msd_id_espesor,msd_id_detalle,msd_valor")] mat_esp_desc mat_esp_desc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mat_esp_desc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.msd_id_detalle = new SelectList(db.detalles, "det_id", "det_nombre", mat_esp_desc.msd_id_detalle);
            ViewBag.msd_id_espesor = new SelectList(db.espesores, "esp_id", "esp_nombre", mat_esp_desc.msd_id_espesor);
            ViewBag.msd_id_material = new SelectList(db.materias_primas, "mat_id", "mat_nombre", mat_esp_desc.msd_id_material);
            return View(mat_esp_desc);
        }

        // GET: mat_esp_desc/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mat_esp_desc mat_esp_desc = await db.mat_esp_desc.FindAsync(id);
            if (mat_esp_desc == null)
            {
                return HttpNotFound();
            }
            return View(mat_esp_desc);
        }

        // POST: mat_esp_desc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mat_esp_desc mat_esp_desc = await db.mat_esp_desc.FindAsync(id);
            db.mat_esp_desc.Remove(mat_esp_desc);
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
