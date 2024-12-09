using Advent.UseCases.Day2;

namespace Advent.Tests.UseCases.Day2;

public class Day2ParserTests
{
    private const string TestData =
        "7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9";

    [Fact]
    public void Parse_ShouldReturnCorrectNumberOfLists()
    {
        // Arrange
        var parser = new Day2Parser();

        // Act
        var result = parser.Parse(TestData).ToList();

        // Assert
        result.Count.Should().Be(6);
        result[0].Should().BeEquivalentTo([7, 6, 4, 2, 1]);
        result[1].Should().BeEquivalentTo([1, 2, 7, 8, 9]);
        result[2].Should().BeEquivalentTo([9, 7, 6, 2, 1]);
        result[3].Should().BeEquivalentTo([1, 3, 2, 4, 5]);
        result[4].Should().BeEquivalentTo([8, 6, 4, 4, 1]);
        result[5].Should().BeEquivalentTo([1, 3, 6, 7, 9]);
    }
}
