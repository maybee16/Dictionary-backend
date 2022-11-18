using DictionaryService.Models.Dto.Requests.Word;
using FluentValidation;

namespace DictionaryService.Validation.Theme.Interfaces;

public interface ICreateWordRequestValidator : IValidator<CreateWordRequest>
{
}
