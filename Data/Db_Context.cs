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

        public DbSet<Tache> Taches {get; set;}
        public DbSet<SousTache> Soustaches { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Technicien> Techniciens { get; set; }
        public DbSet<ModelType> Types { get; set; }
        public DbSet<Titre> Titres { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
