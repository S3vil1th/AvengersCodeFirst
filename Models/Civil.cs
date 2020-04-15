using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test13.Models
{

    public enum Civilite { M, Mme }
    public class Civil 


    {
        [ForeignKey("Utilisateur")]

        public int CivilID { get; set; }

       
   

        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public Civilite Civilite { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime Date_de_naissance { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de décès")]
        public DateTime? Date_de_deces { get; set; }

        /*public string NomComplet
        {
            get
            {
                return String.Format("{0} {1}, {2}",Civilite, Prenom, Nom);
            }
        }*/

        public string NomComplet
        {
            get
            {
                return Prenom + ", " + Nom + ",né(e) le " + Date_de_naissance ;
            }
        }


        


        public Heros Heros { get; set; }

        public Mechant Mechant { get; set; }

        public Utilisateur Utilisateur { get; set; }




    }
}