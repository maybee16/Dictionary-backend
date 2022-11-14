using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Validation.Theme.Interfaces;
using FluentValidation;

namespace DictionaryService.Validation.Theme;
public class CreateThemeRequestValidator : AbstractValidator<CreateThemeRequest>, ICreateThemeRequestValidator
{
  public CreateThemeRequestValidator()
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

    // DictionaryId
  }
}
