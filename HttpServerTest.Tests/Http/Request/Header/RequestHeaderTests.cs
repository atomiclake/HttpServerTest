using HttpServerTest.Core.Http.Request.Header;

namespace HttpServerTest.Tests.Http.Request.Header;

public class RequestHeaderTests
{
    private static readonly List<RequestHeader> DefaultTestData =
    [
        new("Host", [new("developer.mozilla.org")]),
        new("Accept-Encoding", [new("gzip"), new("deflate"), new("br")]),
        new("Accept", [new("text/html"), new("application/xhtml+xml"), new("application/xml", 0.9f), new("*/*", 0.8f)]),
    ];

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

    [Fact]
    public void RequestHeader_SingleValue_ProducesCorrectString()
    {
        // Arrange
        var actualData = DefaultTestData[0].ToString();

        // Act
        string expectedValue = "Host: developer.mozilla.org";

        // Assert
        Assert.Equal(expectedValue, actualData, true, true, true, false);
    }

    [Fact]
    public void RequestHeader_MultipleValues_ProducesCorrectString()
    {
        // Arrange
        var actualData = DefaultTestData[1].ToString();

        // Act
        string expectedValue = "Accept-Encoding: gzip,deflate,br";

        // Assert
        Assert.Equal(expectedValue, actualData, true, true, true, false);
    }

    [Fact]
    public void RequestHeader_MultipleValuesWithQuality_ProducesCorrectString()
    {
        // Arrange
        var actualData = DefaultTestData[2].ToString();

        // Act
        string expectedValue = "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

        // Assert
        Assert.Equal(expectedValue, actualData, true, true, true, false);
    }
}
