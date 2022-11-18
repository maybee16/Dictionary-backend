using DictionaryService.Business.Commands.Word.Interfaces;
using DictionaryService.Data.Interfaces;
using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Dto.Requests.Word;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace DictionaryService.Business.Commands.Word;

public class CreateWordCommand : ICreateWordCommand
{
  private readonly IValidator<CreateWordRequest> _validator;
  private readonly IWordRepository _repository;
  private readonly IDbWordMapper _mapper;
  private readonly IResponseCreator _responseCreator;

  public CreateWordCommand(
    IValidator<CreateWordRequest> validator,
    IWordRepository repository,
    IDbWordMapper mapper,
    IResponseCreator responseCreator)
  {
    _validator = validator;
    _repository = repository;
    _mapper = mapper;
    _responseCreator = responseCreator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateWordRequest request)
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
