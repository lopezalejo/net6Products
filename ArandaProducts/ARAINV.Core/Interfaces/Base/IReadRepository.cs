﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ARAINV.Core.Interfaces.Base
{
    public interface IReadRepository<T, TContext>
        where T : class
        where TContext : DbContext, new()
    {
        int GetCount();
        int GetCount(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, string orderBy = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T> FilterSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, string orderBy = null);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
    }
}
