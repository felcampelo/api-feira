using fair.ioc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using fair.infra.Context;
using Microsoft.EntityFrameworkCore;
using fair.api.Serilog;
using Serilog;
using fair.api.Middlewares;

try
{
    var corsPolicy = "AllowAll";

    var builder = WebApplication.CreateBuilder(args);
    SerilogExtension.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);



    builder.Services.AddResponseCompression(opt =>
    {
        opt.Providers.Add<GzipCompressionProvider>();
        opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "aplication/json" });
    });

    builder.Services.AddCors(options =>
                          options.AddPolicy(corsPolicy, builder =>
                          {
                              builder
                                  .AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                          }));     

    builder.Services.AddControllers();    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = $"API Feira", Version = "v1" });
    });


    builder.Services.AddApiVersioning(options => { options.ReportApiVersions = true; });

    builder.Services.AddVersionedApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

    DependencyResolver.RegisterServices(builder.Services, builder.Configuration);
    builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

    var app = builder.Build();

    app.UseMiddleware<ErrorHandlingMiddleware>();    

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseCors(corsPolicy);
    app.MapControllers();


    app.Run();
}
catch (Exception err)
{
    Log.Fatal(err, "A aplicação parou.");
}
finally
{
    Log.Information("Encerrando...");
    Log.CloseAndFlush();
}