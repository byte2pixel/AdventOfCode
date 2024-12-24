using Advent.UseCases.Day21;

namespace Advent.Tests.UseCases.Day21;

public class Day21ParserTests
{
    [Fact]
    public void Parse_Returns_Correct_Data()
    {
        var input = TestData.Day21TestData;
        var result = Day21Parser.Parse(input);
        result.Should().HaveCount(5);
        result.Should().Contain("029A");
        result.Should().Contain("980A");
        result.Should().Contain("179A");
        result.Should().Contain("379A");
    }
}
