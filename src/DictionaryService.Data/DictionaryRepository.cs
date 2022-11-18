using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;
using Microsoft.EntityFrameworkCore;

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

  public Task<bool> DoesExistAsync(Guid dictionaryId)
  {
    return _provider.Dictionaries.AnyAsync(x => x.Id == dictionaryId);
  }
}
