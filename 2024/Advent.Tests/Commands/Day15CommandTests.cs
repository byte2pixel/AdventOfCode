using Advent.Common.Commands;
using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day15CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day15CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day15Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day15TestData));

        var command = new Day15Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day15", null),
            new LiveSettings { PartChoice = new(Part.Part1), Live = false, }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 15 Part 1");
        console.Output.Should().Contain("The answer is 10092");
    }

    [Fact]
    public async Task Day15Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day15TestData));

        var command = new Day15Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day15", null),
            new LiveSettings { PartChoice = new(Part.Part2), Live = false, }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 15 Part 2");
        console.Output.Should().Contain("The answer is 9021");
    }
}
