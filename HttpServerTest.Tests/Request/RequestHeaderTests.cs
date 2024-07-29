using HttpServerTest.Core.Request;

namespace HttpServerTest.Tests.Request;

public class RequestHeaderTests
{
    private readonly List<RequestHeader> DefaultTestData;

    public RequestHeaderTests()
    {
        DefaultTestData =
        [
            new("Host", [new("developer.mozilla.org")]),
            new("User-Agent", [new("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.9; rv:50.0) Gecko/20100101 Firefox/50.0")]),
            new("Accept", [new("text/html"), new("application/xhtml+xml"), new("application/xml", 0.9f), new("*/*", 0.8f)])
        ];
    }

    [Fact]
    public void RequestHeader_EmptyName_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestHeader("");
        });
    }

    [Fact]
    public void RequestHeader_BlankName_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestHeader("  ");
        });
    }
}
