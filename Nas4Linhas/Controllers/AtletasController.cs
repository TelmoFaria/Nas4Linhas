using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nas4Linhas.Models;

namespace Nas4Linhas.Controllers
{
    public class AtletasController : Controller
    {
        private Nas4LinhasDb db = new Nas4LinhasDb();

        // GET: Atletas
        public ActionResult Index()
        {
            var atletas = db.Atletas.Include(a => a.Equipas);
            return View(atletas.ToList());
        }

        // GET: Atletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atletas atletas = db.Atletas.Find(id);
            if (atletas == null)
            {
                return HttpNotFound();
            }
            return View(atletas);
        }

        // GET: Atletas/Create
        public ActionResult Create()
        {
            ViewBag.EquipasFK = new SelectList(db.Equipas, "EquipaID", "NomeEquipa");
            return View();
        }

        // POST: Atletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtletaID,Nome,Nacionalidade,Golos,DataNasc,Jogos,EquipasFK")] Atletas atletas)
        {
            if (ModelState.IsValid)
            {
                db.Atletas.Add(atletas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipasFK = new SelectList(db.Equipas, "EquipaID", "NomeEquipa", atletas.EquipasFK);
            return View(atletas);
        }

        // GET: Atletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atletas atletas = db.Atletas.Find(id);
            if (atletas == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipasFK = new SelectList(db.Equipas, "EquipaID", "NomeEquipa", atletas.EquipasFK);
            return View(atletas);
        }

        // POST: Atletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtletaID,Nome,Nacionalidade,Golos,DataNasc,Jogos,EquipasFK")] Atletas atletas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atletas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipasFK = new SelectList(db.Equipas, "EquipaID", "NomeEquipa", atletas.EquipasFK);
            return View(atletas);
        }

        // GET: Atletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atletas atletas = db.Atletas.Find(id);
            if (atletas == null)
            {
                return HttpNotFound();
            }
            return View(atletas);
        }

        // POST: Atletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atletas atletas = db.Atletas.Find(id);
            db.Atletas.Remove(atletas);
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
