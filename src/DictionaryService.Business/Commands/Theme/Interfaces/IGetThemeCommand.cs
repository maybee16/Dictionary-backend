using DictionaryService.Models.Dto.Requests.Theme.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Theme;
using DictionaryService.Models.Dto.Responses.Word;

namespace DictionaryService.Business.Commands.Theme.Interfaces;

public interface IGetThemeCommand
{
  Task<OperationResultResponse<ThemeResponse>> ExecuteAsync(GetThemeFilter filter);
}
