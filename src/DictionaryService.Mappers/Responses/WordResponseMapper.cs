using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Responses.Word;

namespace DictionaryService.Mappers.Responses;

public class WordResponseMapper : IWordResponseMapper
{
  public WordResponse Map(DbWord dbWord)
  {
    return dbWord is null
      ? null
      : new WordResponse
      {
        WordId = dbWord.Id,
        Name = dbWord.Name,
        Translation = dbWord.Translation,
        ThemeId = dbWord.ThemeId,
        IsActive = dbWord.IsActive
      };
  }
}
