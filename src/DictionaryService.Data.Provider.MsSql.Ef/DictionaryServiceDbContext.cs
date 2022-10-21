using Microsoft.EntityFrameworkCore;

namespace DictionaryService.Data.Provider.MsSql.Ef;

public class DictionaryServiceDbContext : DbContext
{
  public DictionaryServiceDbContext(DbContextOptions<DictionaryServiceDbContext> options) : base(options)
  {

  }
}
