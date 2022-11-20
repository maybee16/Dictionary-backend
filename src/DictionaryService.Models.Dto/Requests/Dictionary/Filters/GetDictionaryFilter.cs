using Microsoft.AspNetCore.Mvc;

namespace DictionaryService.Models.Dto.Requests.Dictionary.Filters;

public record GetDictionaryFilter
{
  [FromQuery(Name = "dictionaryid")]
  public Guid DictionaryId { get; set; }

  [FromQuery(Name = "includethemes")]
  public bool IncludeThemes { get; set; } = true;

  [FromQuery(Name = "includewords")]
  public bool IncludeWords { get; set; } = true;
}
