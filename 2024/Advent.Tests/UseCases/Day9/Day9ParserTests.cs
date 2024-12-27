using Advent.UseCases.Day9;

namespace Advent.Tests.UseCases.Day9;

public class Day9ParserTests
{
    [Fact]
    public void Parse_WhenInputIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        var input = "";

        // Act
        Action act = () => Day9Parser.Parse(input);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Parse_WhenInputIsInvalid_ThrowsInvalidOperationException()
    {
        // Arrange
        var input = "0";

        // Act
        Action act = () => Day9Parser.Parse(input);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Parse_WhenInputIsValid_DiskMap()
    {
        // Arrange
        var input = "12345";
        uint[] expected =
        [
            0,
            uint.MaxValue,
            uint.MaxValue,
            1,
            1,
            1,
            uint.MaxValue,
            uint.MaxValue,
            uint.MaxValue,
            uint.MaxValue,
            2,
            2,
            2,
            2,
            2,
        ];

        // Act
        var result = Day9Parser.Parse(input);

        // Assert
        result.ToArray().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Parse_WhenInputIsValie_DiskMap2()
    {
        var data = TestData.GetDay9ParsedData();
        // Act
        Span<uint> result = Day9Parser.Parse(TestData.Day9ParserInput);

        var resultArray = result.ToArray();
        // Assert
        resultArray.Should().NotBeNull();
        resultArray.Should().HaveCount(data.Length);
        resultArray.Should().BeEquivalentTo(data);
    }
}
