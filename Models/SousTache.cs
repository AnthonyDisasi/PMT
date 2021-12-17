using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMT.Models
{
    public class SousTache
    {
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
        public string Priorite { get; set; }

        public double Progression { get; set; }

        public string Statut
        {
            get
            {
                if(Date_Fin > DateTime.Now)
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

        public string ResponsableTache { get; set; }

        [Required]
        [Display(Name = ("Date début")), DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }

        [Required]
        [Display(Name = ("Date limite")), DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }

        public Tache Tache { get; set; }
    }
}
