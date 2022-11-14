using DictionaryService.Models.Dto.Requests.Theme;
using FluentValidation;

namespace DictionaryService.Validation.Theme.Interfaces;

public interface ICreateThemeRequestValidator : IValidator<CreateThemeRequest>
{
}
