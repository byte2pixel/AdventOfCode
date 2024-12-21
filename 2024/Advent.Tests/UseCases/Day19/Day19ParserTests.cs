using Advent.UseCases.Day19;

namespace Advent.Tests.UseCases.Day19;

public class Day19ParserTests
{
    [Fact]
    public void Parse_ShouldReturn_BuildingBlocksAndTargets()
    {
        // Arrange
        var input = TestData.Day19TestData;

        // Act
        var (buildingBlocks, targets) = Day19Parser.Parse(input);

        // Assert
        buildingBlocks
            .Should()
            .BeEquivalentTo(new List<string> { "r", "wr", "b", "g", "bwu", "rb", "gb", "br" });
        targets
            .Should()
            .BeEquivalentTo(
                new List<string>
                {
                    "brwrr",
                    "bggr",
                    "gbbr",
                    "rrbgbr",
                    "ubwu",
                    "bwurrg",
                    "brgr",
                    "bbrgwb"
                }
            );
    }
}
