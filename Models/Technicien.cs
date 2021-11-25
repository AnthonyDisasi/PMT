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
        public string Post { get; set; }

        public string AllName { get
            {
                return Nom + Postnom + Prenom;
            }
        }

        public ICollection<Affectation> Affectations { get; set; }
    }
}
