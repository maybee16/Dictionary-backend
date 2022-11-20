using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Theme.Filters;
using Microsoft.EntityFrameworkCore;

namespace DictionaryService.Data;

public class ThemeRepository : IThemeRepository
{
  private readonly IDataProvider _provider;

  public ThemeRepository(
    IDataProvider provider)
  {
    _provider = provider;
  }

  public async Task<Guid?> CreateAsync(DbTheme dbTheme)
  {
    if (dbTheme is null)
    {
      return null;
    }

    _provider.Themes.Add(dbTheme);
    await _provider.SaveAsync();

    return dbTheme.Id;
  }

  public Task<bool> DoesExistAsync(Guid themeId)
  {
    return _provider.Themes.AnyAsync(x => x.Id == themeId);
  }

  public Task<DbTheme> GetAsync(GetThemeFilter filter)
  {
    return filter is null
      ? null
      : _provider.Themes
        .Where(theme => theme.Id == filter.ThemeId)
        .Include(theme => theme.Words.Where(word => word.IsActive))
        .FirstOrDefaultAsync();
  }
}
