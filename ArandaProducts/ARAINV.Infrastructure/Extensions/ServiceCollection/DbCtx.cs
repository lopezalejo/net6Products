using ARAINV.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARAINV.Infrastructure.Extensions.ServiceCollection
{
    public static class DbCtx
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArandaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ArandaDbContext"));
            });

            return services;
        }
    }
}
