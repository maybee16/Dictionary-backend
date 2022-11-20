using DictionaryService.Mappers.Models.Interfaces;
using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Responses.Dictionary;

namespace DictionaryService.Mappers.Responses;

public class DictionaryResponseMapper : IDictionaryResponseMapper
{
  private readonly IThemeInfoMapper _themeInfoMapper;

  public DictionaryResponseMapper(
    IThemeInfoMapper themeInfoMapper)
  {
    _themeInfoMapper = themeInfoMapper;
  }

  public DictionaryResponse Map(DbDictionary dbDictionary)
  {
    return dbDictionary is null
      ? null
      : new DictionaryResponse
      {
        DictionaryId = dbDictionary.Id,
        Name = dbDictionary.Name,
        Description = dbDictionary.Description,
        IsActive = dbDictionary.IsActive,
        Themes = dbDictionary.Themes?.Select(_themeInfoMapper.Map).ToList()
      };
  }
}
