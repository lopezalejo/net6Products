using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using ARAINV.Core.Interfaces.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service.Base
{
    public interface ICRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default);
        Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TAddDto> InsertAsync(TAddDto objDTO, CancellationToken cancellationToken = default);
        Task<TUpdDto> UpdateAsync(TUpdDto objDTO, CancellationToken cancellationToken = default);
        Task<TDelDto> DeleteAsync(TDelDto objDTO, CancellationToken cancellationToken = default);
    }
}
