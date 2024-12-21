using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day19;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day19Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day19input.txt");
        var (buildingBlocks, targets) = Day19Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay19Solver solver = choice switch
        {
            "Part 1" => new Day19Part1Solver(),
            "Part 2" => new Day19Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(buildingBlocks, targets);
        _console.MarkupLine($"[bold green]Day 19 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
