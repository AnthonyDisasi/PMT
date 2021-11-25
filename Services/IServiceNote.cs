using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services
{
    public interface IServiceNote
    {
        public Task<IEnumerable<Note>> Get();
        public Task<Note> Get(string id);
        public Task<Note> Create(Note note);
        public Task Update(Note note);
        public Task Delete(string id);
    }
}
