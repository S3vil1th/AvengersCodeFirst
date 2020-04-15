using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Test13.Models;

namespace Test13.DAL
{
    public class AvengersContext : DbContext
    {

        public AvengersContext() : base("AvengersContext")
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Civil> Civils { get; set; }

        public DbSet<Organisation> Organisations { get; set; }


        public DbSet<Pays> Pays { get; set; }

        public DbSet<Heros> Heros { get; set; }

        public DbSet<Mechant> Mechants { get; set; }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Incident_Motif> Incident_Motifs { get; set; }

        public DbSet<Mission> Missions { get; set; }

        public DbSet<Satisfaction> Satisfactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Incident>()
               .HasRequired<Utilisateur>(incident => incident.Utilisateur)
               .WithMany(utilisateur => utilisateur.Incidents)
               .HasForeignKey<int>(utilisateur => utilisateur.UtilisateurID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mission>()
                .HasRequired(m => m.Satisfaction)
                .WithRequiredPrincipal(s => s.Mission);


            /* modelBuilder.Entity<Civil>()
                        .HasOptional(civil => civil.Heros)
                        .WithRequired(heros => heros.Civil);

             modelBuilder.Entity<Civil>()
                        .HasOptional(civil => civil.Mechant)
                        .WithOptionalPrincipal(mechant => mechant.Civil);*/


            /* David : Mapping tables Foreign Keys
            
            // Test: Civils/heros
            modelBuilder.Entity<Civil>()
                        .HasOptional(civil => civil.Heros) 
                        .WithRequired(heros => heros.Civil);

            modelBuilder.Entity<Civil>()
                .HasRequired<Pays>(civil => civil.Pays)
                .WithMany(pays => pays.Civils)
                .HasForeignKey<int>(civil => civil.PaysID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
              .HasRequired<Pays>(organisation => organisation.Pays)
              .WithMany(pays => pays.Organisations)
              .HasForeignKey<int>(organisation => organisation.PaysID)
              .WillCascadeOnDelete(false);

             modelBuilder.Entity<Civil>()
                 .HasMany<Incident>(civil => civil.Incident)
                 .WithRequired(incident => incident.Civils)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Incident>()
                .HasRequired<Civil>(incident => incident.Civil)
                .WithMany(civil => civil.Incidents)
                .HasForeignKey<int>(incident => incident.UtilisateurID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Incident>()
               .HasRequired<Organisation>(incident => incident.Organisation)
               .WithMany(organisation => organisation.Incidents)
               .HasForeignKey<int>(incident => incident.UtilisateurID)
               .WillCascadeOnDelete(false);*/








        }

        
    }
}