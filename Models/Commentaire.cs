using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMT.Models
{
    public class Commentaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string SousTacheID { get; set; }

        public string Note { get; set; }
        public DateTime Date_Post { get; set; }
        public string UserPost { get; set; }
        public bool EstActif { get; set; }

        public SousTache SousTache { get; set; }
    }
}
