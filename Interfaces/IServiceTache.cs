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

        public Task<List<SelectListItem>> ListUser();
        public Task<List<SelectListItem>> ListeType();
        public Task<List<SelectListItem>> GetUser();

        public Task<Tache> Create(Tache tache, string Username);
        public Task Update(Tache tache);
        public Task Delete(string id);

        //Return tache parent
        public Task AddSousTacheAsync(SousTache soustache, string id);
        public Task AddNote(string commentaire, string idTache, string username);

        //////////////
        public Task<SousTache> GetSoustacheAsync(string id);
        public Task<SousTache> UpdateSousTache(SousTache sousTache, string idParent);
        public Task UpdateSousTacheAsync(SousTache soustache);
        public Task DeleteSousTacheAsync(string id);
    }
}
