using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services
{
    public interface IServiceTechnicien
    {
        public Task<IEnumerable<Technicien>> Get();
        public Task<IEnumerable<Tache>> GetTaches(string idUser);
        public Task<string> GetIdUser(string username);
        public Task<Technicien> GetUserByUsername(string username);
        public Task<List<SelectListItem>> ListUser();
        public Task<List<SelectListItem>> ListTitre();
        public Task<Technicien> Get(string id);
        public Task<Technicien> Create(Technicien technicien);
        public Task<string> Update(Technicien technicien, string id);
        public Task<string> Delete(string id);
    }
}
