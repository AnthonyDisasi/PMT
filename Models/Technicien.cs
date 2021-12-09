﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class Technicien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Postnom { get; set; }
        public string Titre { get; set; }

        [Required]
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool EstActif { get; set; }

        public string AllName
        {
            get
            {
                return Nom + " - " + Postnom + " - " + Prenom;
            }
        }
        public ICollection<Affectation> Affectations { get; set; }
    }
}
