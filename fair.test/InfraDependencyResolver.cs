using EntityFrameworkCore.UseRowNumberForPaging;
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
        private const string ConnString = "Data Source=localhost;Initial Catalog=FeiraApp;Integrated Security=SSPI;Persist Security Info=False;";

        internal static ServiceProvider RegisterServices()
        {
            var serviceProvider = new ServiceCollection().AddDbContext<FairContext>(options =>
               options.UseSqlServer(ConnString,
               i => i.UseRowNumberForPaging())
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors())
           .AddTransient<FairContext>()
           .AddScoped<IFairRepository, FairRepository>()
           .AddLogging()
           .BuildServiceProvider();

            return serviceProvider;
        }
    }

}
