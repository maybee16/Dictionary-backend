using Microsoft.AspNetCore.Mvc;

namespace DictionaryService.Models.Dto.Requests.Theme.Filters;

public record GetThemeFilter
{
  [FromQuery(Name = "themeid")]
  public Guid ThemeId { get; set; }

  [FromQuery(Name = "includewords")]
  public bool IncludeWords { get; set; } = true;
}
