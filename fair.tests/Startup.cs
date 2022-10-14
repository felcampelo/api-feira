using fair.ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace fair.tests
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();

        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options => { options.ReportApiVersions = true; });
            services.AddControllers().AddApplicationPart(Assembly.Load("fair.api")).AddControllersAsServices();
            DependencyResolver.RegisterServices(services, Configuration);
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
