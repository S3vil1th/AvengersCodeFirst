using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test13.Models
{
    public class Utilisateur
    {


        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UtilisateurID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string Numéro_Telephone { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public int PaysID { get; set; }

       



        public  Pays Pays { get; set; }

        public ICollection<Incident> Incidents { get; set; }

        public Civil Civil { get; set; }

        public Organisation Organisation { get; set; }





    }
}