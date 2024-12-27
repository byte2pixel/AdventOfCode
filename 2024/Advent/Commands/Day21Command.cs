using Advent.Common.Commands;
using Advent.UseCases.Day21;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day21Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var data = Day21Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay21Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day21Solver(2),
            Part.Part2 => new Day21Solver(25),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 21 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
