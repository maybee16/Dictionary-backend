namespace DictionaryService.Models.Dto.Responses.Word;

public record WordResponse
{
  public Guid WordId { get; set; }
  public string Name { get; set; }
  public string Translation { get; set; }
  public Guid ThemeId { get; set; }
  public bool IsActive { get; set; }
}
