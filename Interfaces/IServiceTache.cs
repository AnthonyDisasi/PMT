using Microsoft.AspNetCore.Mvc.Rendering;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services
{
    public interface IServiceTache
    {
        public Task<IEnumerable<Tache>> Get();
        public Task<IEnumerable<Tache>> GetWhereDateFinMax();
        public Task<Tache> Get(string id);

        public Task<List<SelectListItem>> ListStatut();
        public Task<List<SelectListItem>> ListePriorite();
        public Task<List<SelectListItem>> ListeType();

        public Task<Tache> Create(Tache tache, string Username);
        public Task Update(Tache tache);
        public Task Delete(string id);

        //Return tache parent
        public Task<Tache> AddSousTacheAsync(Tache tache, string id);
    }
}
