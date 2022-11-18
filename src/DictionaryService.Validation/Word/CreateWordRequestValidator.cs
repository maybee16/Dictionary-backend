using DictionaryService.Data.Interfaces;
using DictionaryService.Models.Dto.Requests.Word;
using DictionaryService.Validation.Theme.Interfaces;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DictionaryService.Validation.Theme;
public class CreateWordRequestValidator : AbstractValidator<CreateWordRequest>, ICreateWordRequestValidator
{
  private readonly Regex _regex = new(@"^([a-zA-Zа-яА-ЯёЁ]+)$");

  public CreateWordRequestValidator(
    IThemeRepository themeRepository)
  {
    RuleFor(dictionary => dictionary.Name)
      .Cascade(CascadeMode.Stop)
      .NotEmpty()
      .WithMessage("Name can not be empty.")
      .MinimumLength(2)
      .WithMessage("Name is too short.")
      .Must(x => _regex.IsMatch(x.Trim()))
      .WithMessage("Name contains invalid characters.")
      .MaximumLength(30)
      .WithMessage("Name is too long.");

    RuleFor(dictionary => dictionary.Translation)
      .Cascade(CascadeMode.Stop)
      .NotEmpty()
      .WithMessage("Translation can not be empty.")
      .MinimumLength(2)
      .WithMessage("Translation is too short.")
      .Must(x => _regex.IsMatch(x.Trim()))
      .WithMessage("Translation contains invalid characters.")
      .MaximumLength(30)
      .WithMessage("Translation is too long.");

    RuleFor(dictionary => dictionary.ThemeId)
      .MustAsync(async (x, _) => await themeRepository.DoesExistAsync(x))
      .WithMessage("This theme does not exist.");
  }
}
