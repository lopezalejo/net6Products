using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ARAINV.Core.Interfaces.Repository
{
    public interface IUserRepository<TContext> : IReadRepository<User, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<User> GetUserAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> FilterUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
        Task<IEnumerable<User>> GetPagedUserAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string orderBy = null);
        Task<IEnumerable<User>> GetPagedUserAsync(int pageNumber, int pageSize, Expression<Func<User, bool>> predicate, CancellationToken cancellationToken, string orderBy = null);
        Task<User> SingleUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
