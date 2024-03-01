using Microsoft.EntityFrameworkCore;

namespace ARAINV.Core.Interfaces.Base
{
    public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
    {
        TContext Init();
    }
}
