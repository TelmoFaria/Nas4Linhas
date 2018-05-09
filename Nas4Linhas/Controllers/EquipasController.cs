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
    public class EquipasController : Controller
    {
        private Nas4LinhasDb db = new Nas4LinhasDb();

        // GET: Equipas
        public ActionResult Index()
        {
            var equipas = db.Equipas.Include(e => e.Competicao);
            return View(equipas.ToList());
        }

        // GET: Equipas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // GET: Equipas/Create
        public ActionResult Create()
        {
            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome");
            return View();
        }

        // POST: Equipas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipaID,NomeEquipa,Classificacao,Vitorias,Empates,Derrotas,Logo,CompeticaoFK")] Equipas equipas)
        {
            if (ModelState.IsValid)
            {
                db.Equipas.Add(equipas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome", equipas.CompeticaoFK);
            return View(equipas);
        }

        // GET: Equipas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome", equipas.CompeticaoFK);
            return View(equipas);
        }

        // POST: Equipas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipaID,NomeEquipa,Classificacao,Vitorias,Empates,Derrotas,Logo,CompeticaoFK")] Equipas equipas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome", equipas.CompeticaoFK);
            return View(equipas);
        }

        // GET: Equipas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipas equipas = db.Equipas.Find(id);
            db.Equipas.Remove(equipas);
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
