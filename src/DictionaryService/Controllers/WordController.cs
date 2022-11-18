using DictionaryService.Business.Commands.Word.Interfaces;
using DictionaryService.Models.Dto.Requests.Word;
using DictionaryService.Models.Dto.Responses;
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
}
