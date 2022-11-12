using DictionaryService.Models.Dto.Requests.Dictionary;
using FluentValidation;

namespace DictionaryService.Validation.Dictionary.Interfaces;

public interface ICreateDictionaryRequestValidator : IValidator<CreateDictionaryRequest>
{
}
