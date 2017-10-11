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
    public class clientesController : Controller
    {
        private espacio_diseno_bdEntities db = new espacio_diseno_bdEntities();

        // GET: clientes
        public async Task<ActionResult> Index()
        {
            return View(await db.clientes.ToListAsync());
        }

        // GET: clientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cli_id,cli_rut,cli_nombre,cli_contacto,cli_telefono,cli_correo,cli_direccion")] clientes clientes)
        {
            // validamos ruts ingresados
            string rut = clientes.cli_rut;
            if (!validarRut(rut))
            {
                ModelState.AddModelError("", "Rut invalido");
                Response.Write("<script>window.alert('Rut invalido');</script>");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //formateamos rut ingresados (. -)
                    clientes.cli_rut = formatearRut(rut);
                    db.clientes.Add(clientes);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Ya existe registro del cliente " + clientes.cli_rut);
                Response.Write("<script>window.alert('Ya existe registro del cliente ');</script>");
            }

            return View(clientes);
        }

        // GET: clientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cli_id,cli_rut,cli_nombre,cli_contacto,cli_telefono,cli_correo,cli_direccion")] clientes clientes)
        {
            // validamos ruts ingresados
            string rut = clientes.cli_rut;
            if (!validarRut(rut))
            {
                ModelState.AddModelError("", "Rut invalido");
                Response.Write("<script>window.alert('Rut invalido');</script>");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //formateamos rut ingresados (. -)
                    clientes.cli_rut = formatearRut(rut);
                    db.Entry(clientes).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Ya existe registro del cliente " + clientes.cli_rut);
                Response.Write("<script>window.alert('Ya existe registro del cliente ');</script>");
            }
            return View(clientes);
        }

        // GET: clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            clientes clientes = await db.clientes.FindAsync(id);
            db.clientes.Remove(clientes);
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
        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
        public string formatearRut(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
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
