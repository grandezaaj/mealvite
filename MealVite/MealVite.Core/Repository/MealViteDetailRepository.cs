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
    public class MealViteDetailRepository : IMealViteDetails
    {

        public MealViteDbContext ctx;
        private bool disposed = false;

        public MealViteDetailRepository()
        {
            this.ctx = new MealViteDbContext();
            this.ctx.Configuration.ProxyCreationEnabled = false;
        }

        public List<MealViteDetail> GetAll()
        {
            return this.ctx.MealViteDetails
                .Where(e => e.IsDeleted == false).ToList();
        }

        public MealViteDetail FindById(int id)
        {
            return this.ctx.MealViteDetails
                .Where(e => e.MealviteId == id).SingleOrDefault();
        }

        public MealViteDetail Update(MealViteDetail entity)
        {
            this.ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.Save();

            return entity;
        }

        public MealViteDetail Insert(MealViteDetail entity)
        {
            this.ctx.MealViteDetails.Add(entity);
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
