using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Models.Dto.Responses;

namespace DictionaryService.Business.Commands.Theme.Interface;

public interface ICreateThemeCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateThemeRequest request);
}
