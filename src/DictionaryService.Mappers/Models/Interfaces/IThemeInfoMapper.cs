using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Models;

namespace DictionaryService.Mappers.Models.Interfaces;

public interface IThemeInfoMapper
{
  ThemeInfo Map(DbTheme dbTheme);
}
