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
        public Task<Tache> Create(Tache tache);
        public Task Update(Tache tache);
        public Task Delete(string id);
    }
}
