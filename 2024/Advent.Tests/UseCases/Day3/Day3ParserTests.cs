using Advent.UseCases.Day3;

namespace Advent.Tests.UseCases.Day3;

public class Day3ParserTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectResult()
    {
        // Arrange
        var input = "R8,U5,L5,D3\nU7,R6,D4,L4";
        var expected = "R8,U5,L5,D3U7,R6,D4,L4";

        // Act
        var result = Day3Parser.Parse(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Parse_ShouldReturnEmptyString_WhenInputIsEmpty()
    {
        // Arrange
        var input = "";

        // Act
        var result = Day3Parser.Parse(input);

        // Assert
        result.Should().Be("");
    }
}
