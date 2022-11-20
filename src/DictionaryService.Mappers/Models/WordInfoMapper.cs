using DictionaryService.Mappers.Models.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Models;

namespace DictionaryService.Mappers.Models;

public class WordInfoMapper : IWordInfoMapper
{
  public WordInfo Map(DbWord dbWord)
  {
    return dbWord is null
      ? null
      : new WordInfo
      {
        WordId = dbWord.Id,
        Name = dbWord.Name,
        Translation = dbWord.Translation
      };
  }
}
