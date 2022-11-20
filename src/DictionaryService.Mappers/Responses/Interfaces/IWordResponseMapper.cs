using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Responses.Word;

namespace DictionaryService.Mappers.Responses.Interfaces;

public interface IWordResponseMapper
{
  WordResponse Map(DbWord dbWord);
}
