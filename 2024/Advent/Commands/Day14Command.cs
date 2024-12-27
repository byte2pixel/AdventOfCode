using Advent.Common.Commands;
using Advent.UseCases.Day14;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day14Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<Day14Settings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, Day14Settings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var data = Day14Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay14Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day14Part1Solver(),
            Part.Part2 => new Day14Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        (int result, string[]? gridData) = solver.Solve(data, settings);
        if (gridData is not null)
            DisplayGrid(gridData);
        _console.MarkupLine($"[bold green]Day 14 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
