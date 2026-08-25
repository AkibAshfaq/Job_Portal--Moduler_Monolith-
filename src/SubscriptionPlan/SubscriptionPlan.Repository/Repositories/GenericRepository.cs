using Microsoft.EntityFrameworkCore;
using SubscriptionPlan.Repository.Context;
using SubscriptionPlan.Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SubscriptionPlan.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly PortalDbContext _context;
        public readonly DbSet<T> _dbset;

        public GenericRepository(PortalDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public async Task AddAsync(T Entity)
        {
            await _dbset.AddAsync(Entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Update(T Entity)
        {
            _dbset.Update(Entity);
        }

        public async Task<T?> GetByIdWithoutTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
