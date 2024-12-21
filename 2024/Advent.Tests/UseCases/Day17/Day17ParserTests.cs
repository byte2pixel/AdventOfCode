namespace Advent.Tests.UseCases.Day17;

using Advent.UseCases.Day17;

public class Day17ParserTests
{
    [Fact]
    public void Parse_WhenGivenInput_ReturnsDay17Data()
    {
        // Arrange
        var expected = new Day17Data
        {
            RegisterA = 729,
            RegisterB = 0,
            RegisterC = 0,
            Opcode = [0, 5, 3],
            Operand = [1, 4, 0],
            OriginalProgram = "0,1,5,4,3,0"
        };

        // Act
        var result = Day17Parser.Parse(TestData.Day17TestData);

        // Assert
        result.RegisterA.Should().Be(expected.RegisterA);
        result.RegisterB.Should().Be(expected.RegisterB);
        result.RegisterC.Should().Be(expected.RegisterC);
        result.Opcode.Should().Equal(expected.Opcode);
        result.Operand.Should().Equal(expected.Operand);
        result.OriginalProgram.Should().Be(expected.OriginalProgram);
    }
}
