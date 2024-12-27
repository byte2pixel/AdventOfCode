using Advent.Common.Commands;
using Advent.UseCases.Day17;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day17Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var data = Day17Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay17Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day17Part1Solver(),
            Part.Part2 => new Day17Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 17 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
