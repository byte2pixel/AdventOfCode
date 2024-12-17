using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day13CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day13CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day13Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day13TestData));

        var command = new Day13Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day13", null),
            new AdventSettings { Part = "Part 1" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 13 Part 1");
        console.Output.Should().Contain("The answer is 480");
    }

    [Fact]
    public async Task Day13Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day13TestData));

        var command = new Day13Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day13", null),
            new AdventSettings { Part = "Part 2" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 13 Part 2");
        console.Output.Should().Contain("The answer is 875318608908");
    }
}
