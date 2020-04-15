using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test13.Models
{
    public class Organisation 
    {

        [ForeignKey("Utilisateur")]

        public int OrganisationID { get; set; }

      

        [Required]
        public string Denomination { get; set; }


        

        [Required]
        [DataType(DataType.Date)]
      
        [Display(Name = "Date de création")]
        public DateTime Date_de_creation { get; set; }

       

        [DataType(DataType.Date)]
        
        [Display(Name = "Date de dissolution")]
        public DateTime? Date_de_dissolution { get; set; }




        public Utilisateur Utilisateur { get; set; }




    }
}