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

        [Display(Name = "Créateur de la tâche")]
        public string CreateurTache { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }

        public int Progression { get; set; }

        public string Statut
        {
            get
            {
                if (Date_Fin > DateTime.Now)
                {
                    if (Progression == 100)
                        return "Clôturée";
                    else if (Progression == 0)
                        return "Non commncée (en retard)";
                    else
                        return "En retard";
                }
                else
                {
                    if (Progression == 100)
                        return "Clôturée";
                    else if (Progression == 0)
                        return "Non commncée";
                    else
                        return "En cours";
                }
            }
        }


        public bool EstActif { get; set; }

        [Required]
        [Display(Name = "Reponsable de tâche")]
        public string ResponsableTache { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = ("Date début"))]
        public DateTime Date_Debut { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = ("Date limite"))]
        public DateTime Date_Fin { get; set; }

        public ICollection<Note> Notes { get; set; }
        [Display(Name = "Sous - Tâche(s)")]
        public ICollection<SousTache> SousTaches { get; set; }

        //public Technicien Technicien { get; set; }
    }
}
