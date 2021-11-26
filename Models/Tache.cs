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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string CreateurTacheID { get; set; }
        public string ParentID { get; set; }

        [Required]
        public string Description { get; set; }
        public string Type { get; set; }
        [Required]
        public string StatutID { get; set; }
        [Required]
        public string PrioriteID { get; set; }

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
        public Statut Statut { get; set; }
        public Priorite Priorite { get; set; }
    }
}
