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
        public string Mail { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public string AllName { get
            {
                return Nom + " - " + Postnom + " - " + Prenom;
            }
        }

        public ICollection<Affectation> Affectations { get; set; }
    }
}
