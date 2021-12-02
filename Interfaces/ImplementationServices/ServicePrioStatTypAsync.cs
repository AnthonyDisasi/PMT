﻿using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces.ImplementationServices
{
    public class ServicePrioStatTypAsync : IServicePrioStatTypAsync
    {
        private readonly Db_Context _context;

        public ServicePrioStatTypAsync(Db_Context context)
        {
            _context = context;
        }

        public async Task<Priorite> CreatePrioriteAsync(string nom)
        {
            var model = new Priorite
            {
                EstActif = true,
                Nom = nom
            };

            _context.Priorites.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Statut> CreateStatutAsync(string nom)
        {
            var model = new Statut
            {
                EstActif = true,
                Nom = nom
            };

            _context.Statuts.Add(model);
            await _context.SaveChangesAsync();
            return model;
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

        public async Task DisablePriorite(string id)
        {
            var model = await _context.Priorites.FindAsync(id);
            model.EstActif = false;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DisableType(string id)
        {
            var model = await _context.Types.FindAsync(id);
            model.EstActif = true;
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

        public async Task<IEnumerable<ModelType>> GetListTypeAsync()
            => await _context.Types.Where(t => t.EstActif == true).ToListAsync();
    }
}
