using DictionaryService.Business.Commands.Dictionary;
using DictionaryService.Business.Commands.Dictionary.Interface;
using DictionaryService.Business.Commands.Dictionary.Interfaces;
using DictionaryService.Business.Commands.Theme;
using DictionaryService.Business.Commands.Theme.Interface;
using DictionaryService.Business.Commands.Theme.Interfaces;
using DictionaryService.Business.Commands.Word;
using DictionaryService.Business.Commands.Word.Interfaces;
using DictionaryService.Data;
using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Data.Provider.MsSql.Ef;
using DictionaryService.Mappers.Db;
using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Mappers.Models;
using DictionaryService.Mappers.Models.Interfaces;
using DictionaryService.Mappers.Responses;
using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Dto.Requests.Dictionary;
using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Models.Dto.Requests.Word;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Interfaces;
using DictionaryService.Validation.Dictionary;
using DictionaryService.Validation.Theme;
using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

      services.AddHealthChecks()
        .AddSqlServer(dbConnStr);

      services.AddControllers();

      // Dictionary
      services.AddTransient<ICreateDictionaryCommand, CreateDictionaryCommand>();
      services.AddTransient<IGetDictionaryCommand, GetDictionaryCommand>();
      services.AddTransient<IValidator<CreateDictionaryRequest>, CreateDictionaryRequestValidator>();
      services.AddTransient<IDictionaryRepository, DictionaryRepository>();
      services.AddTransient<IDbDictionaryMapper, DbDictionaryMapper>();
      services.AddTransient<IDictionaryResponseMapper, DictionaryResponseMapper>();

      // Theme
      services.AddTransient<ICreateThemeCommand, CreateThemeCommand>();
      services.AddTransient<IGetThemeCommand, GetThemeCommand>();
      services.AddTransient<IValidator<CreateThemeRequest>, CreateThemeRequestValidator>();
      services.AddTransient<IThemeRepository, ThemeRepository>();
      services.AddTransient<IDbThemeMapper, DbThemeMapper>();
      services.AddTransient<IThemeInfoMapper, ThemeInfoMapper>();
      services.AddTransient<IThemeResponseMapper, ThemeResponseMapper>();

      // Word
      services.AddTransient<ICreateWordCommand, CreateWordCommand>();
      services.AddTransient<IGetWordCommand, GetWordCommand>();
      services.AddTransient<IValidator<CreateWordRequest>, CreateWordRequestValidator>();
      services.AddTransient<IWordRepository, WordRepository>();
      services.AddTransient<IDbWordMapper, DbWordMapper>();
      services.AddTransient<IWordInfoMapper, WordInfoMapper>();
      services.AddTransient<IWordResponseMapper, WordResponseMapper>();

      services.AddTransient<IDataProvider, DictionaryServiceDbContext>();
      services.AddTransient<IResponseCreator, ResponseCreator>();
      services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

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
