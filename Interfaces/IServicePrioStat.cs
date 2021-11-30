using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces
{
    public interface IServicePrioStatAsync
    {
        public Task<IEnumerable<Priorite>> GetListPrioriteAsync();
        public Task<IEnumerable<Statut>> GetListStatutAsync();

        public Task<Statut> CreateStatutAsync(Statut statut);
        public Task<Priorite> CreatePrioriteAsync(Priorite priorite);

        public Task DisablePriorite(string id);
        public Task DisasbleStatut(string id);
    }
}
