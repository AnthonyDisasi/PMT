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
        public string TechnicienID { get; set; }

        public string Type { get; set; }
        public string Statut { get; set; }
        public string Priorite { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }

        public ICollection<Affectation> Affectations { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Tache> Taches { get; set; }
        public Technicien Technicien { get; set; }
    }
}
