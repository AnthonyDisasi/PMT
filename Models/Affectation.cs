using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class Affectation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string TacheID { get; set; }
        public string TechnicienID { get; set; }

        public bool EstActif { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_Affectation { set
            {
                Date_Affectation = DateTime.Now;
            }
            get
            {
                return Date_Affectation;
            }
        }

        public Tache Tache { get; set; }
        public Technicien Technicien { get; set; }
    }
}
