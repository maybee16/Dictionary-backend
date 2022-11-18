using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Word;

namespace DictionaryService.Mappers.Db.Interfaces;

public interface IDbWordMapper
{
  DbWord Map(CreateWordRequest request);
}
