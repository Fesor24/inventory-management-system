using IMS.Domain.Primitives;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Data.Interceptors;
using IMS.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IMS.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, opt) =>
        {
            opt.UseNpgsql(config.GetConnectionString(ApplicationDbContext.DATABASE_CONNECTION),
                mig => mig.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
            .AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>()
            );
        });

        //services.AddDbContext<ApplicationDbContext>((sp, opt) =>
        //{
        //    opt.UseInMemoryDatabase("IMS")
        //    .AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());
        //});

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
