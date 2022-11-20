using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Responses.Theme;
using DictionaryService.Models.Dto.Responses.Word;

namespace DictionaryService.Mappers.Responses.Interfaces;

public interface IThemeResponseMapper
{
  ThemeResponse Map(DbTheme dbTheme);
}
