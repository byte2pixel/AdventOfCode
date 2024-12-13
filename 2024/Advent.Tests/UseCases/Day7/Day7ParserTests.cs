using Advent.UseCases.Day7;

namespace Advent.Tests.UseCases.Day7;

public class Day7ParserTests
{
    [Fact]
    public void ParseInput_ShouldReturnExpectedResult()
    {
        // Act
        var result = Day7Parser.Parse(TestData.Day7TestData);
        (int, int[])[] expectedResult =
        [
            (190, [10, 19]),
            (3267, [81, 40, 27]),
            (83, [17, 5]),
            (156, [15, 6]),
            (7290, [6, 8, 6, 15]),
            (161011, [16, 10, 13]),
            (192, [17, 8, 14]),
            (21037, [9, 7, 18, 13]),
            (292, [11, 6, 16, 20]),
        ];
        result.Should().BeEquivalentTo(expectedResult);
    }
}
