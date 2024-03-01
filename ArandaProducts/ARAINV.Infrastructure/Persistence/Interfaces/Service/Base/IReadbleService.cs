﻿using ARAINV.Core.Entities;
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
    public interface IReadbleService<TGetDto, TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default);
        Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
        Task<IEnumerable<TGetDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string orderBy = null);
        Task<IEnumerable<TGetDto>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
    }
}