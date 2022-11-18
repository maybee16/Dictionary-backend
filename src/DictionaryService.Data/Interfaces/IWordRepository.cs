using DictionaryService.Models.Db;

namespace DictionaryService.Data.Interfaces;

public interface IWordRepository
{
  Task<Guid?> CreateAsync(DbWord dbWord);
}
