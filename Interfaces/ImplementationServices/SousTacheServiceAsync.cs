using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Interfaces.ImplementationServices
{
    public class SousTacheServiceAsync : ISousTacheServiceAsync
    {
        private readonly Db_Context _context;

        public SousTacheServiceAsync(Db_Context context)
        {
            _context = context;
        }

        public async Task<SousTache> AddSousTacheAsync(SousTache model)
        {
            double PoidsTotal = 0;
            double temp = 0;
            double calcul = 0.0;
            var soustache = await _context.Soustaches.Include(s => s.SousTaches).FirstOrDefaultAsync(t => t.ID == model.SousTacheID);
            if (soustache.SousTaches.Count > 0)
            {
                soustache.SousTaches = soustache.SousTaches.Where(st => st.EstActif == true).ToList();
                foreach (var item in soustache.SousTaches)
                {
                    PoidsTotal += item.Poids;
                }
                if (PoidsTotal == 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in soustache.SousTaches)
                    {
                        ite.Poids = (ite.Poids * temp) / 100;
                        _context.Entry(ite).State = EntityState.Modified;
                    }
                }
                else if ((PoidsTotal + model.Poids) > 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in soustache.SousTaches)
                    {
                        ite.Poids = (ite.Poids / PoidsTotal) * temp;
                        _context.Entry(ite).State = EntityState.Modified;

                    }
                }
            }
            model.ID = null;
            model.EstActif = true;
            _context.Soustaches.Add(model);
            foreach (var item in soustache.SousTaches)
            {
                calcul += (item.Progression / 100) * item.Poids;
            }
            soustache.Progression = ((int)calcul);
            _context.Entry(soustache).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<string> DeleteSousTacheAsync(string id)
        {
            double calcul = 0.0;
            var model = await _context.Soustaches.FindAsync(id);

            string id_ = model.SousTacheID;

            var soustache = await _context.Soustaches.Include(st => st.SousTaches).FirstOrDefaultAsync(s => s.ID == model.SousTacheID);
            if(soustache != null)
            foreach (var item in soustache.SousTaches)
            {
                if (item.ID != model.ID)
                    calcul += (item.Progression / 100) * item.Poids;
            }

            model.EstActif = false;
            _context.Entry(model).State = EntityState.Modified;

            soustache.Progression = calcul;
            _context.Entry(soustache).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return id_;
        }

        public async Task<SousTache> GetSousTacheAsync(string id)
        {
            var model = await _context.Soustaches.Include(s => s.SousTaches).Include(co => co.Commentaires).FirstOrDefaultAsync(s => s.ID == id);
            model.SousTaches = model.SousTaches.Where(s => s.EstActif == true).ToList();
            return model;
        }

        public async Task<List<SelectListItem>> GetUserAsync()
            => await(from t in _context.Techniciens
                     orderby t.Username
                     where (t.EstActif == true)
                     select new SelectListItem
                     {
                         Text = t.Username,
                         Value = t.Username
                     })
                .ToListAsync();

        public async Task<List<SelectListItem>> ListeTypeAsync()
            => await(
                from t in _context.Types
                orderby t.Nom
                where (t.EstActif == true)
                select new SelectListItem
                {
                    Text = t.Nom,
                    Value = t.Nom
                })
            .ToListAsync();

        public async Task<SousTache> UpdateSousTacheAsync(SousTache model, string idParent)
        {
            model.EstActif = true;
            model.SousTacheID = idParent;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
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

        public async Task UpdateSousTacheParentAsync(SousTache model)
        {
            double PoidsTotal = 0;
            double temp = 0; double calcul = 0.0;
            var soustache = await _context.Soustaches.Include(s => s.SousTaches).FirstOrDefaultAsync(t => t.ID == model.SousTacheID);
            if (soustache.SousTaches.Count() > 0)
            {
                soustache.SousTaches = soustache.SousTaches.Where(st => st.EstActif == true).ToList();

                foreach (var item in soustache.SousTaches)
                {
                    if (item.ID != model.ID)
                        PoidsTotal += item.Poids;
                }
                if (PoidsTotal == 100)
                {
                    temp = 100 - model.Poids;
                    foreach (var ite in soustache.SousTaches)
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
                    foreach (var ite in soustache.SousTaches)
                    {
                        if (ite.ID != model.ID)
                        {
                            ite.Poids = (ite.Poids / PoidsTotal) * temp;
                            _context.Entry(ite).State = EntityState.Modified;
                        }
                    }
                }

                foreach (var item in (soustache.SousTaches).ToList())
                {
                    if (item.EstActif == true)
                        calcul += (item.Progression / 100) * item.Poids;
                }
                soustache.Progression = ((int)calcul);
                _context.Entry(soustache).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
