using Advent.Common.Commands;
using Advent.UseCases.Day11;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day11Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var data = Day11Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay11Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day11Solver(25),
            Part.Part2 => new Day11Solver(75),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 11 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
