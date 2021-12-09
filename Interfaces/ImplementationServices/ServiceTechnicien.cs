using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PMT.Data;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Services.ImplementationServices
{
    public class ServiceTechnicien : IServiceTechnicien
    {
        private readonly Db_Context context;
        private UserManager<User_App> userManager;
        private IUserValidator<User_App> userValidator;
        private IPasswordValidator<User_App> passwordValidator;
        private IPasswordHasher<User_App> passwordHasher;

        public List<Erreur> erreurs = null;

        public ServiceTechnicien(UserManager<User_App> userManager,
            IUserValidator<User_App> userValidator,
            IPasswordValidator<User_App> passwordValidator,
            IPasswordHasher<User_App> passwordHasher,
            Db_Context context)
        {
            this.userManager = userManager;
            this.userValidator = userValidator;
            this.passwordValidator = passwordValidator;
            this.passwordHasher = passwordHasher;
            this.context = context;
        }

        public async Task<Technicien> Create(Technicien technicien)
        {
            User_App user = new User_App
            {
                UserName = technicien.Username,
                Email = technicien.Mail
            };

            IdentityResult result = await userManager.CreateAsync(user, technicien.Password);

            if (result.Succeeded)
            {
                user = await userManager.FindByNameAsync(technicien.Username);
                technicien.ID = user.Id;
                context.Techniciens.Add(technicien);
                await context.SaveChangesAsync();
                return technicien;
            }
            return technicien;
        }

        public async Task<string> Delete(string id)
        {
            User_App user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                var technicien = await context.Techniciens.FindAsync(id);
                context.Techniciens.Remove(technicien);
                await context.SaveChangesAsync();
                return "Suppression réussite";
            }
            else
            {
                return "Echec de suppression, l'utilisateur n'existe pas";
            }
        }

        public async Task<IEnumerable<Technicien>> Get()
        {
            return await context.Techniciens.Include(a => a.Affectations).ToListAsync();
        }

        public async Task<Technicien> Get(string id)
        {
            return await context.Techniciens.Include(a => a.Affectations).ThenInclude(t => t.Tache).FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<string> GetIdUser(string username)
        {
            //var model = context.Techniciens.FirstOrDefaultAsync(t => t.Username == User.Identity.Name);
            return (await context.Techniciens.FirstOrDefaultAsync(t => t.Username == username)).ID;
        }

        public async Task<Technicien> GetUserByUsername(string username)
            => await context.Techniciens.Include(a => a.Affectations).ThenInclude(t => t.Tache).FirstOrDefaultAsync(t => t.Username == username);

        public async Task<IEnumerable<Tache>> GetTaches(string idUser)
        {
            return await context.Taches.AsNoTracking().Where(t => t.CreateurTache == idUser).ToListAsync();
        }

        public async Task<string> Update(Technicien technicien, string id)
        {
            User_App user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                user.UserName = technicien.Username;
                user.Email = technicien.Mail;
                IdentityResult ValidEmail = await userValidator.ValidateAsync(userManager, user);
                
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(technicien.Password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, technicien.Password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, technicien.Password);
                    }
                }

                if((ValidEmail.Succeeded && validPass == null) || (ValidEmail.Succeeded && technicien.Password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {

                        context.Entry(technicien).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        return "Modification réussite";
                    }
                }
            }
            return "Echec de modification";
        }
    }
}