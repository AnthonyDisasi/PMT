using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services.ImplementationServices
{
    public class ServiceTache : IServiceTache
    {
        private readonly Db_Context context;

        public ServiceTache(Db_Context context)
        {
            this.context = context;
        }

        public async Task<Tache> Create(Tache tache)
        {
            context.Taches.Add(tache);
            await context.SaveChangesAsync();
            return tache;
        }

        public async Task Delete(string id)
        {
            var tache = await context.Taches.FindAsync(id);
            context.Taches.Remove(tache);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tache>> Get()
        {
            return await context.Taches.ToListAsync();
        }

        public async Task<Tache> Get(string id)
        {
            return await context.Taches.FindAsync(id);
        }

        public async Task Update(Tache tache)
        {
            context.Entry(tache).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
