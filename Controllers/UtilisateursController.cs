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
    public class UtilisateursController : Controller
    {
        private AvengersContext db = new AvengersContext();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Civil).Include(u => u.Organisation).Include(u => u.Pays);
            return View(utilisateurs.ToList());
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.UtilisateurID = new SelectList(db.Civils, "CivilID", "Prenom");
            ViewBag.UtilisateurID = new SelectList(db.Organisations, "OrganisationID", "Denomination");
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom");
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UtilisateurID,Email,Numéro_Telephone,Adresse,PaysID")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilisateurID = new SelectList(db.Civils, "CivilID", "Prenom", utilisateur.UtilisateurID);
            ViewBag.UtilisateurID = new SelectList(db.Organisations, "OrganisationID", "Denomination", utilisateur.UtilisateurID);
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom", utilisateur.PaysID);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.UtilisateurID = new SelectList(db.Civils, "CivilID", "Prenom", utilisateur.UtilisateurID);
            ViewBag.UtilisateurID = new SelectList(db.Organisations, "OrganisationID", "Denomination", utilisateur.UtilisateurID);
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom", utilisateur.PaysID);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UtilisateurID,Email,Numéro_Telephone,Adresse,PaysID")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilisateurID = new SelectList(db.Civils, "CivilID", "Prenom", utilisateur.UtilisateurID);
            ViewBag.UtilisateurID = new SelectList(db.Organisations, "OrganisationID", "Denomination", utilisateur.UtilisateurID);
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom", utilisateur.PaysID);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateur);
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
