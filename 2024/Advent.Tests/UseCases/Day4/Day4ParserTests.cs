using Advent.UseCases.Day4;

namespace Advent.Tests.UseCases.Day4;

public class Day4ParserTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectDimensions()
    {
        var input = "1234\n4567\n7890";
        var result = Day4Parser.Parse(input);

        result.Rows.Should().Be(3);
        result.Columns.Should().Be(4);
    }

    [Fact]
    public void Parse_ShouldCreateCorrectFlatCrossword()
    {
        var input = "123\n456\n789";
        var result = Day4Parser.Parse(input);

        result
            .FlatCrossword.ToArray()
            .Should()
            .BeEquivalentTo(['1', '2', '3', '4', '5', '6', '7', '8', '9']);
    }

    [Fact]
    public void Parse_ShouldThrowArgumentException_WhenLinesHaveDifferentLengths()
    {
        var input = "123\n4567\n890";
        Action act = () => Day4Parser.Parse(input);

        act.Should().Throw<ArgumentException>();
    }
}
