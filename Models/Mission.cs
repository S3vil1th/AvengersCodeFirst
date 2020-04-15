using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test13.Models
{

    public enum Statut_Mission { En_Attente = 0, Mission_activée = 1, Mission_refusée = 2 }
    public class Mission
    {
        [Key]
        public int MissionID { get; set; }

        public int IncidentID { get; set; }

        public Statut_Mission Statut_Mission { get; set; } 

        public int HerosID { get; set; }

        public int? MechantID { get; set; }

        public string Commentaire { get; set; }

        public DateTime Date_Mission { get; set; }


        public Incident Incident { get; set; }

        public Heros Heros { get; set; }

        public Mechant Mechant { get; set; }

        public Satisfaction Satisfaction { get; set; }








    }
}