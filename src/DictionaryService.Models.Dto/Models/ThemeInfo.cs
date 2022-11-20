namespace DictionaryService.Models.Dto.Models;

public record ThemeInfo
{
  public Guid ThemeId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public List<WordInfo> Words { get; set; }
}
