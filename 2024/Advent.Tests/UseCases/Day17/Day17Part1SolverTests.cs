using Advent.UseCases.Day17;

namespace Advent.Tests.UseCases.Day17;

public class Day17Part1SolverTests
{
    [Fact]
    public void Solve_WhenGivenExample_ReturnsExpected()
    {
        // Arrange
        var data = new Day17Data
        {
            RegisterA = 729,
            RegisterB = 0,
            RegisterC = 0,
            Opcode = [0, 5, 3],
            Operand = [1, 4, 0]
        };
        var solver = new Day17Part1Solver();

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be("4,6,3,5,6,3,5,2,1,0");
    }

    [Fact]
    public void Solve_WhenGiven_Sample1_ReturnsExpected()
    {
        var data = new Day17Data
        {
            RegisterA = 2024,
            RegisterB = 0,
            RegisterC = 9,
            Opcode = [0, 5, 3],
            Operand = [1, 4, 0],
        };

        var solver = new Day17Part1Solver();

        var result = solver.Solve(data);
        result.Should().Be("4,2,5,6,7,7,7,7,3,1,0");
    }

    [Fact]
    public void Solve_WhenGiven_Sample2_ReturnsExpected()
    {
        var data = new Day17Data
        {
            RegisterA = 10,
            RegisterB = 0,
            RegisterC = 9,
            Opcode = [5, 5, 5],
            Operand = [0, 1, 4],
        };

        var solver = new Day17Part1Solver();

        var result = solver.Solve(data);
        result.Should().Be("0,1,2");
    }
}
