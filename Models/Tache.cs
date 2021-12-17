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
        public string CreateurTache { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }

        public double Progression { get; set; }

        public bool EstActif { get; set; }

        [Required]
        public string ResponsableTache { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = ("Date début"))]
        public DateTime Date_Debut { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = ("Date limite"))]
        public DateTime Date_Fin { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<SousTache> SousTaches { get; set; }

        //public Technicien Technicien { get; set; }
    }
}
