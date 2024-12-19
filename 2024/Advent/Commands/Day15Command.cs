using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day15;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day15Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day15input.txt");
        var data = Day15Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay15Solver solver = choice switch
        {
            "Part 1" => new Day15Part1Solver(),
            "Part 2" => new Day15Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        (int result, string[]? gridData) = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 15 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        if (gridData is not null)
        {
            DisplayGrid(gridData);
        }
        return 0;
    }
}
