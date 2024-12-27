using Advent.Common.Commands;
using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day8CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day8CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day8Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day8TestData));

        var command = new Day8Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day8", null),
            new AdventSettings { PartChoice = new(Part.Part1) }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 8 Part 1");
        console.Output.Should().Contain("The answer is 14");
    }

    [Fact]
    public async Task Day8Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day8TestData));

        var command = new Day8Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day8", null),
            new AdventSettings { PartChoice = new(Part.Part2) }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 8 Part 2");
        console.Output.Should().Contain("The answer is 34");
    }
}
