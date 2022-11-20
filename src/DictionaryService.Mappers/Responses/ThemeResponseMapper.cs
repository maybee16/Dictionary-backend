using DictionaryService.Mappers.Models.Interfaces;
using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Responses.Theme;
using DictionaryService.Models.Dto.Responses.Word;

namespace DictionaryService.Mappers.Responses;

public class ThemeResponseMapper : IThemeResponseMapper
{
  private readonly IWordInfoMapper _wordInfoMapper;

  public ThemeResponseMapper(
    IWordInfoMapper wordInfoMapper)
  {
    _wordInfoMapper = wordInfoMapper;
  }

  public ThemeResponse Map(DbTheme dbTheme)
  {
    return dbTheme is null
      ? null
      : new ThemeResponse
      {
        ThemeId = dbTheme.Id,
        Name = dbTheme.Name,
        Description = dbTheme.Description,
        DictionaryId = dbTheme.DictionaryId,
        IsActive = dbTheme.IsActive,
        Words = dbTheme.Words?.Select(_wordInfoMapper.Map).ToList()
      };
  }
}
