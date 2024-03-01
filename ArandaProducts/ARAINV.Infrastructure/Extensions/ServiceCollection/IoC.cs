using ARAINV.Core.Interfaces.Base;
using ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service;
using ARAINV.Core.Data;
using ARAINV.Infrastructure.Persistence.Base;
using ARAINV.Core.Interfaces.Repository;
using ARAINV.Infrastructure.Persistence.Interfaces.Service;
using ARAINV.Infrastructure.Persistence.Repository;
using ARAINV.Infrastructure.Persistence.Service;
using Microsoft.Extensions.DependencyInjection;


namespace ARAINV.Infrastructure.Extensions.ServiceCollection
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory<ArandaDbContext>, DbFactory<ArandaDbContext>>();
            services.AddScoped<IUnitOfWork<ArandaDbContext>, UnitOfWork<ArandaDbContext>>();

            services.AddTransient<IProductRepository<ArandaDbContext>, ProductRepository>();
            services.AddTransient<IUserRepository<ArandaDbContext>, UserRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJWTService, JWTService>();

            return services;
        }
    }
}
