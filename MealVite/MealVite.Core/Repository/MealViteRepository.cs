using MealVite.Data;
using MealVite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MealVite.Core.Repository
{
    public class MealViteRepository
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

        private void Save()
        {
            this.ctx.SaveChanges();
        }

        public void Reserve(int mealviteId, int userId)
        {
            throw new NotFiniteNumberException();
        }

        public void CancelReservation(int mealviteId, int userId)
        {
            throw new NotImplementedException();
        }

        public void CancelMealvite(int mealviteId, int userId, string reason)
        {
            throw new NotImplementedException();
        }

        public void MoveMealvite(int mealviteId, int userId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void RateAndComment(int mealviteId, int userId, int rate, string comment)
        {
            throw new NotImplementedException();
        }

        public double CalculateTotal(int mealviteId)
        {
            return 1.0;
        }

        public int GetAtendeesCount(int mealviteId)
        {
            return 1;
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
