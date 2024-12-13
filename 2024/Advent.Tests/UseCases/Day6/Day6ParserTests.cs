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

    [Fact]
    public void ParseInput_Day8_ShouldReturnExpectedResult()
    {
        // Act
        var result = Day6Parser.Parse(TestData.Day8TestData);

        // Assert
        result.Rows.Should().Be(12);
        result.Columns.Should().Be(12);
        result.Length.Should().Be(144);
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

    [Theory]
    [InlineData(0, "............")]
    [InlineData(1, "........0...")]
    [InlineData(2, ".....0......")]
    [InlineData(3, ".......0....")]
    [InlineData(4, "....0.......")]
    [InlineData(5, "......A.....")]
    [InlineData(6, "............")]
    [InlineData(7, "............")]
    [InlineData(8, "........A...")]
    [InlineData(9, ".........A..")]
    [InlineData(10, "............")]
    [InlineData(11, "............")]
    public void Parse_Day8_ShouldReturnCorrectRowContent(int index, string expected)
    {
        // Act
        var result = Day6Parser.Parse(TestData.Day8TestData);

        // Assert
        result[index].ToString().Should().Be(expected);
    }
}
