using DictionaryService.Models.Db;

namespace DictionaryService.Data.Interfaces;

public interface IDictionaryRepository
{
  Task<Guid?> CreateAsync(DbDictionary dbDictionary);

  Task<bool> DoesExistAsync(Guid dictionaryId);
}
