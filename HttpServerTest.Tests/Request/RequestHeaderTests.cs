using HttpServerTest.Core.Request;

namespace HttpServerTest.Tests.Request;

public class RequestHeaderTests
{
    private static readonly List<RequestHeader> DefaultTestData =
        [
            new("Host", [new("developer.mozilla.org")]),
        new("Accept-Encoding", [new("gzip"), new("deflate"), new("br")]),
        new("Accept", [new("text/html"), new("application/xhtml+xml"), new("application/xml", 0.9f), new("*/*", 0.8f)]),
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
