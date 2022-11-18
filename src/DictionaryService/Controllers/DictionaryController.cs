using DictionaryService.Business.Commands.Dictionary.Interface;
using DictionaryService.Models.Dto.Requests.Dictionary;
using DictionaryService.Models.Dto.Responses;
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

  [HttpPost("get")]
  public async Task<OperationResultResponse<DictionaryResponse>> CreateAsync(
    [FromServices] IGetDictionaryCommand command,
    GetDictionaryFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
}
