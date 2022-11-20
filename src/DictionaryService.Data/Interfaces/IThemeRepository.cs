using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Theme.Filters;

namespace DictionaryService.Data.Interfaces;

public interface IThemeRepository
{
  Task<Guid?> CreateAsync(DbTheme dbTheme);

  Task<DbTheme> GetAsync(GetThemeFilter filter);

  Task<bool> DoesExistAsync(Guid themeId);
}
