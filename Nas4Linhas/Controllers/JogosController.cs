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
    public class JogosController : Controller
    {
        private Nas4LinhasDb db = new Nas4LinhasDb();

        // GET: Jogos
        public ActionResult Index()
        {
            var jogos = db.Jogos.Include(j => j.Competicao);
            return View(jogos.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome");
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogoID,EquipaVisitada,EquipaVisitante,Cartoes,Resultado,DataJogo,CompeticaoFK")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome", jogos.CompeticaoFK);
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome", jogos.CompeticaoFK);
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogoID,EquipaVisitada,EquipaVisitante,Cartoes,Resultado,DataJogo,CompeticaoFK")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompeticaoFK = new SelectList(db.Competicao, "CompeticaoID", "Nome", jogos.CompeticaoFK);
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogos jogos = db.Jogos.Find(id);
            db.Jogos.Remove(jogos);
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
