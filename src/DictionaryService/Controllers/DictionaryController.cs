using DictionaryService.Business.Commands.Dictionary.Interface;
using DictionaryService.Business.Commands.Dictionary.Interfaces;
using DictionaryService.Models.Dto.Requests.Dictionary;
using DictionaryService.Models.Dto.Requests.Dictionary.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Dictionary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DictionaryService.Controllers;

[Route("[controller]")]
[ApiController]
public class DictionaryController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateDictionaryCommand command,
    CreateDictionaryRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("get")]
  public async Task<OperationResultResponse<DictionaryResponse>> GetAsync(
    [FromServices] IGetDictionaryCommand command,
    [FromQuery] GetDictionaryFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
}
