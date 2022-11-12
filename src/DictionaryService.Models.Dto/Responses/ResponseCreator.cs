using DictionaryService.Models.Dto.Responses.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace DictionaryService.Models.Dto.Responses;

public class ResponseCreator : IResponseCreator
{
  private const string BadRequest = "Request is not correct.";
  private const string NotFound = "Nothing found on request.";

  private readonly IHttpContextAccessor _httpContextAccessor;

  public ResponseCreator(
    IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public OperationResultResponse<T> CreateFailureResponse<T>(HttpStatusCode statusCode, List<string> errors = null)
  {
    _httpContextAccessor.HttpContext.Response.StatusCode = (int)statusCode;

    if (errors == null)
    {
      switch (statusCode)
      {
        case HttpStatusCode.BadRequest:
          errors = new() { BadRequest };
          break;
        case HttpStatusCode.NotFound:
          errors = new() { NotFound };
          break;
      }
    }

    return new OperationResultResponse<T>
    {
      Body = default,
      Errors = errors
    };
  }
}
