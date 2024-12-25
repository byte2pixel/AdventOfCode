namespace Advent.Tests.UseCases.Day23;

using Advent.UseCases.Day23;

public class Day23ParserTests
{
    [Fact]
    public void Parse_WhenInputIsValid_ReturnsParsedData()
    {
        // Arrange
        var expected = new List<(string, string)>
        {
            ("kh", "tc"),
            ("qp", "kh"),
            ("de", "cg"),
            ("ka", "co"),
            ("yn", "aq"),
            ("qp", "ub"),
            ("cg", "tb"),
            ("vc", "aq"),
            ("tb", "ka"),
            ("wh", "tc"),
            ("yn", "cg"),
            ("kh", "ub"),
            ("ta", "co"),
            ("de", "co"),
            ("tc", "td"),
            ("tb", "wq"),
            ("wh", "td"),
            ("ta", "ka"),
            ("td", "qp"),
            ("aq", "cg"),
            ("wq", "ub"),
            ("ub", "vc"),
            ("de", "ta"),
            ("wq", "aq"),
            ("wq", "vc"),
            ("wh", "yn"),
            ("ka", "de"),
            ("kh", "ta"),
            ("co", "tc"),
            ("wh", "qp"),
            ("tb", "vc"),
            ("td", "yn"),
        };

        // Act
        var actual = Day23Parser.Parse(TestData.Day23TestData);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
