using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealVite.Core.Base
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        T FindById(int id);
        T Update(T entity);
        T Insert(T entity);
        void Delete(int id);

    }
}
