using Advent.Common.Commands;
using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day22CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day22CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day22Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day22TestData));

        var command = new Day22Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day22", null),
            new AdventSettings { PartChoice = new(Part.Part1) }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 22 Part 1");
        console.Output.Should().Contain("The answer is 37327623");
    }

    [Fact]
    public async Task Day22Command_Solves_Part2_Correctly()
    {
        var data = "1\n" + "2\n" + "3\n" + "2024\n";
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(data));

        var command = new Day22Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day22", null),
            new AdventSettings { PartChoice = new(Part.Part2) }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 22 Part 2");
        console.Output.Should().Contain("The answer is 23");
    }
}
