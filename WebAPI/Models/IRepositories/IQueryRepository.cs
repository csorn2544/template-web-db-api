using System.Linq.Expressions;

namespace WebAPI.Models.IRepositories
{
    public interface IQueryRepository<T> where T : class
    {
        IQueryable<T> GetAsync();
        IQueryable<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
        Task<List<T>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> DoesExist(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
