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

    /// <summary>
    /// Returns the contained value.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the Result represents an error.</exception>
    public T GetContained() => HandleSuccess(t => t);

    /// <summary>
    /// Calls the given function on the contained value and returns the result. 
    /// </summary>
    /// <param name="successHandler">The function used to produce the result.</param>
    /// <typeparam name="TU">The type of the returned value.</typeparam>
    /// <exception cref="InvalidOperationException">If the Result represents an error.</exception>
    public TU HandleSuccess<TU>(Func<T, TU> successHandler)
    {
        if (_value == null || !_success)
        {
            throw new InvalidOperationException("HandleSuccess cannot be called on an error Result.");
        }

        return successHandler(_value);
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