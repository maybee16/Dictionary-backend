using DictionaryService.Data.Provider.MsSql.Ef;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DictionaryService
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      string dbConnStr = Configuration.GetConnectionString("SQLConnectionString");

      services.AddDbContext<DictionaryServiceDbContext>(options =>
      {
        options.UseSqlServer(dbConnStr);
      });

      services.AddControllers();

      services.AddMassTransit(mt =>
      {
        mt.UsingRabbitMq((context, config) =>
        {
          config.Host("localhost", "/", host =>
          {
            host.Username("guest");
            host.Password("guest");
          });
        });
      });

      services.AddMassTransitHostedService();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      using IServiceScope serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

      using var dbContext = serviceScope.ServiceProvider.GetService<DictionaryServiceDbContext>();

      dbContext.Database.Migrate();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
