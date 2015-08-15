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
    public class MealViteRepository : IMealVite
    {
        private MealViteDbContext ctx;
        private bool disposed = false;

        public MealViteRepository()
        {
            this.ctx = new MealViteDbContext();
            this.ctx.Configuration.ProxyCreationEnabled = false;
        }

        public List<Mealvite> GetAll()
        {
            return this.ctx.Mealvites
                .Where(e => e.IsDeleted == false).ToList();
        }

        public Mealvite FindById(int id)
        {
            return this.ctx.Mealvites
                .Where(e => e.MealviteId == id).SingleOrDefault();
        }

        public Mealvite Update (Mealvite entity)
        {
            this.ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.Save();

            return entity;
        }

        public Mealvite Insert (Mealvite entity)
        {
            this.ctx.Mealvites.Add(entity);
            this.Save();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.FindById(id);

            entity.IsDeleted = true;

            this.Update(entity);
        }

        public void Reserve(int mealViteId, int userId)
        {
            throw new NotImplementedException();
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
