using Advent.Common.Commands;
using Advent.UseCases.Day1;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day1Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync(context.Name);
        var data = Day1Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay1Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day1Part1Solver(),
            Part.Part2 => new Day1Part2Solver(),
            _ => throw new InvalidOperationException("Invalid part choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 1 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
