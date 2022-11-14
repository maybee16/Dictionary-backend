using DictionaryService.Business.Commands.Theme.Interface;
using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Models.Dto.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DictionaryService.Controllers;

[Route("[controller]")]
[ApiController]
public class ThemeController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateThemeCommand command,
    CreateThemeRequest request)
  {
    return await command.ExecuteAsync(request);
  }
}
