using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string TacheID { get; set; }

        public string Commentaire { get; set; }
        public DateTime Date_Post { get; set; }
        public string UserPost { get; set; }
        public bool EstActif { get; set; }

        public Tache Tache { get; set; }
    }
}
