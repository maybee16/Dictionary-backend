using DictionaryService.Business.Commands.Dictionary.Interfaces;
using DictionaryService.Data.Interfaces;
using DictionaryService.Mappers.Responses.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Dictionary.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Dictionary;
using DictionaryService.Models.Dto.Responses.Interfaces;
using System.Net;

namespace DictionaryService.Business.Commands.Dictionary;

public class GetDictionaryCommand : IGetDictionaryCommand
{
  private readonly IDictionaryRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IDictionaryResponseMapper _dictionaryResponseMapper;

  public GetDictionaryCommand(
    IDictionaryRepository repository,
    IResponseCreator responseCreator,
    IDictionaryResponseMapper dictionaryResponseMapper)
  {
    _repository = repository;
    _responseCreator = responseCreator;
    _dictionaryResponseMapper = dictionaryResponseMapper;
  }

  public async Task<OperationResultResponse<DictionaryResponse>> ExecuteAsync(GetDictionaryFilter filter)
  {
    DbDictionary dbDictionary = await _repository.GetAsync(filter);

    if (dbDictionary is null)
    {
      return _responseCreator.CreateFailureResponse<DictionaryResponse>(
        HttpStatusCode.NotFound,
        new List<string> { "Dictionary not found" });
    }

    return new(body: _dictionaryResponseMapper.Map(dbDictionary));
  }
}
