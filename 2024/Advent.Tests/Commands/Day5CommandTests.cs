using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day5CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day5CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day5Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day5TestData));

        var command = new Day5Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day5", null),
            new AdventSettings { Part = "Part 1" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 5 Part 1");
        console.Output.Should().Contain("The answer is 143");
    }
}
