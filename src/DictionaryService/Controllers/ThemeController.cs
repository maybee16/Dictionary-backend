using DictionaryService.Business.Commands.Theme.Interface;
using DictionaryService.Business.Commands.Theme.Interfaces;
using DictionaryService.Models.Dto.Requests.Theme;
using DictionaryService.Models.Dto.Requests.Theme.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Theme;
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

  [HttpGet("get")]
  public async Task<OperationResultResponse<ThemeResponse>> GetAsync(
   [FromServices] IGetThemeCommand command,
   [FromQuery] GetThemeFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
}
