using DictionaryService.Models.Db;

namespace DictionaryService.Data.Interfaces;

public interface IThemeRepository
{
  Task<Guid?> CreateAsync(DbTheme dbTheme);
}
