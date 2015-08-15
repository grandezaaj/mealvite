using MealVite.Data;
using MealVite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MealVite.Core.Interfaces;

namespace MealVite.Core.Repository
{
    public class ProfileRepository : IProfile
    {
        private MealViteDbContext ctx;
        private bool disposed = false;

        public ProfileRepository()
        {
            this.ctx = new MealViteDbContext();
            this.ctx.Configuration.ProxyCreationEnabled = false;
        }

        public List<Profile> GetAll()
        {
            return this.ctx.Profiles
                .Where(e => e.IsDeleted == false).ToList();
        }

        public Profile FindById(int id)
        {
            return this.ctx.Profiles
                .Where(e => e.ProfileId == id).SingleOrDefault();
        }

        public Profile Update(Profile entity)
        {
            this.ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.Save();

            return entity;
        }

        public Profile Insert(Profile entity)
        {
            this.ctx.Profiles.Add(entity);
            this.Save();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.FindById(id);

            entity.IsDeleted = true;

            this.Update(entity);
        }

        private void Save()
        {
            this.ctx.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
