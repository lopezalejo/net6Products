using ARAINV.Core.Entities;
using ARAINV.Infrastructure.DTOs.Users;
using System.Linq.Expressions;

namespace ARAINV.Infrastructure.Persistence.Interfaces.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> FilterUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);

        Task<IEnumerable<UserDTO>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
    }
}
