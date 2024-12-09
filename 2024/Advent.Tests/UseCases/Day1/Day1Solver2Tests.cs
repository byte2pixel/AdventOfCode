using Advent.UseCases.Day1;

namespace Advent.Tests.UseCases.Day1;

public class Day1Solver2Tests
{
    [Fact]
    public void Solve_ShouldReturnCorrectResult()
    {
        // Arrange
        var solver = new Day1Part2Solver();
        var input = (new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 });

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(31);
    }

    [Fact]
    public void Solve_ShouldThrowArgumentException_WhenInputListsAreEmpty()
    {
        // Arrange
        var solver = new Day1Part2Solver();
        var input = (new List<int>(), new List<int>());

        // Act
        Action act = () => solver.Solve(input);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Input lists cannot be empty");
    }
}
