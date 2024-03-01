﻿using Microsoft.EntityFrameworkCore;

namespace ARAINV.Core.Interfaces.Base
{
    public interface IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        void CreateTransaction();
        Task CreateTransactionAsync();
        Task CreateTransactionAsync(CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync();
        Task RollbackAsync(CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
