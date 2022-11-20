using Microsoft.AspNetCore.Mvc;

namespace DictionaryService.Models.Dto.Requests.Word.Filters;

public record GetWordFilter
{
  [FromQuery(Name = "wordid")]
  public Guid WordId { get; set; }
}
