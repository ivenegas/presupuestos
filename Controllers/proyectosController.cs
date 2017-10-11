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
using System.Dynamic;

namespace espaciodiseno.Controllers
{
    [Authorize]
    public class proyectosController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: proyectos
        public async Task<ActionResult> Index()

        {
            var proyectos = db.proyectos.Include(p => p.clientes).Include(p => p.condiciones_pago).Include(p => p.estados_proyectos);
            return View(await proyectos.ToListAsync());
        }

        // GET: proyectos/Details/5
        public async Task<ActionResult> Details(int id, int? est, string img)
        {
            ViewBag.img = img;
            if (est == 2)
            {
                var ide = id;
                return RedirectToAction("pdf", new { id = id });
            }
            else
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
           
            List<presupuestos> proyectosList = db.presupuestos.ToList();
            proyectosViewModel proyectosVM = new proyectosViewModel();

            List<proyectosViewModel> proyectosVMList = proyectosList.Select(x => new proyectosViewModel
            {
                pre_proyecto = x.pre_proyecto,
                pre_nombre = x.pre_nombre,
                pre_id = x.pre_id,
                pre_total_mo = x. pre_total_mo,
                pre_montaje = x.pre_montaje,
                pre_varios = x.pre_varios,
                pre_total_neto = x. pre_total_neto,
                pre_total_ut = x.pre_total_ut,
                pre_total_flete = x.pre_total_flete,
                pre_total_bruto = x.pre_total_bruto,
                total_materiales = x.total_materiales,
                
            }).ToList();

                var pres = (from c in db.proyectos
                            join d in db.presupuestos on c.pro_id equals d.pre_proyecto
                            where d.pre_proyecto == id
                            select d).ToList();

                var press = (from d in proyectosVMList
                             where d.pre_proyecto == id
                             select d).ToList();

                ViewBag.presupuesto = press;

                var sumamo = press.Sum(x => x.pre_total_mo);
                ViewBag.sumamo = sumamo;
                var sumamat = press.Sum(x => x.total_materiales);
                ViewBag.sumamat = sumamat;
                var sumaflet = press.Sum(x => x.pre_total_flete);
                ViewBag.sumaflet = sumaflet;
                var sumamont = press.Sum(x => x.pre_montaje);
                ViewBag.sumamont = sumamont;
                var sumavar = press.Sum(x => x.pre_varios);
                ViewBag.sumavar = sumavar;
                var sumaneto = press.Sum(x => x.pre_total_neto);
                ViewBag.sumaneto = sumaneto;
                var sumamg = press.Sum(x => x.pre_total_ut);
                ViewBag.sumamg = sumamg;
                var sumapres = press.Sum(x => x.pre_total_bruto);

                ViewBag.sumapres = sumapres;
                return View(proyectos);
            }
            return View();
        }
       

        // GET: proyectos/Create
        public ActionResult Create(string imga)
        {
            ViewBag.img = imga;
            ViewBag.pro_cliente = new SelectList(db.clientes, "cli_id", "cli_nombre");
            ViewBag.pro_condicion = new SelectList(db.condiciones_pago, "con_id", "con_nombre");
            ViewBag.pro_estado = new SelectList(db.estados_proyectos, "est_id", "est_nombre");
            //asigancíon automatica del numero de proyecto
            var cont = from c in db.proyectos select c;
            int cont2 = cont.Count() + 1;
            ViewBag.numero = cont2;
            return View();
        }

        // POST: proyectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pro_id,pro_nombre,pro_numero,pro_cliente,pro_fecha,pro_descripcion,pro_plazo,pro_condicion,pro_img,pro_mo,pro_material,pro_flete,pro_montaje,pro_varios,pro_neto,pro_utilidad,pro_total_presupuesto,pro_estado")] proyectos proyectos)
        {
            if (ModelState.IsValid)
            {

                proyectos.pro_estado = 1;
                var numero = proyectos.pro_numero;
                numero = numero +  DateTime.Now.Year;
                proyectos.pro_numero = numero;
                db.proyectos.Add(proyectos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.pro_cliente = new SelectList(db.clientes, "cli_id", "cli_nombre", proyectos.pro_cliente);
            ViewBag.pro_condicion = new SelectList(db.condiciones_pago, "con_id", "con_nombre", proyectos.pro_condicion);
            ViewBag.pro_estado = new SelectList(db.estados_proyectos, "est_id", "est_nombre", proyectos.pro_estado);
            return View(proyectos);
        }

        public ActionResult Editar(int id, int? mo, int? mat, int? fle, int? mon,int? va, int? net, int? mg, int? tot)
        {
            var pro = new proyectos { pro_id = id };
            using (var context = new espacio_diseno_bdEntities())
            {

                context.proyectos.Attach(pro);
                pro.pro_mo = mo;
                pro.pro_montaje = mon;
                pro.pro_material = mat;
                pro.pro_flete = fle;
                pro.pro_varios = va;
                pro.pro_neto = net;
                pro.pro_utilidad= mg;
                pro.pro_total_presupuesto = tot;
                pro.pro_estado = 2;
                
                context.Configuration.ValidateOnSaveEnabled = false;
                context.SaveChanges();

            }
            return RedirectToAction("Index");
        }


        // GET: proyectos/Edit/5
        public async Task<ActionResult> Edit(int? id, int? num, int? est, string img)
        {
            ViewBag.img = img;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.pro_cliente = new SelectList(db.clientes, "cli_id", "cli_nombre", proyectos.pro_cliente);
            ViewBag.pro_condicion = new SelectList(db.condiciones_pago, "con_id", "con_nombre", proyectos.pro_condicion);
            ViewBag.pro_estado = new SelectList(db.estados_proyectos, "est_id", "est_nombre", proyectos.pro_estado);
            ViewBag.numeroE = num;
            ViewBag.est = est;
            return View(proyectos);
        }

        // POST: proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pro_id,pro_nombre,pro_numero,pro_cliente,pro_fecha,pro_descripcion,pro_plazo,pro_condicion,pro_img")] proyectos proyectos)
        {

            if (ModelState.IsValid)
            {
                proyectos.pro_estado = 1;
                db.Entry(proyectos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.pro_cliente = new SelectList(db.clientes, "cli_id", "cli_rut", proyectos.pro_cliente);
            ViewBag.pro_condicion = new SelectList(db.condiciones_pago, "con_id", "con_nombre", proyectos.pro_condicion);
            ViewBag.pro_estado = new SelectList(db.estados_proyectos, "est_id", "est_nombre", proyectos.pro_estado);
            return View(proyectos);
        }

        // GET: proyectos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // POST: proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            proyectos proyectos = await db.proyectos.FindAsync(id);
            db.proyectos.Remove(proyectos);
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

        // GET: proyectos/Edit/5
        public async Task<ActionResult> agregarPresupuesto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.pro_cliente = new SelectList(db.clientes, "cli_id", "cli_rut", proyectos.pro_cliente);
            ViewBag.pro_condicion = new SelectList(db.condiciones_pago, "con_id", "con_nombre", proyectos.pro_condicion);
            ViewBag.pro_estado = new SelectList(db.estados_proyectos, "est_id", "est_id", proyectos.pro_estado);
            return View(proyectos);
        }

        // POST: proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> agregarPresupuesto([Bind(Include = "pro_id,pro_nombre,pro_numero,pro_cliente,pro_fecha,pro_descripcion,pro_plazo,pro_condicion,pro_img,pro_mo,pro_material,pro_flete,pro_montaje,pro_varios,pro_neto,pro_utilidad,pro_total_presupuesto,pro_estado")] proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyectos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.pro_cliente = new SelectList(db.clientes, "cli_id", "cli_rut", proyectos.pro_cliente);
            ViewBag.pro_condicion = new SelectList(db.condiciones_pago, "con_id", "con_nombre", proyectos.pro_condicion);
            ViewBag.pro_estado = new SelectList(db.estados_proyectos, "est_id", "est_id", proyectos.pro_estado);
            return View(proyectos);
        }

        public async Task<ActionResult> pdf(int? id, bool pdf = false)
        {
            ViewBag.PDF = pdf;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            List<presupuestos> proyectosList = db.presupuestos.ToList();
            proyectosViewModel proyectosVM = new proyectosViewModel();

            List<proyectosViewModel> proyectosVMList = proyectosList.Select(x => new proyectosViewModel
            {
                pre_proyecto = x.pre_proyecto,
                pre_nombre = x.pre_nombre,
                pre_id = x.pre_id,
                pre_total_mo = x.pre_total_mo,
                pre_montaje = x.pre_montaje,
                pre_varios = x.pre_varios,
                pre_total_neto = x.pre_total_neto,
                pre_total_ut = x.pre_total_ut,
                pre_total_flete = x.pre_total_flete,
                pre_total_bruto = x.pre_total_bruto,
                total_materiales = x.total_materiales,

            }).ToList();

            var pres = (from c in db.proyectos
                        join d in db.presupuestos on c.pro_id equals d.pre_proyecto
                        where d.pre_proyecto == id
                        select d).ToList();

            var press = (from d in proyectosVMList
                         where d.pre_proyecto == id
                         select d).ToList();

            ViewBag.presupuesto = press;

            var sumamo = press.Sum(x => x.pre_total_mo);
            ViewBag.sumamo = sumamo;
            var sumamat = press.Sum(x => x.total_materiales);
            ViewBag.sumamat = sumamat;
            var sumaflet = press.Sum(x => x.pre_total_flete);
            ViewBag.sumaflet = sumaflet;
            var sumamont = press.Sum(x => x.pre_montaje);
            ViewBag.sumamont = sumamont;
            var sumaneto = press.Sum(x => x.pre_total_neto);
            ViewBag.sumaneto = sumaneto;
            var sumamg = press.Sum(x => x.pre_total_ut);
            ViewBag.sumamg = sumamg;
            var sumapres = press.Sum(x => x.pre_total_bruto);
            var monto = formatearMonto(sumapres.Value.ToString());
            ViewBag.sumapres = monto;
            return View(proyectos);
        }

        public ActionResult generarPdf(int? id)
        {
            var cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            return new Rotativa.ActionAsPdf("pdf", new { id = id, pdf = true })
            { FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName, Cookies = cookies
            };
        }


        // GUARDAR IMAGEN
        [HttpPost]
        public ActionResult Img(HttpPostedFileBase file)
        {
            string path = System.IO.Path.Combine(Server.MapPath("~/Content/Img"), System.IO.Path.GetFileName(file.FileName));
            file.SaveAs(path);
            var url = file.FileName;
            return RedirectToAction("create", "proyectos", new { imga = url });
        }
        public ActionResult cargarImg()
        {
            return View();
        }
        [HttpPost]

        //AGREGAR PUNTOS A LOS MONTOS INGRESADOS
        public string formatearMonto(string monto)
        {
            int cont = 0;
            string format;
            if (monto.Length == 0)
            {
                return "";
            }
            else
            {
                monto = monto.Replace(".", "");

                format = "";
                for (int i = monto.Length - 1; i >= 0; i--)
                {
                    format = monto.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

    }
}
