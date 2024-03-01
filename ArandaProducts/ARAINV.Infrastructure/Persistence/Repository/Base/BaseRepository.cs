using ARAINV.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace ARAINV.Infrastructure.Persistence.Repository.Base
{
    public class BaseRepository<T, TKey, TContext> : IBaseRepository<T, TContext>
        where T : class
        where TContext : DbContext, new()
    {
        private TContext _dataContext;
        private readonly DbSet<T> _dbSet;
        protected IDbFactory<TContext> DbFactory { get; private set; }
        protected TContext DbContext { get => _dataContext ?? (_dataContext = DbFactory.Init()); }


        public BaseRepository(IDbFactory<TContext> dbFactory) { DbFactory = dbFactory; _dbSet = DbContext.Set<T>(); }


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, string orderBy = null)
        {
            return (!string.IsNullOrEmpty(orderBy)) ? await _dbSet.OrderBy(orderBy).ToListAsync(cancellationToken) : await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return (!string.IsNullOrEmpty(orderBy)) ? await _dbSet.Where(predicate).OrderBy(orderBy).ToListAsync(cancellationToken) : await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return (!string.IsNullOrEmpty(orderBy)) ? await _dbSet.Where(predicate).OrderBy(orderBy).ToListAsync(cancellationToken) : await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<T> FilterSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public int GetCount() { return _dbSet.Count(); }

        public int GetCount(Expression<Func<T, bool>> predicate) { return _dbSet.Count(predicate); }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string orderBy = null)
        {
            return (!string.IsNullOrEmpty(orderBy)) ? await _dbSet.OrderBy(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken) :
                                                      await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return (!string.IsNullOrEmpty(orderBy)) ? await _dbSet.OrderBy(orderBy).Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken) :
                                                      await _dbSet.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
