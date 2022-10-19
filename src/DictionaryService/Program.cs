using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace DictionaryService
{
  public class Program
  {
    public static void Main()
    {
      try
      {
        new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .Build();

        CreateHostBuilder().Build().Run();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
