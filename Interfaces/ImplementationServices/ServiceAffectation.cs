using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services.ImplementationServices
{
    public class ServiceAffectation : IServiceAffectation
    {
        private readonly Db_Context context;

        public ServiceAffectation(Db_Context context)
        {
            this.context = context;
        }

        public async Task<Affectation> Create(Affectation affectation)
        {
            context.Affectations.Add(affectation);
            await context.SaveChangesAsync();
            return affectation;
        }

        public async Task Delete(string id)
        {
            var affectation = await context.Affectations.FindAsync(id);
            context.Affectations.Remove(affectation);
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<Affectation>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Affectation> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Affectation affectation)
        {
            throw new NotImplementedException();
        }
    }
}
