using Advent.Common.Commands;
using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day21CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day21CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day21Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day21TestData));

        var command = new Day21Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day21", null),
            new AdventSettings { PartChoice = new(Part.Part1) }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 21 Part 1");
        console.Output.Should().Contain("The answer is 126384");
    }

    [Fact]
    public async Task Day21Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day21TestData));

        var command = new Day21Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day21", null),
            new AdventSettings { PartChoice = new(Part.Part2) }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 21 Part 2");
        console.Output.Should().Contain("The answer is 154115708116294");
    }
}
