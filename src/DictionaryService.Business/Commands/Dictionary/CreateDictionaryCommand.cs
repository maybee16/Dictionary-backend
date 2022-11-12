using DictionaryService.Business.Commands.Dictionary.Interface;
using DictionaryService.Data.Interfaces;
using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Dto.Requests.Dictionary;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace DictionaryService.Business.Commands.Dictionary;

public class CreateDictionaryCommand : ICreateDictionaryCommand
{
  private readonly IValidator<CreateDictionaryRequest> _validator;
  private readonly IDictionaryRepository _repository;
  private readonly IDbDictionaryMapper _mapper;
  private readonly IResponseCreator _responseCreator;

  public CreateDictionaryCommand(
    IValidator<CreateDictionaryRequest> validator,
    IDictionaryRepository repository,
    IDbDictionaryMapper mapper,
    IResponseCreator responseCreator)
  {
    _validator = validator;
    _repository = repository;
    _mapper = mapper;
    _responseCreator = responseCreator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateDictionaryRequest request)
  {
    ValidationResult validationResult = await _validator.ValidateAsync(request);

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.BadRequest,
        validationResult.Errors.Select(x => x.ErrorMessage).ToList());
    }

    OperationResultResponse<Guid?> response = new(body: await _repository.CreateAsync(_mapper.Map(request)));

    if (response.Body is null)
    {
      return _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.BadRequest);
    }

    return response;
  }
}
