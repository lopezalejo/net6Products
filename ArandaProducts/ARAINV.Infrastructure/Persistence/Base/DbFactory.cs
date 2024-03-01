using ARAINV.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace ARAINV.Infrastructure.Persistence.Base
{
    public class DbFactory<TContext> : IDisposable, IDbFactory<TContext>
        where TContext : DbContext, new()
    {
        private bool _disposed;
        private TContext _dbContext;
        private Func<TContext> _instanceFunc;

        public DbFactory(Func<TContext> dbContextFactory)
        {
            _dbContext = dbContextFactory();
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public TContext Init()
        {
            return _dbContext ??= _instanceFunc.Invoke();
        }
    }
}
