namespace HttpServerTest.Core.Request;

public readonly struct RequestHeaderValue
{
    public string Value { get; }

    public float? Quality { get; }

    public bool HasQuality => Quality is not null;

    public RequestHeaderValue(string value, float? quality)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value must not be empty or blank", nameof(value));
        }

        Value = value;

        if (quality is not null and < 0.0f or > 1.0f)
        {
            throw new ArgumentException("Quality must not be less than 0 or greater than 1", nameof(quality));
        }

        Quality = quality;
    }

    public RequestHeaderValue(string value)
        : this(value, default)
    {
        
    }

    public override string ToString()
    {
        string quality = Quality is not null ?
            $";q={string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:F1}", Quality)}":
            "";

        return $"{Value}{quality}";
    }
}
