using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Word.Filters;

namespace DictionaryService.Data.Interfaces;

public interface IWordRepository
{
  Task<Guid?> CreateAsync(DbWord dbWord);

  Task<DbWord> GetAsync(GetWordFilter filter);
}
