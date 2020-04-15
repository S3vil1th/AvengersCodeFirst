using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test13.Models
{

    
    public class Incident
    {

        [Key]
        public int IncidentID { get; set; }

        public int UtilisateurID { get; set; }


        [Display(Name = "Motif")]
        public int Incident_MotifID { get; set; }

        [Required]
        public int PaysID { get; set; }

        public string Contexte { get; set; }

        public string Adresse { get; set; }


       
        public DateTime Date_Incident { get; set; } 


        public Incident_Motif Incident_Motif { get; set; }

        public Pays Pays { get; set; }

      
        public Utilisateur Utilisateur { get; set; }

       
       
    }
}