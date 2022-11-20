using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Word.Filters;
using Microsoft.EntityFrameworkCore;

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

  public Task<DbWord> GetAsync(GetWordFilter filter)
  {
    return filter is null
      ? null
      : _provider.Words
        .Where(word => word.Id == filter.WordId)
        .FirstOrDefaultAsync();
  }
}
