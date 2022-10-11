using fair.ioc.Application;
using fair.ioc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace fair.ioc
{
    public static class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            ApplicationDependencyResolver.ChildServiceRegister(services);
            InfraDependencyResolver.ChildServiceRegister(services, configuration);
        }
    }
}
