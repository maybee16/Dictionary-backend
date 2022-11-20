namespace DictionaryService.Models.Dto.Models;

public record WordInfo
{
  public Guid WordId { get; set; }
  public string Name { get; set; }
  public string Translation { get; set; }
}
