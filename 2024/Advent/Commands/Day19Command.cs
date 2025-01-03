using Advent.Common.Commands;
using Advent.UseCases.Day19;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day19Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var (buildingBlocks, targets) = Day19Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay19Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day19Part1Solver(),
            Part.Part2 => new Day19Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(buildingBlocks, targets);
        _console.MarkupLine($"[bold green]Day 19 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
