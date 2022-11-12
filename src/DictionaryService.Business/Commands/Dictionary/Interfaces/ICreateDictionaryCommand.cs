using DictionaryService.Models.Dto.Requests.Dictionary;
using DictionaryService.Models.Dto.Responses;

namespace DictionaryService.Business.Commands.Dictionary.Interface;

public interface ICreateDictionaryCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateDictionaryRequest request);
}
