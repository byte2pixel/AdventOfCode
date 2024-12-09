using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day2CommandTests
{
    private const string TestData =
        "7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9";
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();

    [Fact]
    public async Task Day2Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        var command = new Day2Command(mockReader);
        AnsiConsole.Record();
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day2", null),
            new Day2Command.Settings { Part = "Part 1" }
        );
        result.Should().Be(0);
        var text = AnsiConsole.ExportText();
        text.Should().Contain("Day 2 Part 1");
        text.Should().Contain("The answer is 2");
    }

    [Fact]
    public async Task Day2Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        var command = new Day2Command(mockReader);
        AnsiConsole.Record();
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day2", null),
            new Day2Command.Settings { Part = "Part 2" }
        );
        result.Should().Be(0);
        var text = AnsiConsole.ExportText();
        text.Should().Contain("Day 2 Part 2");
        text.Should().Contain("The answer is 4");
    }
}
