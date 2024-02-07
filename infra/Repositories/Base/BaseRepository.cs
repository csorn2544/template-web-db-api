using domain.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace infra.Repositories.Base
{
    public class BaseRepository<TEntity, TContext>(TContext context) :
                QueryRepository<TEntity, TContext>(context), IRepository<TEntity>
          where TEntity : class
          where TContext : DbContext
    {
        public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<int> CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
            if (item == null) return default;
            _context.Set<TEntity>().Remove(item);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.UpdateRange(entities);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
