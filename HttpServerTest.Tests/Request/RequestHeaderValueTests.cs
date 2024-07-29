using HttpServerTest.Core.Request;

namespace HttpServerTest.Tests.Request;

public class RequestHeaderValueTests
{
    [Fact]
    public void RequestHeaderValue_ValueLessThanZero_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestHeaderValue("test", -0.1f);
        });
    }

    [Fact]
    public void RequestHeaderValue_ValueGreaterThanOne_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestHeaderValue("test", 1.01f);
        });
    }

    [Fact]
    public void RequestHeaderValue_EmptyValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestHeaderValue("");
        });
    }

    [Fact]
    public void RequestHeaderValue_BlankValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestHeaderValue("  ");
        });
    }
}
