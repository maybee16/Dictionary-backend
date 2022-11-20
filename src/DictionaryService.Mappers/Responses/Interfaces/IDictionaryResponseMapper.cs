using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Responses.Dictionary;
using DictionaryService.Models.Dto.Responses.Theme;

namespace DictionaryService.Mappers.Responses.Interfaces;

public interface IDictionaryResponseMapper
{
  DictionaryResponse Map(DbDictionary dbDictionary);
}
