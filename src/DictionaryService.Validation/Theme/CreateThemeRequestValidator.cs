using DictionaryService.Data.Interfaces;
using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Validation.Theme.Interfaces;
using FluentValidation;

namespace DictionaryService.Validation.Theme;
public class CreateThemeRequestValidator : AbstractValidator<CreateThemeRequest>, ICreateThemeRequestValidator
{
  public CreateThemeRequestValidator(
    IDictionaryRepository dictionaryRepository)
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

    RuleFor(dictionary => dictionary.DictionaryId)
      .MustAsync(async (x, _) => await dictionaryRepository.DoesExistAsync(x))
      .WithMessage("This dictionary does not exist.");
  }
}
