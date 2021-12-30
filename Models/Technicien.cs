using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class Technicien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Postnom { get; set; }
        public string Titre { get; set; }

        [Required]
        public string Username { get; set; }
        [Display(Name = "E - mail")]
        public string Mail { get; set; }
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        public bool EstActif { get; set; }
    }
}
