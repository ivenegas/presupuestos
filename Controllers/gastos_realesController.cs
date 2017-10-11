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
    public class gastos_realesController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: gastos_reales
        public async Task<ActionResult> Index()
        {
            var gastos_reales = db.gastos_reales.Include(g => g.proyectos);
            return View(await gastos_reales.ToListAsync());
        }

        // GET: gastos_reales/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gastos_reales gastos_reales = await db.gastos_reales.FindAsync(id);
            if (gastos_reales == null)
            {
                return HttpNotFound();
            }
            return View(gastos_reales);
        }

        // GET: gastos_reales/Create
        public ActionResult Create(int id, int? num, int? est, string nom, int? mo, int? mat, int? fle, int? mon, int? va, int? net, int? uti, int? tot)
        {
            ViewBag.idpro = id;
            ViewBag.numpro = num;
            ViewBag.nombre = nom;
            ViewBag.mo = mo;
            ViewBag.mat = mat;
            ViewBag.mon = mon;
            ViewBag.fle = fle;
            ViewBag.va = va;
            ViewBag.net = net;
            ViewBag.uti = uti;
            ViewBag.tot = tot;

            List<gastos_reales> gastosList = db.gastos_reales.ToList();
            GastosProyectosViewModels gastosVM = new GastosProyectosViewModels();

            List<GastosProyectosViewModels> gastosVMList = gastosList.Select(x => new GastosProyectosViewModels
            {
                gas_id_proyecto = x.gas_id_proyecto,
                gas_mat_real = x.gas_mat_real,
                gas_flete_real = x.gas_flete_real,
                gas_montaje_real = x.gas_montaje_real,
                gas_mo_real = x.gas_mo_real,
                gas_neto_real = x.gas_neto_real,
                gas_total_real = x.gas_total_real,
                gas_varios_real = x.gas_varios_real,
               gas_uti_real = x.gas_uti_real,
               gas_id = x.gas_id

            }).ToList();

            var gasto = (from c in db.gastos_reales
                        join d in db.proyectos on c.gas_id_proyecto equals d.pro_id
                        where d.pro_id == id
                        select d).ToList();

            var press = (from d in gastosVMList
                         where d.gas_id_proyecto == id
                         select d).ToList();

            ViewBag.presupuesto = press;


            ViewBag.gas_id_proyecto = new SelectList(db.proyectos, "pro_id", "pro_numero");
            return View();
        }

        // POST: gastos_reales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "gas_id,gas_id_proyecto,gas_mo_real,gas_mat_real,gas_flete_real,gas_montaje_real,gas_varios_real,gas_mo_pre,gas_mat_pre,gas_flete_pre,gas_montaje_pre,gas_varios_pre,gas_neto_real,gas_neto_pre,gas_uti_real,gas_uti_pre,gas_total_real,gas_total_pre, gas_estado")] gastos_reales gastos_reales)
        {
            if (ModelState.IsValid)
            {
                gastos_reales.gas_estado = 1;
                db.gastos_reales.Add(gastos_reales);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "proyectos");
            }

            ViewBag.gas_id_proyecto = new SelectList(db.proyectos, "pro_id", "pro_numero", gastos_reales.gas_id_proyecto);
            return View(gastos_reales);
        }

        // GET: gastos_reales/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gastos_reales gastos_reales = await db.gastos_reales.FindAsync(id);
            if (gastos_reales == null)
            {
                return HttpNotFound();
            }
            ViewBag.gas_id_proyecto = new SelectList(db.proyectos, "pro_id", "pro_numero", gastos_reales.gas_id_proyecto);
            return View(gastos_reales);
        }

        // POST: gastos_reales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "gas_id,gas_id_proyecto,gas_mo_real,gas_mat_real,gas_flete_real,gas_montaje_real,gas_varios_real,gas_mo_pre,gas_mat_pre,gas_flete_pre,gas_montaje_pre,gas_varios_pre,gas_neto_real,gas_neto_pre,gas_uti_real,gas_uti_pre,gas_total_real,gas_total_pre,gas_estado")] gastos_reales gastos_reales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gastos_reales).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.gas_id_proyecto = new SelectList(db.proyectos, "pro_id", "pro_numero", gastos_reales.gas_id_proyecto);
            return View(gastos_reales);
        }

        // GET: gastos_reales/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gastos_reales gastos_reales = await db.gastos_reales.FindAsync(id);
            if (gastos_reales == null)
            {
                return HttpNotFound();
            }
            return View(gastos_reales);
        }

        // POST: gastos_reales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            gastos_reales gastos_reales = await db.gastos_reales.FindAsync(id);
            db.gastos_reales.Remove(gastos_reales);
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
