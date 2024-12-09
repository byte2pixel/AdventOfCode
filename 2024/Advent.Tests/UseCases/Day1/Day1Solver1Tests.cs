using Advent.UseCases.Day1;

namespace Advent.Tests.UseCases.Day1;

public class Day1Solver1Tests
{
    [Fact]
    public void Solve_ShouldReturnCorrectResult()
    {
        // Arrange
        var solver = new Day1Part1Solver();
        var input = (new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 });

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(11);
    }

    [Fact]
    public void Solve_ShouldThrowArgumentException_WhenInputListsAreEmpty()
    {
        // Arrange
        var solver = new Day1Part1Solver();
        var input = (new List<int>(), new List<int>());

        // Act
        Action act = () => solver.Solve(input);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Input lists cannot be empty");
    }

    [Fact]
    public void Solve_ShouldThrowArgumentException_WhenInputListsHaveDifferentLengths()
    {
        // Arrange
        var solver = new Day1Part1Solver();
        var input = (new List<int> { 1, 2, 3 }, new List<int> { 1, 2 });

        // Act
        Action act = () => solver.Solve(input);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Input lists must have the same length");
    }
}
