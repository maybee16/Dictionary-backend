namespace DictionaryService.Models.Dto.Responses;

public class OperationResultResponse<T>
{
  public T Body { get; set; }
  public List<string> Errors { get; set; } = new List<string>();

  public OperationResultResponse(T body = default(T), List<string> errors = null)
  {
    Body = body;
    Errors = errors ?? new List<string>();
  }
}
