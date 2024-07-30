namespace HttpServerTest.Core.Util;

public struct Freezable<T>
{
    private T _value;

    public bool IsFrozen { get; init; }

    public T Value
    {
        readonly get => _value;

        set
        {
            if (!IsFrozen)
            {
                _value = value;
            }
        }
    }

    public Freezable(T value)
    {
        _value = value;
    }

    public void Freeze()
    {
        if (!IsFrozen)
        {
            this = this with { IsFrozen = true };
        }
    }

    public static Freezable<T> From(T value)
    {
        return new(value);
    }

    public static implicit operator T(Freezable<T> freezable)
    {
        return freezable.Value;
    }

    public static implicit operator Freezable<T>(T value)
    {
        return Freezable<T>.From(value);
    }
}
