using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Word;

namespace DictionaryService.Mappers.Db;

public class DbWordMapper : IDbWordMapper
{
  public DbWord Map(CreateWordRequest request)
  {
    return request is null
      ? null
      : new DbWord
      {
        Id = Guid.NewGuid(),
        Name = request.Name,
        Translation = request.Translation,
        ThemeId = request.ThemeId,
        IsActive = true
      };
  }
}
