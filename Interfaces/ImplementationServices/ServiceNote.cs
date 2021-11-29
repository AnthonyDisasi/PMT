using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services.ImplementationServices
{
    public class ServiceNote : IServiceNote
    {
        private readonly Db_Context context;

        public ServiceNote(Db_Context context)
        {
            this.context = context;
        }

        public async Task<Note> Create(Note note)
        {
            context.Notes.Add(note);
            await context.SaveChangesAsync();
            return note;
        }

        public async Task Delete(string id)
        {
            var note = await context.Notes.FindAsync(id);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> Get()
        {
            return await context.Notes.ToListAsync();
        }

        public async Task<Note> Get(string id)
        {
            return await context.Notes.FindAsync(id);
        }

        public async Task Update(Note note)
        {
            context.Entry(note).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}