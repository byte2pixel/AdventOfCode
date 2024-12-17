using Advent.UseCases.Day13;

namespace Advent.Tests.UseCases.Day13;

public class Day13ParserTests
{
    [Fact]
    public void Parser_ShouldReturnCorrectData1()
    {
        // Arrange
        var data = Day13Parser.Parse(TestData.Day13TestData);

        // Assert
        data.Should().HaveCount(4);
        data[0].Points.Should().HaveCount(2);
        data[1].Points.Should().HaveCount(2);
        data[2].Points.Should().HaveCount(2);
        data[3].Points.Should().HaveCount(2);

        data[0].Destination.Should().BeEquivalentTo(new Point { X = 8400, Y = 5400 });
        data[1].Destination.Should().BeEquivalentTo(new Point { X = 12748, Y = 12176 });
        data[2].Destination.Should().BeEquivalentTo(new Point { X = 7870, Y = 6450 });
        data[3].Destination.Should().BeEquivalentTo(new Point { X = 18641, Y = 10279 });

        data[0]
            .Points[0]
            .Should()
            .BeEquivalentTo(
                new WeightedPoint
                {
                    X = 94,
                    Y = 34,
                    Weight = 3
                }
            );
        data[0]
            .Points[1]
            .Should()
            .BeEquivalentTo(
                new WeightedPoint
                {
                    X = 22,
                    Y = 67,
                    Weight = 1
                }
            );
        data[3]
            .Points[0]
            .Should()
            .BeEquivalentTo(
                new WeightedPoint
                {
                    X = 69,
                    Y = 23,
                    Weight = 3
                }
            );
        data[3]
            .Points[1]
            .Should()
            .BeEquivalentTo(
                new WeightedPoint
                {
                    X = 27,
                    Y = 71,
                    Weight = 1
                }
            );
    }
}
