using System.ComponentModel.DataAnnotations;

namespace DictionaryService.Models.Dto.Requests.Dictionary;

public record CreateDictionaryRequest
{
  [Required]
  public string Name { get; set; }
  public string Description { get; set; }
}
