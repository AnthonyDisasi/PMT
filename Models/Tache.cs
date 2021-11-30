using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class Tache
    {
        public Tache()
        {
            Taches = new HashSet<Tache>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string TacheID { get; set; }
        public string CreateurTache { get; set; }

        public string Nom { get; set; }
        [Required]
        public string Description { get; set; }
        public string Type { get; set; }

        [Required]
        public string Statut { get; set; }
        [Required]
        public string Priorite { get; set; }

        public bool EstActif { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date_Fin { get; set; }

        public ICollection<Affectation> Affectations { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Tache> Taches { get; set; }

        //public Technicien Technicien { get; set; }
    }
}
