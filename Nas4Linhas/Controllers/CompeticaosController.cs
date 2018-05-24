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
    public class CompeticaosController : Controller
    {
        private Nas4LinhasDb db = new Nas4LinhasDb();

        // GET: Competicaos
        public ActionResult Index()
        {
            return View(db.Competicao.ToList());
        }

        // GET: Competicaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicao competicao = db.Competicao.Find(id);
            if (competicao == null)
            {
                return HttpNotFound();
            }
            return View(competicao);
        }

        // GET: Competicaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competicaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompeticaoID,Nome,Pais")] Competicao competicao)
        {
            if (ModelState.IsValid)
            {
                db.Competicao.Add(competicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competicao);
        }

        // GET: Competicaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicao competicao = db.Competicao.Find(id);
            if (competicao == null)
            {
                return HttpNotFound();
            }
            return View(competicao);
        }

        // POST: Competicaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompeticaoID,Nome,Pais")] Competicao competicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competicao);
        }

        // GET: Competicaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicao competicao = db.Competicao.Find(id);
            if (competicao == null)
            {
                return HttpNotFound();
            }
            return View(competicao);
        }

        // POST: Competicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competicao competicao = db.Competicao.Find(id);
            db.Competicao.Remove(competicao);
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
