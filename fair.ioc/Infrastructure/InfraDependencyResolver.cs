using EntityFrameworkCore.UseRowNumberForPaging;
using fair.infra.Context;
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

            return services;
        }
    }
}
