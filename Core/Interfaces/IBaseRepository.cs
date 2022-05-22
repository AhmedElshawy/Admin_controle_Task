using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync (Expression<Func<T,bool>> criteria);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(Expression<Func<T, object>> include);
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria);

        void Add(T entity);

        void Update(T entity);
    }
}
