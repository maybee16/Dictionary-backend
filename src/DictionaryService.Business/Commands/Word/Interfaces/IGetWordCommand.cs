using DictionaryService.Models.Dto.Requests.Word.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Word;

namespace DictionaryService.Business.Commands.Word.Interfaces;

public interface IGetWordCommand
{
  Task<OperationResultResponse<WordResponse>> ExecuteAsync(GetWordFilter filter);
}
