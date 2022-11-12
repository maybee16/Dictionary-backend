using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;

namespace DictionaryService.Data;

public class DictionaryRepository : IDictionaryRepository
{
  private readonly IDataProvider _provider;

  public DictionaryRepository(
    IDataProvider provider)
  {
    _provider = provider;
  }

  public async Task<Guid?> CreateAsync(DbDictionary dbDictionary)
  {
    if (dbDictionary is null)
    {
      return null;
    }

    _provider.Dictionaries.Add(dbDictionary);
    await _provider.SaveAsync();

    return dbDictionary.Id;
  }
}
