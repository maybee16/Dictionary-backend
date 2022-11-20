using DictionaryService.Mappers.Models.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Models;

namespace DictionaryService.Mappers.Models;

public class ThemeInfoMapper : IThemeInfoMapper
{
  private readonly IWordInfoMapper _wordInfoMapper;

  public ThemeInfoMapper(
    IWordInfoMapper wordInfoMapper)
  {
    _wordInfoMapper = wordInfoMapper;
  }

  public ThemeInfo Map(DbTheme dbTheme)
  {
    return dbTheme is null
      ? null
      : new ThemeInfo
      {
        ThemeId = dbTheme.Id,
        Name = dbTheme.Name,
        Description = dbTheme.Description,
        Words = dbTheme.Words?.Select(_wordInfoMapper.Map).ToList()
      };
  }
}
