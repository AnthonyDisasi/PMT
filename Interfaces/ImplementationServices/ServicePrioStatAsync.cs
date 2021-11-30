using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces.ImplementationServices
{
    public class ServicePrioStatAsync : IServicePrioStatAsync
    {
        private readonly Db_Context _context;

        public ServicePrioStatAsync(Db_Context context)
        {
            _context = context;
        }

        public async Task<Priorite> CreatePrioriteAsync(Priorite priorite)
        {
            priorite.EstActif = true;
            _context.Priorites.Add(priorite);
            await _context.SaveChangesAsync();
            return priorite;
        }

        public async Task<Statut> CreateStatutAsync(Statut statut)
        {
            statut.EstActif = true;
            _context.Statuts.Add(statut);
            await _context.SaveChangesAsync();
            return statut;
        }

        public async Task DisablePriorite(string id)
        {
            var model = await _context.Priorites.FindAsync(id);
            model.EstActif = false;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DisasbleStatut(string id)
        {
            var model = await _context.Statuts.FindAsync(id);
            model.EstActif = false;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Priorite>> GetListPrioriteAsync()
            => await _context.Priorites.Where(p => p.EstActif == true).ToListAsync();

        public async Task<IEnumerable<Statut>> GetListStatutAsync()
            => await _context.Statuts.Where(p => p.EstActif == true).ToListAsync();
    }
}
