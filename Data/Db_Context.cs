using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Data
{
    public class Db_Context : IdentityDbContext<User_App>
    {
        public Db_Context(DbContextOptions<Db_Context> options) : base(options) { }

        DbSet<Tache> Taches {get; set;}
        DbSet<Priorite> Priorites { get; set; }
        DbSet<Note> Notes { get; set; }
        DbSet<Technicien> Techniciens { get; set; }
        DbSet<Statut> Statuts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
