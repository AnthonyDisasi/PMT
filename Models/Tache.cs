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
        public int Etat { get; set; }

        [Required]
        public string Statut { get; set; }
        [Required]
        public string Priorite { get; set; }

        public bool EstActif { get; set; }

        [Required]
        [Display(Name = ("Date début"))]
        public DateTime Date_Debut { get; set; }

        [Required]
        [Display(Name = ("Date limite"))]
        public DateTime Date_Fin { get; set; }

        public string Deadline 
        {
            get
            {
                if(Date_Fin.Day < DateTime.Now.Day && Date_Fin.Year < DateTime.Now.Year && Date_Fin.Month < DateTime.Now.Month)
                {
                    return " déjà depassée";
                }
                else if(Date_Fin.Day == DateTime.Now.Day && Date_Fin.Year == DateTime.Now.Year && Date_Fin.Month == DateTime.Now.Month)
                {
                    return "pour ajourd'hui";
                }
                else
                {
                    return Date_Fin.Day.ToString() + "/" + Date_Fin.Month.ToString() + "/" + Date_Fin.Year.ToString();
                }
            } 
        }

        public string ColorEtat
        {
            get
            {
                return Etat + "%";
            }
        }

        public ICollection<Affectation> Affectations { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Tache> Taches { get; set; }

        //public Technicien Technicien { get; set; }
    }
}
