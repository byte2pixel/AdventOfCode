using Advent.Common.Commands;
using Advent.UseCases.Day20;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day20CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day20CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day20Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day20TestData));

        var command = new Day20Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day20", null),
            new Day20Settings { PartChoice = new(Part.Part1), Threshold = 0 }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 20 Part 1");
        console.Output.Should().Contain("The answer is 44");
    }

    [Fact]
    public async Task Day20Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day20TestData));

        var command = new Day20Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day20", null),
            new Day20Settings { PartChoice = new(Part.Part2), Threshold = 50 }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 20 Part 2");
        console.Output.Should().Contain("The answer is 285");
    }
}
