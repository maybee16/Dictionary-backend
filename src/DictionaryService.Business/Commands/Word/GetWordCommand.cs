using DictionaryService.Business.Commands.Word.Interfaces;
using DictionaryService.Data.Interfaces;
using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Word.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Interfaces;
using DictionaryService.Models.Dto.Responses.Word;
using System.Net;

namespace DictionaryService.Business.Commands.Word;

public class GetWordCommand : IGetWordCommand
{
  private readonly IWordRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IWordResponseMapper _wordResponseMapper;

  public GetWordCommand(
    IWordRepository repository,
    IResponseCreator responseCreator,
    IWordResponseMapper wordResponseMapper)
  {
    _repository = repository;
    _responseCreator = responseCreator;
    _wordResponseMapper = wordResponseMapper;
  }

  public async Task<OperationResultResponse<WordResponse>> ExecuteAsync(GetWordFilter filter)
  {
    DbWord dbWord = await _repository.GetAsync(filter);

    if (dbWord is null)
    {
      return _responseCreator.CreateFailureResponse<WordResponse>(
        HttpStatusCode.NotFound,
        new List<string> { "Word not found" });
    }

    return new(body: _wordResponseMapper.Map(dbWord));
  }
}
