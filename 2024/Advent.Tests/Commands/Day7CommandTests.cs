using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day7CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day7CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day7Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day7TestData));

        var command = new Day7Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day7", null),
            new AdventSettings { Part = "Part 1" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 7 Part 1");
        console.Output.Should().Contain("The answer is 3749");
    }

    [Fact]
    public async Task Day7Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day7TestData));

        var command = new Day7Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day7", null),
            new AdventSettings { Part = "Part 2" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 7 Part 2");
        console.Output.Should().Contain("The answer is 11387");
    }
}
