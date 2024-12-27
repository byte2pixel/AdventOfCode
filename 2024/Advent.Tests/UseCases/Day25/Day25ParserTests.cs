using Advent.UseCases.Day25;

namespace Advent.Tests.UseCases.Day25;

public class Day25ParserTests
{
    [Fact]
    public void Parse_WhenInputIsValid_ReturnsDay25Input()
    {
        // Arrange
        var expectedLocks = new List<GridData>
        {
            new(["#####", ".####", ".####", ".####", ".#.#.", ".#...", "....."]),
            new(["#####", "##.##", ".#.##", "...##", "...#.", "...#.", "....."])
        };

        var expectedKeys = new List<GridData>
        {
            new([".....", "#....", "#....", "#...#", "#.#.#", "#.###", "#####"]),
            new([".....", ".....", "#.#..", "###..", "###.#", "###.#", "#####"]),
            new([".....", ".....", ".....", "#....", "#.#..", "#.#.#", "#####"])
        };

        // Act
        (var locks, var keys) = Day25Parser.Parse(TestData.Day25TestData);

        // Assert
        locks.Should().HaveCount(2);
        locks.Should().BeEquivalentTo(expectedLocks);
        keys.Should().HaveCount(3);
        keys.Should().BeEquivalentTo(expectedKeys);
    }
}
