using Advent.UseCases.Day18;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day18CommandTests
{
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day18CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day18Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day18TestData));

        var command = new Day18Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day18", null),
            new Day18Settings
            {
                Part = "Part 1",
                BytesToDrop = 12,
                Rows = 7,
                Columns = 7
            }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 18 Part 1");
        console.Output.Should().Contain("The answer is 22");
    }

    [Fact]
    public async Task Day18Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader
            .ReadInputAsync(Arg.Any<string>())
            .Returns(Task.FromResult(TestData.Day18TestData));

        var command = new Day18Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day18", null),
            new Day18Settings
            {
                Part = "Part 2",
                Rows = 7,
                Columns = 7
            }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 18 Part 2");
        console.Output.Should().Contain("The answer is 6,1");
    }
}
