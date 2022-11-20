using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Dictionary.Filters;

namespace DictionaryService.Data.Interfaces;

public interface IDictionaryRepository
{
  Task<Guid?> CreateAsync(DbDictionary dbDictionary);

  Task<DbDictionary> GetAsync(GetDictionaryFilter filter);

  Task<bool> DoesExistAsync(Guid dictionaryId);
}
