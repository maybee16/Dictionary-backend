using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;

namespace DictionaryService.Data;

public class WordRepository : IWordRepository
{
  private readonly IDataProvider _provider;

  public WordRepository(
    IDataProvider provider)
  {
    _provider = provider;
  }

  public async Task<Guid?> CreateAsync(DbWord dbWord)
  {
    if (dbWord is null)
    {
      return null;
    }

    _provider.Words.Add(dbWord);
    await _provider.SaveAsync();

    return dbWord.Id;
  }
}
