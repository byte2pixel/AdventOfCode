using Advent.Common.Settings;
using Advent.UseCases.Day4;
using Spectre.Console.Cli;

namespace Advent.Tests.Commands;

public class Day4CommandTests
{
    // data that is a 10x10 crossword puzzle
    private const string TestData =
        "MMMSXXMASM\nMSAMXMSMSA"
        + "\nAMXSXMAAMM\nMSAMASMSMX"
        + "\nXMASAMXAMM\nXXAMMXXAMA"
        + "\nSMSMSASXSS\nSAXAMASAAA"
        + "\nMAMMMXMMMM\nMXMXAXMASX";
    private readonly List<string> _arguments = [];
    private readonly IRemainingArguments _remaining = Substitute.For<IRemainingArguments>();
    private readonly TestConsole console = new();

    public Day4CommandTests()
    {
        console.Profile.Capabilities.Interactive = true;
    }

    [Fact]
    public async Task Day4Command_Solves_Part1_Correctly()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        var command = new Day4Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day4", null),
            new Day4Settings { Part = "Part 1" }
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 4 Part 1");
        console.Output.Should().Contain("The answer is 18");
    }

    // [Fact]
    // public async Task Day3Command_Solves_Part2_Correctly()
    // {
    //     string TestData2 =
    //         "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
    //     var mockReader = Substitute.For<IFileReader>();
    //     mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData2));

    //     var command = new Day3Command(mockReader, console);
    //     var result = await command.ExecuteAsync(
    //         new CommandContext(_arguments, _remaining, "day3", null),
    //         new AdventSettings { Part = "Part 2" }
    //     );
    //     result.Should().Be(0);
    //     console.Output.Should().Contain("Day 3 Part 2");
    //     console.Output.Should().Contain("The answer is 48");
    // }

    [Fact]
    public async Task Day4Command_Prompts_For_Part_1()
    {
        var mockReader = Substitute.For<IFileReader>();
        mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

        console.Input.PushKey(ConsoleKey.Enter);

        var command = new Day4Command(mockReader, console);
        var result = await command.ExecuteAsync(
            new CommandContext(_arguments, _remaining, "day4", null),
            new Day4Settings()
        );
        result.Should().Be(0);
        console.Output.Should().Contain("Day 4 Part 1");
        console.Output.Should().Contain("The answer is 18");
    }

    // [Fact]
    // public async Task Day4Command_Prompts_For_Part_2()
    // {
    //     var mockReader = Substitute.For<IFileReader>();
    //     mockReader.ReadInputAsync(Arg.Any<string>()).Returns(Task.FromResult(TestData));

    //     console.Input.PushKey(ConsoleKey.DownArrow);
    //     console.Input.PushKey(ConsoleKey.Enter);

    //     var command = new Day3Command(mockReader, console);
    //     var result = await command.ExecuteAsync(
    //         new CommandContext(_arguments, _remaining, "day4", null),
    //         new AdventSettings()
    //     );
    //     result.Should().Be(0);
    //     console.Output.Should().Contain("Day 4 Part 2");
    //     console.Output.Should().Contain("The answer is 48");
    // }
}