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
    public class presupuestosController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: presupuestos
        public async Task<ActionResult> Index()
        {
            var presupuestos = db.presupuestos.Include(p => p.detalles).Include(p => p.detalles1).Include(p => p.detalles2).Include(p => p.detalles3).Include(p => p.detalles4).Include(p => p.detalles5).Include(p => p.detalles6).Include(p => p.detalles7).Include(p => p.detalles8).Include(p => p.detalles9).Include(p => p.detalles10).Include(p => p.detalles11).Include(p => p.detalles12).Include(p => p.detalles13).Include(p => p.detalles14).Include(p => p.espesores).Include(p => p.espesores1).Include(p => p.espesores2).Include(p => p.espesores3).Include(p => p.espesores4).Include(p => p.espesores5).Include(p => p.espesores6).Include(p => p.espesores7).Include(p => p.espesores8).Include(p => p.espesores9).Include(p => p.espesores10).Include(p => p.espesores11).Include(p => p.espesores12).Include(p => p.espesores13).Include(p => p.espesores14).Include(p => p.fletes).Include(p => p.mano_obras).Include(p => p.mano_obras1).Include(p => p.mat_esp_desc).Include(p => p.mat_esp_desc1).Include(p => p.mat_esp_desc2).Include(p => p.mat_esp_desc3).Include(p => p.mat_esp_desc4).Include(p => p.mat_esp_desc5).Include(p => p.mat_esp_desc6).Include(p => p.mat_esp_desc7).Include(p => p.mat_esp_desc8).Include(p => p.mat_esp_desc9).Include(p => p.mat_esp_desc10).Include(p => p.mat_esp_desc11).Include(p => p.mat_esp_desc12).Include(p => p.mat_esp_desc13).Include(p => p.mat_esp_desc14).Include(p => p.materias_primas).Include(p => p.materias_primas1).Include(p => p.materias_primas2).Include(p => p.materias_primas3).Include(p => p.materias_primas4).Include(p => p.materias_primas5).Include(p => p.materias_primas6).Include(p => p.materias_primas7).Include(p => p.materias_primas8).Include(p => p.materias_primas9).Include(p => p.materias_primas10).Include(p => p.materias_primas11).Include(p => p.materias_primas12).Include(p => p.materias_primas13).Include(p => p.materias_primas14);
            return View(await presupuestos.ToListAsync());
        }

        // GET: presupuestos/Details/5
        public async Task<ActionResult> Details(string idpro)
        {
            presupuestos pres = new presupuestos();
            var press = pres.pre_id.ToString();
            var idpre = from c in db.presupuestos
            where press == idpro
            select c.pre_id;

            
            
            
            if (idpre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presupuestos presupuestos = await db.presupuestos.FindAsync(idpre);
            if (presupuestos == null)
            {
                return HttpNotFound();
            }
            return View(presupuestos);
        }

        // GET: presupuestos/Create
        public ActionResult Create(int? id, string numero)
        {
            ViewBag.pre_detalle_mat11 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat2 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat3 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat5 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat6 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat7 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat9 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat10 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat12 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat13 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat14 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat15 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat4 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_detalle_mat8 = new SelectList(db.detalles, "det_id", "det_nombre");
            ViewBag.pre_espesor_mat14 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat10 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat11 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat12 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat13 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat15 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat2 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat3 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat4 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat5 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat6 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat7 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat9 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_espesor_mat8 = new SelectList(db.espesores, "esp_id", "esp_nombre");
            ViewBag.pre_flete = new SelectList(db.fletes, "fle_id", "fle_nombre");
            ViewBag.pre_mano_ayudante = new SelectList(db.mano_obras, "man_id", "man_nombre");
            ViewBag.pre_mano_maestro = new SelectList(db.mano_obras, "man_id", "man_nombre");
            //ViewBag.pre_mano_maestro2 = new SelectList(db.mano_obras, "man_id", "man_valor");
            ViewBag.pre_id_mat = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat10 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat11 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat12 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat13 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat14 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat15 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat2 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat3 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat4 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat5 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat6 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat7 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat8 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_id_mat9 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo");
            ViewBag.pre_mat = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat10 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat11 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat12 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat13 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat14 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat15 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat2 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat3 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat4 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat5 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat6 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat7 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat8 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_mat9 = new SelectList(db.materias_primas, "mat_id", "mat_nombre");
            ViewBag.pre_proyecto = new SelectList(db.proyectos, "pro_id", "pro_numero");
            //ViewBag.pre_proyecto2 = new SelectList(db.proyectos, "pro_id", "pro_nombre");
            ViewBag.proyecto = id;
            ViewBag.numProyecto = numero;
            return View();
        }

        // POST: presupuestos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pre_id,pre_nombre,pre_proyecto,pre_mano_maestro,pre_mano_ayudante,pre_total_mo,pre_id_mat,pre_mat,pre_detalle_mat,pre_espesor_mat,pre_cantidad_mat,pre_valor_mat,pre_neto_mat,pre_ut,pre_total_mat,pre_id_mat2,pre_mat2,pre_detalle_mat2,pre_espesor_mat2,pre_cantidad_mat2,pre_valor_mat2,pre_neto_mat2,pre_ut2,pre_total_mat2,pre_id_mat3,pre_mat3,pre_detalle_mat3,pre_espesor_mat3,pre_cantidad_mat3,pre_valor_mat3,pre_neto_mat3,pre_ut3,pre_total_mat3,pre_id_mat4,pre_mat4,pre_detalle_mat4,pre_espesor_mat4,pre_cantidad_mat4,pre_valor_mat4,pre_neto_mat4,pre_ut4,pre_total_mat4,pre_id_mat5,pre_mat5,pre_detalle_mat5,pre_espesor_mat5,pre_cantidad_mat5,pre_valor_mat5,pre_neto_mat5,pre_ut5,pre_total_mat5,pre_id_mat6,pre_mat6,pre_detalle_mat6,pre_espesor_mat6,pre_cantidad_mat6,pre_valor_mat6,pre_neto_mat6,pre_ut6,pre_total_mat6,pre_id_mat7,pre_mat7,pre_detalle_mat7,pre_espesor_mat7,pre_cantidad_mat7,pre_valor_mat7,pre_neto_mat7,pre_ut7,pre_total_mat7,pre_id_mat8,pre_mat8,pre_detalle_mat8,pre_espesor_mat8,pre_cantidad_mat8,pre_valor_mat8,pre_neto_mat8,pre_ut8,pre_total_mat8,pre_id_mat9,pre_mat9,pre_detalle_mat9,pre_espesor_mat9,pre_cantidad_mat9,pre_valor_mat9,pre_neto_mat9,pre_ut9,pre_total_mat9,pre_id_mat10,pre_mat10,pre_detalle_mat10,pre_espesor_mat10,pre_cantidad_mat10,pre_valor_mat10,pre_neto_mat10,pre_ut10,pre_total_mat10,pre_id_mat11,pre_mat11,pre_detalle_mat11,pre_espesor_mat11,pre_cantidad_mat11,pre_valor_mat11,pre_neto_mat11,pre_ut11,pre_total_mat11,pre_id_mat12,pre_mat12,pre_detalle_mat12,pre_espesor_mat12,pre_cantidad_mat12,pre_valor_mat12,pre_neto_mat12,pre_ut12,pre_total_mat12,pre_id_mat13,pre_mat13,pre_detalle_mat13,pre_espesor_mat13,pre_cantidad_mat13,pre_valor_mat13,pre_neto_mat13,pre_ut13,pre_total_mat13,pre_id_mat14,pre_mat14,pre_detalle_mat14,pre_espesor_mat14,pre_cantidad_mat14,pre_valor_mat14,pre_neto_mat14,pre_ut14,pre_total_mat14,pre_id_mat15,pre_mat15,pre_detalle_mat15,pre_espesor_mat15,pre_cantidad_mat15,pre_valor_mat15,pre_neto_mat15,pre_ut15,pre_total_mat15,pre_flete,pre_montaje,pre_varios,pre_total_neto,pre_total_ut,pre_total_bruto,total_materiales,pre_total_flete")] presupuestos presupuestos)
        {
            if (ModelState.IsValid)
            {
                db.presupuestos.Add(presupuestos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "proyectos");
            }

            ViewBag.pre_detalle_mat11 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat11);
            ViewBag.pre_detalle_mat2 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat2);
            ViewBag.pre_detalle_mat3 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat3);
            ViewBag.pre_detalle_mat5 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat5);
            ViewBag.pre_detalle_mat6 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat6);
            ViewBag.pre_detalle_mat7 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat7);
            ViewBag.pre_detalle_mat9 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat9);
            ViewBag.pre_detalle_mat = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat);
            ViewBag.pre_detalle_mat10 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat10);
            ViewBag.pre_detalle_mat12 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat12);
            ViewBag.pre_detalle_mat13 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat13);
            ViewBag.pre_detalle_mat14 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat14);
            ViewBag.pre_detalle_mat15 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat15);
            ViewBag.pre_detalle_mat4 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat4);
            ViewBag.pre_detalle_mat8 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat8);
            ViewBag.pre_espesor_mat14 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat14);
            ViewBag.pre_espesor_mat = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat);
            ViewBag.pre_espesor_mat10 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat10);
            ViewBag.pre_espesor_mat11 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat11);
            ViewBag.pre_espesor_mat12 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat12);
            ViewBag.pre_espesor_mat13 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat13);
            ViewBag.pre_espesor_mat15 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat15);
            ViewBag.pre_espesor_mat2 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat2);
            ViewBag.pre_espesor_mat3 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat3);
            ViewBag.pre_espesor_mat4 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat4);
            ViewBag.pre_espesor_mat5 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat5);
            ViewBag.pre_espesor_mat6 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat6);
            ViewBag.pre_espesor_mat7 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat7);
            ViewBag.pre_espesor_mat9 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat9);
            ViewBag.pre_espesor_mat8 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat8);
            ViewBag.pre_flete = new SelectList(db.fletes, "fle_id", "fle_nombre", presupuestos.pre_flete);
            ViewBag.pre_mano_ayudante = new SelectList(db.mano_obras, "man_id", "man_nombre", presupuestos.pre_mano_ayudante);
            ViewBag.pre_mano_maestro = new SelectList(db.mano_obras, "man_id", "man_nombre", presupuestos.pre_mano_maestro);
            ViewBag.pre_id_mat = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat);
            ViewBag.pre_id_mat10 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat10);
            ViewBag.pre_id_mat11 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat11);
            ViewBag.pre_id_mat12 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat12);
            ViewBag.pre_id_mat13 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat13);
            ViewBag.pre_id_mat14 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat14);
            ViewBag.pre_id_mat15 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat15);
            ViewBag.pre_id_mat2 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat2);
            ViewBag.pre_id_mat3 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat3);
            ViewBag.pre_id_mat4 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat4);
            ViewBag.pre_id_mat5 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat5);
            ViewBag.pre_id_mat6 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat6);
            ViewBag.pre_id_mat7 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat7);
            ViewBag.pre_id_mat8 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat8);
            ViewBag.pre_id_mat9 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat9);
            ViewBag.pre_mat = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat);
            ViewBag.pre_mat10 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat10);
            ViewBag.pre_mat11 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat11);
            ViewBag.pre_mat12 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat12);
            ViewBag.pre_mat13 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat13);
            ViewBag.pre_mat14 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat14);
            ViewBag.pre_mat15 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat15);
            ViewBag.pre_mat2 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat2);
            ViewBag.pre_mat3 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat3);
            ViewBag.pre_mat4 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat4);
            ViewBag.pre_mat5 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat5);
            ViewBag.pre_mat6 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat6);
            ViewBag.pre_mat7 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat7);
            ViewBag.pre_mat8 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat8);
            ViewBag.pre_mat9 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat9);
            ViewBag.pre_proyecto = new SelectList(db.proyectos, "pro_id", "pro_numero", presupuestos.pre_proyecto);
            return View(presupuestos);
        }

        // GET: presupuestos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presupuestos presupuestos = await db.presupuestos.FindAsync(id);
            if (presupuestos == null)
            {
                return HttpNotFound();
            }
            ViewBag.pre_detalle_mat11 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat11);
            ViewBag.pre_detalle_mat2 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat2);
            ViewBag.pre_detalle_mat3 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat3);
            ViewBag.pre_detalle_mat5 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat5);
            ViewBag.pre_detalle_mat6 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat6);
            ViewBag.pre_detalle_mat7 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat7);
            ViewBag.pre_detalle_mat9 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat9);
            ViewBag.pre_detalle_mat = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat);
            ViewBag.pre_detalle_mat10 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat10);
            ViewBag.pre_detalle_mat12 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat12);
            ViewBag.pre_detalle_mat13 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat13);
            ViewBag.pre_detalle_mat14 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat14);
            ViewBag.pre_detalle_mat15 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat15);
            ViewBag.pre_detalle_mat4 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat4);
            ViewBag.pre_detalle_mat8 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat8);
            ViewBag.pre_espesor_mat14 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat14);
            ViewBag.pre_espesor_mat = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat);
            ViewBag.pre_espesor_mat10 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat10);
            ViewBag.pre_espesor_mat11 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat11);
            ViewBag.pre_espesor_mat12 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat12);
            ViewBag.pre_espesor_mat13 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat13);
            ViewBag.pre_espesor_mat15 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat15);
            ViewBag.pre_espesor_mat2 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat2);
            ViewBag.pre_espesor_mat3 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat3);
            ViewBag.pre_espesor_mat4 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat4);
            ViewBag.pre_espesor_mat5 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat5);
            ViewBag.pre_espesor_mat6 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat6);
            ViewBag.pre_espesor_mat7 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat7);
            ViewBag.pre_espesor_mat9 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat9);
            ViewBag.pre_espesor_mat8 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat8);
            ViewBag.pre_flete = new SelectList(db.fletes, "fle_id", "fle_nombre", presupuestos.pre_flete);
            ViewBag.pre_mano_ayudante = new SelectList(db.mano_obras, "man_id", "man_nombre", presupuestos.pre_mano_ayudante);
            ViewBag.pre_mano_maestro = new SelectList(db.mano_obras, "man_id", "man_nombre", presupuestos.pre_mano_maestro);
            ViewBag.pre_id_mat = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat);
            ViewBag.pre_id_mat10 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat10);
            ViewBag.pre_id_mat11 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat11);
            ViewBag.pre_id_mat12 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat12);
            ViewBag.pre_id_mat13 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat13);
            ViewBag.pre_id_mat14 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat14);
            ViewBag.pre_id_mat15 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat15);
            ViewBag.pre_id_mat2 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat2);
            ViewBag.pre_id_mat3 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat3);
            ViewBag.pre_id_mat4 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat4);
            ViewBag.pre_id_mat5 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat5);
            ViewBag.pre_id_mat6 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat6);
            ViewBag.pre_id_mat7 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat7);
            ViewBag.pre_id_mat8 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat8);
            ViewBag.pre_id_mat9 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat9);
            ViewBag.pre_mat = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat);
            ViewBag.pre_mat10 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat10);
            ViewBag.pre_mat11 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat11);
            ViewBag.pre_mat12 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat12);
            ViewBag.pre_mat13 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat13);
            ViewBag.pre_mat14 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat14);
            ViewBag.pre_mat15 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat15);
            ViewBag.pre_mat2 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat2);
            ViewBag.pre_mat3 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat3);
            ViewBag.pre_mat4 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat4);
            ViewBag.pre_mat5 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat5);
            ViewBag.pre_mat6 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat6);
            ViewBag.pre_mat7 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat7);
            ViewBag.pre_mat8 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat8);
            ViewBag.pre_mat9 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat9);
            return View(presupuestos);
        }

        // POST: presupuestos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pre_id,pre_nombre,pre_proyecto,pre_mano_maestro,pre_mano_ayudante,pre_total_mo,pre_id_mat,pre_mat,pre_detalle_mat,pre_espesor_mat,pre_cantidad_mat,pre_valor_mat,pre_neto_mat,pre_ut,pre_total_mat,pre_id_mat2,pre_mat2,pre_detalle_mat2,pre_espesor_mat2,pre_cantidad_mat2,pre_valor_mat2,pre_neto_mat2,pre_ut2,pre_total_mat2,pre_id_mat3,pre_mat3,pre_detalle_mat3,pre_espesor_mat3,pre_cantidad_mat3,pre_valor_mat3,pre_neto_mat3,pre_ut3,pre_total_mat3,pre_id_mat4,pre_mat4,pre_detalle_mat4,pre_espesor_mat4,pre_cantidad_mat4,pre_valor_mat4,pre_neto_mat4,pre_ut4,pre_total_mat4,pre_id_mat5,pre_mat5,pre_detalle_mat5,pre_espesor_mat5,pre_cantidad_mat5,pre_valor_mat5,pre_neto_mat5,pre_ut5,pre_total_mat5,pre_id_mat6,pre_mat6,pre_detalle_mat6,pre_espesor_mat6,pre_cantidad_mat6,pre_valor_mat6,pre_neto_mat6,pre_ut6,pre_total_mat6,pre_id_mat7,pre_mat7,pre_detalle_mat7,pre_espesor_mat7,pre_cantidad_mat7,pre_valor_mat7,pre_neto_mat7,pre_ut7,pre_total_mat7,pre_id_mat8,pre_mat8,pre_detalle_mat8,pre_espesor_mat8,pre_cantidad_mat8,pre_valor_mat8,pre_neto_mat8,pre_ut8,pre_total_mat8,pre_id_mat9,pre_mat9,pre_detalle_mat9,pre_espesor_mat9,pre_cantidad_mat9,pre_valor_mat9,pre_neto_mat9,pre_ut9,pre_total_mat9,pre_id_mat10,pre_mat10,pre_detalle_mat10,pre_espesor_mat10,pre_cantidad_mat10,pre_valor_mat10,pre_neto_mat10,pre_ut10,pre_total_mat10,pre_id_mat11,pre_mat11,pre_detalle_mat11,pre_espesor_mat11,pre_cantidad_mat11,pre_valor_mat11,pre_neto_mat11,pre_ut11,pre_total_mat11,pre_id_mat12,pre_mat12,pre_detalle_mat12,pre_espesor_mat12,pre_cantidad_mat12,pre_valor_mat12,pre_neto_mat12,pre_ut12,pre_total_mat12,pre_id_mat13,pre_mat13,pre_detalle_mat13,pre_espesor_mat13,pre_cantidad_mat13,pre_valor_mat13,pre_neto_mat13,pre_ut13,pre_total_mat13,pre_id_mat14,pre_mat14,pre_detalle_mat14,pre_espesor_mat14,pre_cantidad_mat14,pre_valor_mat14,pre_neto_mat14,pre_ut14,pre_total_mat14,pre_id_mat15,pre_mat15,pre_detalle_mat15,pre_espesor_mat15,pre_cantidad_mat15,pre_valor_mat15,pre_neto_mat15,pre_ut15,pre_total_mat15,pre_flete,pre_montaje,pre_varios,pre_total_neto,pre_total_ut,pre_total_bruto,total_materiales,pre_total_flete")] presupuestos presupuestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuestos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.pre_detalle_mat11 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat11);
            ViewBag.pre_detalle_mat2 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat2);
            ViewBag.pre_detalle_mat3 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat3);
            ViewBag.pre_detalle_mat5 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat5);
            ViewBag.pre_detalle_mat6 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat6);
            ViewBag.pre_detalle_mat7 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat7);
            ViewBag.pre_detalle_mat9 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat9);
            ViewBag.pre_detalle_mat = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat);
            ViewBag.pre_detalle_mat10 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat10);
            ViewBag.pre_detalle_mat12 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat12);
            ViewBag.pre_detalle_mat13 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat13);
            ViewBag.pre_detalle_mat14 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat14);
            ViewBag.pre_detalle_mat15 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat15);
            ViewBag.pre_detalle_mat4 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat4);
            ViewBag.pre_detalle_mat8 = new SelectList(db.detalles, "det_id", "det_nombre", presupuestos.pre_detalle_mat8);
            ViewBag.pre_espesor_mat14 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat14);
            ViewBag.pre_espesor_mat = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat);
            ViewBag.pre_espesor_mat10 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat10);
            ViewBag.pre_espesor_mat11 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat11);
            ViewBag.pre_espesor_mat12 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat12);
            ViewBag.pre_espesor_mat13 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat13);
            ViewBag.pre_espesor_mat15 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat15);
            ViewBag.pre_espesor_mat2 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat2);
            ViewBag.pre_espesor_mat3 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat3);
            ViewBag.pre_espesor_mat4 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat4);
            ViewBag.pre_espesor_mat5 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat5);
            ViewBag.pre_espesor_mat6 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat6);
            ViewBag.pre_espesor_mat7 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat7);
            ViewBag.pre_espesor_mat9 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat9);
            ViewBag.pre_espesor_mat8 = new SelectList(db.espesores, "esp_id", "esp_nombre", presupuestos.pre_espesor_mat8);
            ViewBag.pre_flete = new SelectList(db.fletes, "fle_id", "fle_nombre", presupuestos.pre_flete);
            ViewBag.pre_mano_ayudante = new SelectList(db.mano_obras, "man_id", "man_nombre", presupuestos.pre_mano_ayudante);
            ViewBag.pre_mano_maestro = new SelectList(db.mano_obras, "man_id", "man_nombre", presupuestos.pre_mano_maestro);
            ViewBag.pre_id_mat = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat);
            ViewBag.pre_id_mat10 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat10);
            ViewBag.pre_id_mat11 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat11);
            ViewBag.pre_id_mat12 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat12);
            ViewBag.pre_id_mat13 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat13);
            ViewBag.pre_id_mat14 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat14);
            ViewBag.pre_id_mat15 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat15);
            ViewBag.pre_id_mat2 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat2);
            ViewBag.pre_id_mat3 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat3);
            ViewBag.pre_id_mat4 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat4);
            ViewBag.pre_id_mat5 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat5);
            ViewBag.pre_id_mat6 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat6);
            ViewBag.pre_id_mat7 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat7);
            ViewBag.pre_id_mat8 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat8);
            ViewBag.pre_id_mat9 = new SelectList(db.mat_esp_desc, "msd_id", "msd_codigo", presupuestos.pre_id_mat9);
            ViewBag.pre_mat = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat);
            ViewBag.pre_mat10 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat10);
            ViewBag.pre_mat11 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat11);
            ViewBag.pre_mat12 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat12);
            ViewBag.pre_mat13 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat13);
            ViewBag.pre_mat14 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat14);
            ViewBag.pre_mat15 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat15);
            ViewBag.pre_mat2 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat2);
            ViewBag.pre_mat3 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat3);
            ViewBag.pre_mat4 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat4);
            ViewBag.pre_mat5 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat5);
            ViewBag.pre_mat6 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat6);
            ViewBag.pre_mat7 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat7);
            ViewBag.pre_mat8 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat8);
            ViewBag.pre_mat9 = new SelectList(db.materias_primas, "mat_id", "mat_nombre", presupuestos.pre_mat9);
            return View(presupuestos);
        }

        // GET: presupuestos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presupuestos presupuestos = await db.presupuestos.FindAsync(id);
            if (presupuestos == null)
            {
                return HttpNotFound();
            }
            return View(presupuestos);
        }

        // POST: presupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            presupuestos presupuestos = await db.presupuestos.FindAsync(id);
            db.presupuestos.Remove(presupuestos);
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

        public ActionResult valorMO(int id)
        {
            var valor = from c in db.mano_obras
                        where c.man_id == id
                        select c.man_valor;

            return View(ViewBag.valor = valor);

        }
    }
}
