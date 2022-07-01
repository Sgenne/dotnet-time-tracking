namespace API.Utils.Result;

public class Result<T>
{
    private readonly T? _value;
    private readonly bool _success;

    public string Message { get; }
    public Status Status { get; }

    private Result(T value, Status status, string message, bool success)
    {
        _value = value;
        _success = success;
        Status = status;
        Message = message;
    }

    public TU Match<TU>(Func<T, TU> successHandler, Func<string, Status, TU> errorHandler)
    {
        return _success && _value != null
            ? successHandler(_value)
            : errorHandler(Message, Status);
    }

    public static Result<T> Success(T value) => new(value, Status.Ok, "", true);

    public static Result<T> Success(T value, string message, Status status) => new(
        value,
        status,
        message,
        true);

    public static Result<T> Error(string message, Status status) => new(
        default(T),
        status,
        message,
        false);
}