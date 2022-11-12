using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.Models.Dto.Responses.Interfaces;

public interface IResponseCreator
{
  OperationResultResponse<T> CreateFailureResponse<T>(HttpStatusCode statusCode, List<string> errors = null);
}
