using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces
{
    public interface IServicePrioStatTypTitAsync
    {
        public Task<IEnumerable<ModelType>> GetListTypeAsync();
        public Task<IEnumerable<Titre>> GetTitreAsync();

        public Task<ModelType> CreateTypeAsync(string nom);
        public Task<Titre> CreateTitreAsync(string nom);

        public Task DisableType(string id);
        public Task DisableTitreAsync(string id);
    }
}
