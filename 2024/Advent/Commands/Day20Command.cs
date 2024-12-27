using Advent.Common;
using Advent.Common.Commands;
using Advent.UseCases.Day20;
using Advent.UseCases.Day6;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day20Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<Day20Settings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, Day20Settings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day20input.txt");
        var data = Day6Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay6Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day20Solver(settings.Threshold, 2),
            Part.Part2 => new Day20Solver(settings.Threshold, 20),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 20 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
