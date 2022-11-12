using DictionaryService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace DictionaryService.Data.Provider.MsSql.Ef;

public class DictionaryServiceDbContext : DbContext, IDataProvider
{
  public DbSet<DbDictionary> Dictionaries { get; set; }
  public DbSet<DbTheme> Themes { get; set; }
  public DbSet<DbWord> Words { get; set; }

  public DictionaryServiceDbContext(DbContextOptions<DictionaryServiceDbContext> options) : base(options)
  {
  }

  public void Save()
  {
    SaveChanges();
  }

  public async Task SaveAsync()
  {
    await SaveChangesAsync();
  }
}
