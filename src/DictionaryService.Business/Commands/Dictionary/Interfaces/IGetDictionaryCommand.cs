using DictionaryService.Models.Dto.Requests.Dictionary.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Dictionary;

namespace DictionaryService.Business.Commands.Dictionary.Interfaces;

public interface IGetDictionaryCommand
{
  Task<OperationResultResponse<DictionaryResponse>> ExecuteAsync(GetDictionaryFilter filter);
}
