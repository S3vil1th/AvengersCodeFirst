using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test13.Models
{
    public class Incident_Motif
    {
        [Required]
        [Display(Name = "Motif")]
        public int Incident_MotifID { get; set; }
        [Required]
        public string Motif { get; set; }

        [Display(Name = "Symbole")]
        public string Motif_Symbole { get; set; }

        public ICollection<Incident> Incidents { get; set; }

    }
}