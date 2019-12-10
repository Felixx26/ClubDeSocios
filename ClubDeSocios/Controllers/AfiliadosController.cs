using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubDeSocios.Models;

namespace ClubDeSocios.Controllers
{
    public class AfiliadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Afiliados
        public ActionResult Index()
        {
            var afiliadoes = db.Afiliados.Include(a => a.Socio);
            return View(afiliadoes.ToList());
        }

        // GET: Afiliados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // GET: Afiliados/Create
        public ActionResult Create()
        {
            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre");
            return View();
        }

        // POST: Afiliados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AfiliadoID,Nombre,Apellido,FechaNacimiento,Edad,Sexo,Direccion,Telefono,SocioID")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Afiliados.Add(afiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre", afiliado.SocioID);
            return View(afiliado);
        }

        // GET: Afiliados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre", afiliado.SocioID);
            return View(afiliado);
        }

        // POST: Afiliados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AfiliadoID,Nombre,Apellido,FechaNacimiento,Edad,Sexo,Direccion,Telefono,SocioID")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre", afiliado.SocioID);
            return View(afiliado);
        }

        // GET: Afiliados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afiliado afiliado = db.Afiliados.Find(id);
            db.Afiliados.Remove(afiliado);
            db.SaveChanges();
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
