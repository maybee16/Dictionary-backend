using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Theme;

namespace DictionaryService.Mappers.Db;

public class DbThemeMapper : IDbThemeMapper
{
  public DbTheme Map(CreateThemeRequest request)
  {
    Guid themeId = Guid.NewGuid();

    return request is null
      ? null
      : new DbTheme
      {
        Id = themeId,
        Name = request.Name,
        Description = request.Description,
        DictionaryId = request.DictionaryId,
        IsActive = true
      };
  }
}
