using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services.ImplementationServices
{
    public class ServiceTache : IServiceTache
    {
        private readonly Db_Context _context;

        public ServiceTache(Db_Context context)
        {
            _context = context;
        }

        public async Task<Tache> AddSousTacheAsync(Tache tache, string id)
        {
            var tacheParent = await Get(id);

            //tacheParent.Taches.Add(tache);
            await Update(tacheParent);
            return tacheParent;
        }

        public async Task<Tache> Create(Tache tache, string Username)
        {
            tache.CreateurTache = Username;
            var not = new Notification
            {
                Expediteur = Username,
                Destinataire = tache.ResponsableTache,
                Message = "Vous êtes responsable de la tâche " + tache.Nom,
                DateMessage = DateTime.Now,
                Lu = false
            };
            _context.Notifications.Add(not);

            tache.EstActif = true;
            _context.Taches.Add(tache);
            await _context.SaveChangesAsync();
            return tache;
        }

        public async Task Delete(string id)
        {
            var tache = await _context.Taches.FindAsync(id);
            tache.EstActif = false;
            await Update(tache);
        }
        public async Task<IEnumerable<Tache>> Get()
            => await _context.Taches.Include(t => t.SousTaches).OrderBy(t => t.Date_Debut).Where(t => t.EstActif == true).ToListAsync();

        public async Task<Tache> Get(string id)
            => await _context.Taches.AsNoTracking().Include(t => t.SousTaches).Include(n => n.Notes).Where(t => t.EstActif == true).FirstOrDefaultAsync(t => t.ID == id);

        public async Task<List<SelectListItem>> ListeType()
            => await (from t in _context.Types orderby t.Nom where (t.EstActif == true) select new SelectListItem { Text = t.Nom, Value = t.Nom }).ToListAsync();

        public async Task Update(Tache tache)
        {
            _context.Entry(tache).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<SelectListItem>> ListUser()
            => await (from t in _context.Techniciens orderby t.Username where (t.EstActif == true) select new SelectListItem { Text = t.AllName, Value = t.ID }).ToListAsync();


        public async Task<List<SelectListItem>> GetUser()
            => await (from t in _context.Techniciens orderby t.Username where (t.EstActif == true) select new SelectListItem { Text = t.AllName, Value = t.Username }).ToListAsync();

        public async Task AddNote(string commentaire, string idTache, string username)
        {
            if(commentaire != null || idTache != null)
            {
                var note = new Note
                {
                    TacheID = idTache,
                    UserPost = username,
                    Date_Post = DateTime.Now,
                    Commentaire = commentaire,
                    EstActif = true
                };
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();
                var tache = await _context.Taches.FindAsync(idTache);
                tache.Notes.Add(note);
                await Update(tache);
            }
        }

        public async Task AddSousTacheAsync(SousTache soustache, string id)
        {
            var tache = await _context.Taches.FindAsync(id);
            tache.SousTaches.Add(soustache);
            ///
            double calcul = 0.0;
            double nb = 0;
            foreach (var sousTache in tache.SousTaches)
            {
                if (sousTache.Priorite == "0")
                {
                    calcul += sousTache.Progression;
                }
                else
                {
                    calcul += (sousTache.Progression * (double.Parse(sousTache.Priorite) / 25));
                    nb += double.Parse(sousTache.Priorite) / 25;
                }
            }
            tache.Progression = (calcul / nb);
            ///
            await Update(tache);
        }

        public async Task<SousTache> CreateSousTacheAsync(SousTache sousTache, string username)
        {
            sousTache.CreateurTache = username;
            var not = new Notification
            {
                Expediteur = username,
                Destinataire = sousTache.ResponsableTache,
                Message = "Vous êtes responsable de la tâche " + sousTache.Nom,
                DateMessage = DateTime.Now,
                Lu = false
            };
            sousTache.ID = null;
            _context.Notifications.Add(not);

            sousTache.EstActif = true;
            _context.Soustaches.Add(sousTache);
            return sousTache;
        }

        public async Task<SousTache> GetSoustacheAsync(string id)
            => await _context.Soustaches.Where(s => s.EstActif == true).Include(t => t.Tache).FirstOrDefaultAsync(s => s.ID == id);

        public async Task UpdateSousTache(SousTache sousTache)
        {
            _context.Entry(sousTache).State = EntityState.Modified;
            await UpdateTable();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTable()
        {
            var taches = await _context.Taches.Include(t => t.SousTaches).Where(t => t.EstActif == true).ToListAsync();
            foreach (var tache in taches)
            {
                double calcul = 0.0;
                double nb = 0;
                if (tache.SousTaches.Count > 0)
                {
                    foreach (var sousTache in tache.SousTaches)
                    {
                        if (sousTache.Priorite == "0")
                        {
                            calcul += sousTache.Progression;
                        }
                        else
                        {
                            calcul += (sousTache.Progression * (double.Parse(sousTache.Priorite) / 25));
                            nb += double.Parse(sousTache.Priorite)/ 25;
                        }
                    }
                    tache.Progression = (calcul / nb);
                    _context.Entry(tache).State = EntityState.Modified;
                }
                //yield return tache;
            }
        }

        public async Task DeleteSousTacheAsync(string id)
        {
            var soustache = await _context.Soustaches.FindAsync(id);
            _context.Soustaches.Remove(soustache);
            await _context.SaveChangesAsync();
        }
    }
}
