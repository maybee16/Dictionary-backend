using DictionaryService.Models.Dto.Requests.Dictionary;
using DictionaryService.Validation.Dictionary.Interfaces;
using FluentValidation;

namespace DictionaryService.Validation.Dictionary;
public class CreateDictionaryRequestValidator : AbstractValidator<CreateDictionaryRequest>, ICreateDictionaryRequestValidator
{
  public CreateDictionaryRequestValidator()
  {
    RuleFor(dictionary => dictionary.Name)
      .Cascade(CascadeMode.Stop)
      .NotEmpty()
      .WithMessage("Name can not be empty.")
      .MinimumLength(2)
      .WithMessage("Name is too short.")
      .MaximumLength(30)
      .WithMessage("Name is too long.");

    RuleFor(dictionary => dictionary.Description)
      .MaximumLength(150)
      .WithMessage("Description is too long.");
  }
}
