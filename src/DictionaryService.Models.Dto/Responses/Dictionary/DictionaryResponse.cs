using DictionaryService.Models.Dto.Models;

namespace DictionaryService.Models.Dto.Responses.Dictionary;

public record DictionaryResponse
{
  public Guid DictionaryId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public bool IsActive { get; set; }
  public List<ThemeInfo> Themes { get; set; }
}
