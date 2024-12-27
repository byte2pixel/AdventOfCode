using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day24;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day24Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day24input.txt");
        var data = Day24Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay24Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day24Part1Solver(),
            Part.Part2 => new Day24Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 24 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
