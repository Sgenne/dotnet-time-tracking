namespace backend.Optional;

public class Optional<T>
{
    private readonly T? _value;

    public bool IsEmpty { get; }

    private Optional(bool isEmpty, T? value)
    {
        IsEmpty = isEmpty;
        _value = value;
    }

    public TU Match<TU>(Func<T, TU> someHandler, Func<TU> noneHandler) =>
        !IsEmpty && _value != null 
            ? someHandler(_value) 
            : noneHandler();

    public static Optional<TU> Of<TU>(TU value)
    {
        return new Optional<TU>(false, value);
    }

    public static Optional<T> Empty()
    {
        return new Optional<T>(true, default(T));
    }
}