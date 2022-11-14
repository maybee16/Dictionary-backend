using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;

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
}
