using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces.ImplementationServices
{
    public class ServicePrioStatTypTitAsync : IServicePrioStatTypTitAsync
    {
        private readonly Db_Context _context;

        public ServicePrioStatTypTitAsync(Db_Context context)
        {
            _context = context;
        }

        public async Task<Titre> CreateTitreAsync(string nom)
        {
            var titre = new Titre
            {
                EstActif = true,
                Nom = nom
            };

            _context.Titres.Add(titre);
            await _context.SaveChangesAsync();
            return titre;
        }

        public async Task<ModelType> CreateTypeAsync(string nom)
        {
            var model = new ModelType
            {
                EstActif = true,
                Nom = nom
            };

            _context.Types.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DisableTitreAsync(string id)
        {
            var titre = await _context.Titres.FindAsync(id);
            titre.EstActif = false;
            _context.Entry(titre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DisableType(string id)
        {
            var model = await _context.Types.FindAsync(id);
            model.EstActif = true;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModelType>> GetListTypeAsync()
            => await _context.Types.Where(t => t.EstActif == true).ToListAsync();

        public async Task<IEnumerable<Titre>> GetTitreAsync()
            => await _context.Titres.Where(t => t.EstActif == true).ToListAsync();
    }
}
