using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day23;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day23Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day23input.txt");
        var data = Day23Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay23Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day23Part1Solver(),
            Part.Part2 => new Day23Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 23 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
