using fair.application.Contract;
using fair.application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace fair.ioc.Application
{
    internal class ApplicationDependencyResolver
    {
        internal static void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IFairService, FairService>();
        }
    }
}
