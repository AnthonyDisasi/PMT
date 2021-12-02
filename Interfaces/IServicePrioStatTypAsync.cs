using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces
{
    public interface IServicePrioStatTypAsync
    {
        public Task<IEnumerable<Priorite>> GetListPrioriteAsync();
        public Task<IEnumerable<Statut>> GetListStatutAsync();
        public Task<IEnumerable<ModelType>> GetListTypeAsync();

        public Task<Statut> CreateStatutAsync(string nom);
        public Task<Priorite> CreatePrioriteAsync(string nom);
        public Task<ModelType> CreateTypeAsync(string nom);

        public Task DisablePriorite(string id);
        public Task DisasbleStatut(string id);
        public Task DisableType(string id);
    }
}
