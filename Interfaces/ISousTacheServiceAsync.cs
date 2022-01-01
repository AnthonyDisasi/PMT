using Microsoft.AspNetCore.Mvc.Rendering;
using PMT.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMT.Interfaces
{
    public interface ISousTacheServiceAsync
    {
        public Task<SousTache> AddSousTacheAsync(SousTache model);
        public Task<string> DeleteSousTacheAsync(string id);
        public Task<SousTache> UpdateSousTacheAsync(SousTache model, string idParent);
        public Task UpdateSousTacheParentAsync(SousTache model);
        public Task<SousTache> GetSousTacheAsync(string id);

        public Task<List<SelectListItem>> ListeTypeAsync();
        public Task<List<SelectListItem>> GetUserAsync();

        public Task AddCommentaire(string note, string idSoustache, string username);
    }
}
