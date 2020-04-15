using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test13.Models;

namespace Test13.DAL

{
    public class AvengersInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AvengersContext>
    {
        protected override void Seed(AvengersContext context)
        {

            // David: déclaration des variables


            var utilisateurs = new List<Utilisateur> { };
            utilisateurs.ForEach(s => context.Utilisateurs.Add(s));
            context.SaveChanges();

            var civils = new List<Civil> { };
            civils.ForEach(s => context.Civils.Add(s));
            context.SaveChanges();

            var organisations = new List<Organisation> { };
            organisations.ForEach(s => context.Organisations.Add(s));
            context.SaveChanges();

            var pays = new List<Pays> { };
            pays.ForEach(s => context.Pays.Add(s));
            context.SaveChanges();

            var heros = new List<Heros> { };
            heros.ForEach(s => context.Heros.Add(s));
            context.SaveChanges();

            var mechants = new List<Mechant> { };
            mechants.ForEach(s => context.Mechants.Add(s));
            context.SaveChanges();

            var incidents = new List<Incident> { };
            incidents.ForEach(s => context.Incidents.Add(s));
            context.SaveChanges();

            var incident_motif = new List<Incident_Motif> { };
            incident_motif.ForEach(s => context.Incident_Motifs.Add(s));
            context.SaveChanges();

            var missions = new List<Mission> { };
            missions.ForEach(s => context.Missions.Add(s));
            context.SaveChanges();

            var satisfactions = new List<Satisfaction> { };
            satisfactions.ForEach(s => context.Satisfactions.Add(s));
            context.SaveChanges();







        }
    }
}