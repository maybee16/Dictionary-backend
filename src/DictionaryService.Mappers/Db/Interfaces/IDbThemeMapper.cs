using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Theme;

namespace DictionaryService.Mappers.Db.Interfaces;

public interface IDbThemeMapper
{
  DbTheme Map(CreateThemeRequest request);
}
