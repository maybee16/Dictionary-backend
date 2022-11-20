using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Models;

namespace DictionaryService.Mappers.Models.Interfaces;

public interface IWordInfoMapper
{
  WordInfo Map(DbWord dbWord);
}
