using Advent.Common.Commands;
using Advent.UseCases.Day5;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day5Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var data = Day5Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay5Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day5Part1Solver(),
            Part.Part2 => new Day5Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 5 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
