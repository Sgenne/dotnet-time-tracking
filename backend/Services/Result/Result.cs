namespace backend.Services;

public class Result<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "";
    public Status Status { get; set; }
}