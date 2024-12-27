using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day6;
using Advent.UseCases.Day8;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day8Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day8input.txt");
        var data = Day6Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay6Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day8Part1Solver(),
            Part.Part2 => new Day8Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 8 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
