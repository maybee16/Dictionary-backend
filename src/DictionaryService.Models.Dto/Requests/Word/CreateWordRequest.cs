using System.ComponentModel.DataAnnotations;

namespace DictionaryService.Models.Dto.Requests.Word;

public record CreateWordRequest
{
  [Required]
  public string Name { get; set; }
  [Required]
  public string Translation { get; set; }
  public Guid ThemeId { get; set; }
}
