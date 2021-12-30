using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class technicienModel
    {
        public string ID { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Postnom { get; set; }
        [Required]
        public string Titre { get; set; }

        [Required]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "E - mail")]
        public string Mail { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Compare("Password"), Required]
        [Display(Name = "Confirmer Mot de passe")]
        public string ConfirmPassword { get; set; }
        public bool EstActif { get; set; }
    }
}
