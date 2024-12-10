using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day1CommandTests
{
    private const string TestData = "3   4\n4   3\n2   5\n1   3\n3   9\n3   3";
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day1CommandTests() { }

    [Fact]
    public async Task Day1Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        var command = new Day1Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day1", null),
            new AdventSettings { Part = "Part 1" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 1 Part 1");
        console.Output.Should().Contain("The answer is 11");
    }

    [Fact]
    public async Task Day1Command_Solves_Part2_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        var command = new Day1Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day1", null),
            new AdventSettings { Part = "Part 2" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 1 Part 2");
        console.Output.Should().Contain("The answer is 31");
    }

    [Fact]
    public async Task Day1Command_Throws_If_Part_Is_Invalid()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        var command = new Day1Command(mockReader, console);
        Func<Task> act = async () =>
            await command.ExecuteAsync(
                new CommandContext(_arguments, _remaining, "day1", null),
                new AdventSettings { Part = "Part 3" }
            );
        await act.Should()
            .ThrowAsync<InvalidOperationException>()
            .WithMessage("Invalid part choice");
    }
}
