using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day21;
using Advent.UseCases.Day22;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day22Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day22input.txt");
        var data = Day21Parser.Parse(input);

        var choice = settings.PartChoice ?? PromptForPartChoice();
        IDay21Solver solver = choice.Choice switch
        {
            Part.Part1 => new Day22Part1Solver(2000),
            Part.Part2 => new Day22Part2Solver(2000),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 22 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
