using Advent.UseCases.Day17;

namespace Advent.Tests.UseCases.Day17;

public class Day17Part2SolverTests
{
    [Fact]
    public void Solve_WhenGivenExample_ReturnsExpected()
    {
        // Arrange
        var data = new Day17Data
        {
            RegisterA = 2024,
            RegisterB = 0,
            RegisterC = 0,
            Opcode = [0, 5, 3],
            Operand = [3, 4, 0],
            OriginalProgram = "0,3,5,4,3,0"
        };
        var solver = new Day17Part2Solver();

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be("117440");
    }
}
