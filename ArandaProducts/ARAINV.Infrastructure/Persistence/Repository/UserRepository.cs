using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using ARAINV.Core.Data;
using ARAINV.Core.Interfaces.Repository;
using ARAINV.Infrastructure.Persistence.Repository.Base;
using System.Linq.Expressions;

namespace ARAINV.Infrastructure.Persistence.Repository
{
    public class UserRepository : ReadRepository<User, ArandaDbContext>, IUserRepository<ArandaDbContext>
    {
        public UserRepository(IDbFactory<ArandaDbContext> dbFactory) : base(dbFactory) { }
        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await GetAllAsync(cancellationToken);
        }
        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(id, cancellationToken);
        }
        public async Task<IEnumerable<User>> FilterUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await FilterAsync(predicate, cancellationToken, orderBy);
        }

        public async Task<User> SingleUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await FilterSingleAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetPagedUserAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await GetPagedAsync(pageNumber, pageSize, cancellationToken, orderBy);
        }

        public async Task<IEnumerable<User>> GetPagedUserAsync(int pageNumber, int pageSize, Expression<Func<User, bool>> predicate, CancellationToken cancellationToken, string orderBy = null)
        {
            return await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, orderBy);
        }
    }
}
