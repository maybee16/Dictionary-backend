using DictionaryService.Models.Dto.Requests.Word;
using DictionaryService.Models.Dto.Responses;

namespace DictionaryService.Business.Commands.Word.Interfaces;

public interface ICreateWordCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateWordRequest request);
}
