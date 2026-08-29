using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SubscriptionPlan.Repository.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T?> AddAsync(T Entity);
        void Update(T Entity);
        void Remove(T Entity);
        Task<T?> GetByIdWithoutTrackingAsync(Expression<Func<T, bool>> predicate);
        Task<int> SaveChangeAsync();
    }
}
