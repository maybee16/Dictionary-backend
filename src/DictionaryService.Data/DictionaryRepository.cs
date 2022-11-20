using DictionaryService.Data.Interfaces;
using DictionaryService.Data.Provider;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Dictionary.Filters;
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

  private IQueryable<DbDictionary> CreateGetPredicates(
      GetDictionaryFilter filter,
      IQueryable<DbDictionary> query)
  {
    if (filter.IncludeThemes)
    {
      return filter.IncludeWords
      ? query
        .Include(dictionary => dictionary.Themes.Where(theme => theme.IsActive))
          .ThenInclude(theme => theme.Words.Where(word => word.IsActive))
      : query
        .Include(dictionary => dictionary.Themes.Where(theme => theme.IsActive));
    }

    return query;
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

  public Task<DbDictionary> GetAsync(GetDictionaryFilter filter)
  {
    return filter is null
      ? null
      : CreateGetPredicates(filter, _provider.Dictionaries
        .Where(dictionary => dictionary.Id == filter.DictionaryId)
        .AsQueryable())
      .FirstOrDefaultAsync();
  }
}
