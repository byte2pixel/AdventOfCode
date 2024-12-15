using Advent.UseCases.Day11;

namespace Advent.Tests.UseCases.Day11;

public class Day11ParserTests
{
    [Fact]
    public void Parser_ShouldReturnCorrectData1()
    {
        // Arrange
        var data = Day11Parser.Parse(TestData.Day11TestData);

        // Assert
        data.Should().HaveCount(5);
        data.Should().BeEquivalentTo([0, 1, 10, 99, 999]);
    }

    [Fact]
    public void Parser_ShouldReturnCorrectData2()
    {
        // Arrange
        var data = Day11Parser.Parse("1 2024 1 0 9 9 2021976\n");

        // Assert
        data.Should().HaveCount(7);
        data.Should().BeEquivalentTo([1, 2024, 1, 0, 9, 9, 2021976]);
    }
}
