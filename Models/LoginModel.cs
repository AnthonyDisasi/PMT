using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class LoginModel
    {
        [Required, Display(Name = "Username")]
        [UIHint("name")]
        public string Username { get; set; }
        [Required, Display(Name = "Mot de Passe")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
