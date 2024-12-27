using Advent.Common;
using Advent.Common.Commands;
using Advent.UseCases.Day18;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day18Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<Day18Settings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, Day18Settings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day18input.txt");
        var data = Day18Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay18Solver solver = choice.Choice switch
        {
            Part.Part1
                => new Day18Part1Solver(settings.Rows, settings.Columns, settings.BytesToDrop),
            Part.Part2 => new Day18Part2Solver(settings.Rows, settings.Columns),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        (string result, string? grid) = solver.Solve(data);
        if (grid is not null)
            _console.MarkupLine(grid);
        _console.MarkupLine($"[bold green]Day 18 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
