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
    public class IncidentsController : Controller
    {
        private AvengersContext db = new AvengersContext();

        // GET: Incidents
        public ActionResult Index()
        {
            var incidents = db.Incidents.Include(i => i.Incident_Motif).Include(i => i.Pays).Include(i => i.Utilisateur);
            return View(incidents.ToList());
        }

        // GET: Incidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incidents/Create
        public ActionResult Create()
        {
            ViewBag.Incident_MotifID = new SelectList(db.Incident_Motifs, "Incident_MotifID", "Motif");
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom");
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email");
            return View();
        }

        // POST: Incidents/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncidentID,UtilisateurID,Incident_MotifID,PaysID,Contexte,Adresse,Date_Incident")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Incidents.Add(incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Incident_MotifID = new SelectList(db.Incident_Motifs, "Incident_MotifID", "Motif", incident.Incident_MotifID);
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom", incident.PaysID);
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email", incident.UtilisateurID);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.Incident_MotifID = new SelectList(db.Incident_Motifs, "Incident_MotifID", "Motif", incident.Incident_MotifID);
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom", incident.PaysID);
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email", incident.UtilisateurID);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncidentID,UtilisateurID,Incident_MotifID,PaysID,Contexte,Adresse,Date_Incident")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Incident_MotifID = new SelectList(db.Incident_Motifs, "Incident_MotifID", "Motif", incident.Incident_MotifID);
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Pays_nom", incident.PaysID);
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "Email", incident.UtilisateurID);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident incident = db.Incidents.Find(id);
            db.Incidents.Remove(incident);
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
