﻿using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services.ImplementationServices
{
    public class ServiceTechnicien : IServiceTechnicien
    {
        private readonly Db_Context context;

        public ServiceTechnicien(Db_Context context)
        {
            this.context = context;
        }

        public async Task<Technicien> Create(Technicien technicien)
        {
            context.Techniciens.Add(technicien);
            await context.SaveChangesAsync();
            return technicien;
        }

        public async Task Delete(string id)
        {
            var technicien = await context.Techniciens.FindAsync(id);
            context.Techniciens.Remove(technicien);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Technicien>> Get()
        {
            return await context.Techniciens.ToListAsync();
        }

        public async Task<Technicien> Get(string id)
        {
            return await context.Techniciens.FindAsync(id);
        }

        public string GetIdUser(string username)
        {
            //var model = context.Techniciens.FirstOrDefaultAsync(t => t.Username == User.Identity.Name);
            return context.Techniciens.FirstOrDefault(t => t.Username == username).ID;
        }

        public async Task<IEnumerable<Tache>> GetTaches(string idUser)
        {
            return await context.Taches.AsNoTracking().Where(t => t.TechnicienID == idUser).ToListAsync();
        }

        public async Task Update(Technicien technicien)
        {
            context.Entry(technicien).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}

