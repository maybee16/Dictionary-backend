using DictionaryService.Business.Commands.Theme.Interfaces;
using DictionaryService.Business.Commands.Word.Interfaces;
using DictionaryService.Data.Interfaces;
using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Theme.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Interfaces;
using DictionaryService.Models.Dto.Responses.Theme;
using DictionaryService.Models.Dto.Responses.Word;
using System.Net;

namespace DictionaryService.Business.Commands.Theme;

public class GetThemeCommand : IGetThemeCommand
{
  private readonly IThemeRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IThemeResponseMapper _themeResponseMapper;

  public GetThemeCommand(
    IThemeRepository repository,
    IResponseCreator responseCreator,
    IThemeResponseMapper themeResponseMapper)
  {
    _repository = repository;
    _responseCreator = responseCreator;
    _themeResponseMapper = themeResponseMapper;
  }

  public async Task<OperationResultResponse<ThemeResponse>> ExecuteAsync(GetThemeFilter filter)
  {
    DbTheme dbTheme = await _repository.GetAsync(filter);

    if (dbTheme is null)
    {
      return _responseCreator.CreateFailureResponse<ThemeResponse>(
        HttpStatusCode.NotFound,
        new List<string> { "Theme not found" });
    }

    return new(body: _themeResponseMapper.Map(dbTheme));
  }
}
