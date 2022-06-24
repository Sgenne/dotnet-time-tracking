using API.Auth;

namespace API.Optional;

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

    
    /// <summary>
    /// Returns the contained value.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the Optional is empty.</exception>
    public T Some()
    {
        return Some<T>(v => v);
    }
    
    
    /// <summary>
    /// Converts the contained value to another type.
    /// </summary>
    /// <param name="handler">The function used to convert the contained value.</param>
    /// <typeparam name="TU">The type of the result</typeparam>
    /// <returns>The converted value.</returns>
    /// <exception cref="InvalidOperationException">If the Optional is empty.</exception>
    public TU Some<TU>(Func<T, TU> handler)
    {
        if (_value == null) throw new InvalidOperationException("Cannot call Some() on empty optional.");

        return handler(_value);
    }
    
    public static Optional<TU> Of<TU>(TU value)
    {
        return new Optional<TU>(false, value);
    }

    public static Optional<T> Empty()
    {
        return new Optional<T>(true, default(T));
    }

    
}