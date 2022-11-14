using DictionaryService.Business.Commands.Theme.Interface;
using DictionaryService.Data.Interfaces;
using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace DictionaryService.Business.Commands.Theme;

public class CreateThemeCommand : ICreateThemeCommand
{
  private readonly IValidator<CreateThemeRequest> _validator;
  private readonly IThemeRepository _repository;
  private readonly IDbThemeMapper _mapper;
  private readonly IResponseCreator _responseCreator;

  public CreateThemeCommand(
    IValidator<CreateThemeRequest> validator,
    IThemeRepository repository,
    IDbThemeMapper mapper,
    IResponseCreator responseCreator)
  {
    _validator = validator;
    _repository = repository;
    _mapper = mapper;
    _responseCreator = responseCreator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateThemeRequest request)
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
