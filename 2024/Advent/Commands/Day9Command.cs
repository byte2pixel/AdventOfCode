using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day9;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day9Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day9input.txt");
        var parser = new Day9Parser();
        var data = parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay9Solver solver = choice switch
        {
            "Part 1" => new Day9Part1Solver(),
            "Part 2" => new Day9Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 9 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
