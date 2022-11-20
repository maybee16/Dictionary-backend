using DictionaryService.Models.Dto.Models;

namespace DictionaryService.Models.Dto.Responses.Theme;

public record ThemeResponse
{
  public Guid ThemeId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public Guid DictionaryId { get; set; }
  public bool IsActive { get; set; }
  public List<WordInfo> Words { get; set; }
}
