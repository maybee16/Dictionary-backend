using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Dictionary;

namespace DictionaryService.Mappers.Db.Interfaces;

public interface IDbDictionaryMapper
{
  DbDictionary Map(CreateDictionaryRequest request);
}
