namespace Domain.Helpers;

public class ResultResponse<T>
{
    public bool success { get; set; }
    public string type { get; set; }
    public string message { get; set; }
    public T Data { get; set; }
}
