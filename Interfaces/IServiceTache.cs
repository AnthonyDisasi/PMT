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
        public Task<Tache> Get(string id);

        public Task<List<SelectListItem>> ListStatut();
        public Task<List<SelectListItem>> ListePriorite();

        public Task<Tache> Create(Tache tache, string Username);
        public Task Update(Tache tache);
        public Task Delete(string id);
    }
}
