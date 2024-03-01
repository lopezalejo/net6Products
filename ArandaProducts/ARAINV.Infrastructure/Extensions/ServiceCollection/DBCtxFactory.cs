using ARAINV.Core.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ARAINV.Infrastructure.Extensions.ServiceCollection
{
    public static class DBCtxFactory
    {
        public static IServiceCollection AddDBFactory(this IServiceCollection services)
        {
            services.AddScoped<Func<ArandaDbContext>>((prov) => () => prov.GetService<ArandaDbContext>());

            return services;
        }
    }
}
