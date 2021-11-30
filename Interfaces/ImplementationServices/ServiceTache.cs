using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly Db_Context _context;

        public ServiceTache(Db_Context context)
        {
            _context = context;
        }

        public async Task<Tache> AddSousTacheAsync(Tache tache, string id)
        {
            var tacheParent = await Get(id);
            tacheParent.Taches.Add(tache);
            await Update(tacheParent);
            return tacheParent;
        }

        public async Task<Tache> Create(Tache tache, string Username)
        {
            tache.CreateurTache = Username;
            tache.EstActif = true;
            _context.Taches.Add(tache);
            await _context.SaveChangesAsync();
            return tache;
        }

        public async Task Delete(string id)
        {
            var tache = await _context.Taches.FindAsync(id);
            tache.EstActif = false;
            await Update(tache);
        }
        public async Task<IEnumerable<Tache>> Get()
            => await _context.Taches.Include(a => a.Affectations).Include(t => t.Taches).Where(t => t.EstActif == true).ToListAsync();

        public async Task<IEnumerable<Tache>> GetWhereDateFinMax()
            => await _context.Taches.Include(t => t.Taches).Include(a => a.Affectations).Where(t => t.TacheID == null).Where(t => t.EstActif == true).ToListAsync();

        public async Task<Tache> Get(string id)
            => await _context.Taches.AsNoTracking().Include(t => t.Taches).Include(a => a.Affectations).Where(t => t.EstActif == true).FirstOrDefaultAsync(t => t.ID == id);

        public async Task<List<SelectListItem>> ListePriorite()
            => await (from p in _context.Priorites select new SelectListItem { Text = p.Nom, Value = p.ID }).ToListAsync();

        public async Task<List<SelectListItem>> ListStatut()
            => await(from s in _context.Statuts select new SelectListItem { Text = s.Nom, Value = s.ID }).ToListAsync();

        public async Task Update(Tache tache)
        {
            _context.Entry(tache).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
