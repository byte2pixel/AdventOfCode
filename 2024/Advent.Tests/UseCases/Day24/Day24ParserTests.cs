using Advent.UseCases.Day24;

namespace Advent.Tests.UseCases.Day24;

public class Day24ParserTests
{
    [Fact]
    public void Parse_WhenGivenInput_ReturnsDay24Input()
    {
        // Arrange
        var input =
            "x00: 1\nx01: 0\ny00: 1\ny01: 0\n\nx00 XOR y01 -> mjb\ny01 OR x00 -> tnw\nmjb AND tnw -> z01\n";

        // Act
        var result = Day24Parser.Parse(input);

        // Assert
        result.Wires.Should().HaveCount(7);
        result.Wires.Should().Contain(w => w.Name == "x00" && w.Signal == true);
        result.Wires.Should().Contain(w => w.Name == "x01" && w.Signal == false);
        result.Gates.Should().HaveCount(3);
        result
            .Gates.Should()
            .Contain(g =>
                g.Lhs == "x00"
                && g.Rhs == "y01"
                && g.Type == LogicGate.Xor
                && g.OutputWireName == "mjb"
            );
    }
}
