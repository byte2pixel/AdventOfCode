using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day16CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day16CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day16Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day16TestData2));

        var command = new Day16Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day16", null),
            new AdventSettings { Part = "Part 1" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 16 Part 1");
        console.Output.Should().Contain("The answer is 11048");
    }

    [Fact]
    public async Task Day16Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day16TestData2));

        var command = new Day16Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day16", null),
            new AdventSettings { Part = "Part 2" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 16 Part 2");
        console.Output.Should().Contain("The answer is 64");
    }
}
