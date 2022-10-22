using DictionaryService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace DictionaryService.Data.Provider;

public interface IDataProvider
{
  public DbSet<DbDictionary> Dictionaries { get; set; }
  public DbSet<DbTheme> Themes { get; set; }
  public DbSet<DbWord> Words { get; set; }
  public DbSet<DbWordsDescription> WordsDescriptions { get; set; }
}
