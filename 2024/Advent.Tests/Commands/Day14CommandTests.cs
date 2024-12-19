using Advent.UseCases.Day14;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day14CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day14CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day14Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day14TestData));

        var command = new Day14Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day14", null),
            new Day14Settings
            {
                Part = "Part 1",
                Seconds = 100,
                Rows = 7,
                Columns = 11
            }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 14 Part 1");
        console.Output.Should().Contain("The answer is 12");
    }

    [Fact]
    public async Task Day14Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day14TestData));

        var command = new Day14Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day14", null),
            new Day14Settings
            {
                Part = "Part 2",
                Seconds = 1,
                Rows = 7,
                Columns = 11
            }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 14 Part 2");
        console.Output.Should().Contain("The answer is 10000");
    }
}
