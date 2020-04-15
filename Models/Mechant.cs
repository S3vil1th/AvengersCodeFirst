using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test13.Models
{
    public class Mechant
    {
        [ForeignKey("Civil")]
        public int MechantID { get; set; }

      
       
       



        [Display(Name = "Pseudonyme Méchant")]
        public string Pseudonyme { get; set; }

        [Display(Name = "Photo")]
        public string Image_Mechant { get; set; }
        public Boolean Disponible { get; set; }

       
        public  Civil Civil { get; set; }

        public ICollection<Mission> Missions { get; set; }
    }
}