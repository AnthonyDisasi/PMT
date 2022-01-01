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
        {
            var taches = await _context
                .Taches.Include(t => t.SousTaches.Where(st => st.EstActif == true))
                .OrderBy(t => t.Date_Debut)
                .Where(t => t.EstActif == true)
                .ToListAsync();
            return taches;
        }

        public async Task<Tache> Get(string id)
        {
            var tache = await _context.Taches.AsNoTracking().Include(t => t.SousTaches).Include(n => n.Notes).FirstOrDefaultAsync(t => t.ID == id);
            tache.SousTaches = tache.SousTaches.Where(st => st.EstActif == true).ToList();
            return tache;
        }

        public async Task<List<SelectListItem>> ListeType()
            => await (
            from t in _context.Types 
            orderby t.Nom
            where (t.EstActif == true)
            select new SelectListItem {
                Text = t.Nom,
                Value = t.Nom
            })
            .ToListAsync();

        public async Task Update(Tache tache)
        {
            _context.Entry(tache).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<SelectListItem>> ListUser()
            => await (from t in _context.Techniciens
                      orderby t.Username
                      where (t.EstActif == true)
                      select new SelectListItem {
                          Text = t.Username,
                          Value = t.ID 
                      })
            .ToListAsync();

        public async Task<List<SelectListItem>> GetUser()
            => await (from t in _context.Techniciens
                      orderby t.Username
                      where (t.EstActif == true)
                      select new SelectListItem {
                          Text = t.Username,
                          Value = t.Username
                      })
            .ToListAsync();

        public async Task AddNote(string commentaire, string idTache, string username)
        {
            if (commentaire != null || idTache != null)
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

        public async Task AddCommentaire(string note, string idSoustache, string username)
        {
            if (note != null || idSoustache != null)
            {
                var commentaire = new Commentaire
                {
                    SousTacheID = idSoustache,
                    UserPost = username,
                    Date_Post = DateTime.Now,
                    Note = note,
                    EstActif = true
                };
                _context.Commentaires.Add(commentaire);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddSousTacheAsync(SousTache model, string id)
        {
            double PoidsTotal = 0;
            double temp = 0;
            double calcul = 0.0;
            var tache = await _context.Taches.Include(s => s.SousTaches).FirstOrDefaultAsync(t => t.ID == model.TacheID);
            if (tache.SousTaches.Count > 0)
            {
                tache.SousTaches = tache.SousTaches.Where(st => st.EstActif == true).ToList();
                foreach (var item in tache.SousTaches)
                {
                    PoidsTotal += item.Poids;
                }
                if (PoidsTotal == 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in tache.SousTaches)
                    {
                        ite.Poids = (ite.Poids * temp) / 100;
                        _context.Entry(ite).State = EntityState.Modified;
                    }
                }
                else if ((PoidsTotal + model.Poids) > 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in tache.SousTaches)
                    {
                        ite.Poids = (ite.Poids / PoidsTotal) * temp;
                        _context.Entry(ite).State = EntityState.Modified;

                    }
                }
            }
            model.ID = null;
            model.EstActif = true;
            _context.Soustaches.Add(model);
            foreach (var item in tache.SousTaches)
            {
                calcul += (item.Progression / 100) * item.Poids;
            }
            tache.Progression = ((int)calcul);
            _context.Entry(tache).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<SousTache> GetSoustacheAsync(string id)
        {
            var model = await _context.Soustaches
                            .Include(t => t.Tache)
                            .Include(st => st.SousTaches)
                            .Include(co => co.Commentaires)
                            .FirstOrDefaultAsync(s => s.ID == id);
            model.SousTaches = model.SousTaches.Where(st => st.EstActif == true).ToList();
            return model;
        }

        public async Task<SousTache> UpdateSousTache(SousTache model, string idParent)
        {
            model.EstActif = true;
            model.TacheID = idParent;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
        
        public async Task UpdateSousTacheAsync(SousTache model)
        {
            double PoidsTotal = 0;
            double temp = 0; double calcul = 0.0;
            var tache = await _context.Taches.Include(s => s.SousTaches).FirstOrDefaultAsync(t => t.ID == model.TacheID);
            if (tache.SousTaches.Count > 0)
            {
                tache.SousTaches = tache.SousTaches.Where(st => st.EstActif == true).ToList();
                
                foreach (var item in tache.SousTaches)
                {
                    if(item.ID != model.ID)
                        PoidsTotal += item.Poids;
                }
                if (PoidsTotal == 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in tache.SousTaches)
                    {

                        if (ite.ID != model.ID) 
                        { 
                            ite.Poids = (ite.Poids * temp) / 100;
                            _context.Entry(ite).State = EntityState.Modified;
                        }
                    }
                }
                else if ((PoidsTotal + model.Poids) > 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in tache.SousTaches)
                    {
                        if(ite.ID != model.ID)
                        {
                            ite.Poids = (ite.Poids / PoidsTotal) * temp;
                            _context.Entry(ite).State = EntityState.Modified;
                        }
                    }
                }
            
                foreach (var item in (tache.SousTaches).ToList())
                {
                    if (item.EstActif == true)
                        calcul += (item.Progression / 100) * item.Poids;
                }
                tache.Progression = ((int)calcul);
                _context.Entry(tache).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSousTacheAsync(string id)
        {
            double calcul = 0.0;
            var model = await _context.Soustaches.FindAsync(id);

            var tache = await _context.Taches.Include(st => st.SousTaches).FirstOrDefaultAsync(s => s.ID == model.TacheID);

            foreach (var item in tache.SousTaches)
            {
                if(item.ID != model.ID)
                    calcul += (item.Progression / 100) * item.Poids;
            }

            model.EstActif = false;
            _context.Entry(model).State = EntityState.Modified;

            tache.Progression = ((int)calcul);
            _context.Entry(tache).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
