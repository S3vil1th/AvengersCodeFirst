using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test13.Models
{
    public class Pays
    {
        public int PaysID { get; set; }

        [Display(Name = "Pays")]
        [Required]
        public string Pays_nom { get; set; }

       
        public ICollection<Civil> Civils { get; set; }

        public ICollection<Organisation> Organisations  { get; set; }

        public ICollection<Incident> Incidents { get; set; }



    }
}