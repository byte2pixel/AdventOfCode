using Advent.Tests.Common;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day6;

public class Day6ParserTests
{
    [Fact]
    public void ParseInput_ShouldReturnExpectedResult()
    {
        // Act
        var result = Day6Parser.Parse(TestData.Day6TestData);

        // Assert
        result.Rows.Should().Be(10);
        result.Columns.Should().Be(10);
        result.Length.Should().Be(100);
    }

    [Theory]
    [InlineData(0, "....#.....")]
    [InlineData(1, ".........#")]
    [InlineData(2, "..........")]
    [InlineData(3, "..#.......")]
    [InlineData(4, ".......#..")]
    [InlineData(5, "..........")]
    [InlineData(6, ".#..^.....")]
    [InlineData(7, "........#.")]
    [InlineData(8, "#.........")]
    [InlineData(9, "......#...")]
    public void Parse_ShouldReturnCorrectRowContent(int index, string expected)
    {
        // Act
        var result = Day6Parser.Parse(TestData.Day6TestData);

        // Assert
        result[index].ToString().Should().Be(expected);
    }
}
