using EntityFrameworkCore.UseRowNumberForPaging;
using fair.application.Contract;
using fair.application.Service;
using fair.domain.RepositoryInterfaces;
using fair.infra.Context;
using fair.infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace fair.ioc.Infrastructure
{
    internal class InfraDependencyResolver
    {
        internal static IServiceCollection ChildServiceRegister(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FairContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("FairContext")
            , i => i.UseRowNumberForPaging()
            ));

            services.AddScoped<IFairRepository, FairRepository>();

            return services;
        }
    }
}
