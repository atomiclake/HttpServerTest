﻿namespace HttpServerTest.Core.Request;

public readonly struct RequestHeader
{
    public string Name { get; }

    public IEnumerable<RequestHeaderValue> Values { get; }

    public RequestHeader(string name, IEnumerable<RequestHeaderValue> values)
    {
        Name = name;
        Values = values;
    }

    public RequestHeader(string name)
        : this(name, [])
    {
        
    }

    public override readonly string ToString()
    {
        List<string> values = [];

        foreach (var value in Values
            .OrderBy(headerValue => headerValue.Quality is null)
            .ThenByDescending(headerValue => headerValue.Quality))
        {
            values.Add(value.ToString());
        }

        return string.Join(",", values);
    }
}