using System.ComponentModel.DataAnnotations;

namespace DictionaryService.Models.Dto.Requests.Theme;

public record CreateThemeRequest
{
  [Required]
  public string Name { get; set; }
  public string Description { get; set; }
  public Guid DictionaryId { get; set; }
}
