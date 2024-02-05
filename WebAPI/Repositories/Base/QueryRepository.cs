using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Models.IRepositories;

namespace WebAPI.Repositories.Base
{
    public class QueryRepository<TEntity, TContext>(TContext context) : IQueryRepository<TEntity>
                 where TEntity : class
                 where TContext : DbContext
    {
        private protected readonly TContext _context = context;

        public virtual async Task<bool> DoesExist(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().FindAsync([id], cancellationToken);
        }

        public virtual IQueryable<TEntity> GetAsync()
        {
            return _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

    }
}
