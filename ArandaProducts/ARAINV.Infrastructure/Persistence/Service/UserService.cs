using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using ARAINV.Infrastructure.Persistence.Interfaces.Service;
using ARAINV.Core.Data;
using ARAINV.Infrastructure.DTOs.Users;
using ARAINV.Core.Interfaces.Repository;
using ARAINV.Infrastructure.Persistence.Service.Base;
using AutoMapper;
using System.Linq.Expressions;

namespace ARAINV.Infrastructure.Persistence.Service
{
    public class UserService : RService<UserDTO, int, User, IUserRepository<ArandaDbContext>, ArandaDbContext>, IUserService
    {
        public UserService(IMapper mapper, IUnitOfWork<ArandaDbContext> unitOfWork, IUserRepository<ArandaDbContext> userRepository) :
                base(userRepository, unitOfWork, mapper)
        { }
        public async Task<IEnumerable<UserDTO>> FilterUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await FilterAsync(predicate, cancellationToken, orderBy);
        }

        public async Task<IEnumerable<UserDTO>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, orderBy);
        }
    }
}
