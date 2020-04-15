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
    public class Incident_MotifController : Controller
    {
        private AvengersContext db = new AvengersContext();

        // GET: Incident_Motif
        public ActionResult Index()
        {
            return View(db.Incident_Motifs.ToList());
        }

        // GET: Incident_Motif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident_Motif incident_Motif = db.Incident_Motifs.Find(id);
            if (incident_Motif == null)
            {
                return HttpNotFound();
            }
            return View(incident_Motif);
        }

        // GET: Incident_Motif/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incident_Motif/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Incident_MotifID,Motif,Motif_Symbole")] Incident_Motif incident_Motif)
        {
            if (ModelState.IsValid)
            {
                db.Incident_Motifs.Add(incident_Motif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incident_Motif);
        }

        // GET: Incident_Motif/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident_Motif incident_Motif = db.Incident_Motifs.Find(id);
            if (incident_Motif == null)
            {
                return HttpNotFound();
            }
            return View(incident_Motif);
        }

        // POST: Incident_Motif/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Incident_MotifID,Motif,Motif_Symbole")] Incident_Motif incident_Motif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident_Motif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incident_Motif);
        }

        // GET: Incident_Motif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident_Motif incident_Motif = db.Incident_Motifs.Find(id);
            if (incident_Motif == null)
            {
                return HttpNotFound();
            }
            return View(incident_Motif);
        }

        // POST: Incident_Motif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident_Motif incident_Motif = db.Incident_Motifs.Find(id);
            db.Incident_Motifs.Remove(incident_Motif);
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
