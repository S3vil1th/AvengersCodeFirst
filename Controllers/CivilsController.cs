using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test13.DAL;
using Test13.Models;

namespace Test13.Controllers
{
    public class CivilsController : Controller
    {
        private AvengersContext db = new AvengersContext();

        // GET: Civils
        public ActionResult Index()
        {
            var civils = db.Civils.Include(c => c.Heros).Include(c => c.Mechant).Include(c => c.Utilisateur);
            return View(civils.ToList());
        }

        // GET: Civils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Civil civil = db.Civils.Find(id);
            if (civil == null)
            {
                return HttpNotFound();
            }
            return View(civil);
        }

        // GET: Civils/Create
        public ActionResult Create()
        {
            ViewBag.CivilID = new SelectList(db.Heros, "HerosID", "Pseudonyme");
            ViewBag.CivilID = new SelectList(db.Mechants, "MechantID", "Pseudonyme");
            ViewBag.CivilID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email");
            return View();
        }

        // POST: Civils/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CivilID,Prenom,Nom,Civilite,Date_de_naissance,Date_de_deces")] Civil civil)
        {
            if (ModelState.IsValid)
            {
                db.Civils.Add(civil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilID = new SelectList(db.Heros, "HerosID", "Pseudonyme", civil.CivilID);
            ViewBag.CivilID = new SelectList(db.Mechants, "MechantID", "Pseudonyme", civil.CivilID);
            ViewBag.CivilID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email", civil.CivilID);
            return View(civil);
        }

        // GET: Civils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Civil civil = db.Civils.Find(id);
            if (civil == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilID = new SelectList(db.Heros, "HerosID", "Pseudonyme", civil.CivilID);
            ViewBag.CivilID = new SelectList(db.Mechants, "MechantID", "Pseudonyme", civil.CivilID);
            ViewBag.CivilID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email", civil.CivilID);
            return View(civil);
        }

        // POST: Civils/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CivilID,Prenom,Nom,Civilite,Date_de_naissance,Date_de_deces")] Civil civil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(civil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilID = new SelectList(db.Heros, "HerosID", "Pseudonyme", civil.CivilID);
            ViewBag.CivilID = new SelectList(db.Mechants, "MechantID", "Pseudonyme", civil.CivilID);
            ViewBag.CivilID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email", civil.CivilID);
            return View(civil);
        }

        // GET: Civils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Civil civil = db.Civils.Find(id);
            if (civil == null)
            {
                return HttpNotFound();
            }
            return View(civil);
        }

        // POST: Civils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Civil civil = db.Civils.Find(id);
            db.Civils.Remove(civil);
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
