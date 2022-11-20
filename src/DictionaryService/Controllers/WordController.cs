using DictionaryService.Business.Commands.Word.Interfaces;
using DictionaryService.Models.Dto.Requests.Word;
using DictionaryService.Models.Dto.Requests.Word.Filters;
using DictionaryService.Models.Dto.Responses;
using DictionaryService.Models.Dto.Responses.Word;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DictionaryService.Controllers;

[Route("[controller]")]
[ApiController]
public class WordController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateWordCommand command,
    CreateWordRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("get")]
  public async Task<OperationResultResponse<WordResponse>> GetAsync(
   [FromServices] IGetWordCommand command,
   [FromQuery] GetWordFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
}
