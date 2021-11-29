using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services
{
    public interface IServiceAffectation
    {
        public Task<IEnumerable<Affectation>> Get();
        public Task<Affectation> Get(string id);
        public Task<Affectation> Create(Affectation affectation);
        public Task Update(Affectation affectation);
        public Task Delete(string id);
    }
}
