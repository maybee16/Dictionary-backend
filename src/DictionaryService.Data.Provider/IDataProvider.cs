using DictionaryService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace DictionaryService.Data.Provider;

public interface IDataProvider
{
  DbSet<DbDictionary> Dictionaries { get; set; }
  DbSet<DbTheme> Themes { get; set; }
  DbSet<DbWord> Words { get; set; }

  void Save();
  Task SaveAsync();
}
