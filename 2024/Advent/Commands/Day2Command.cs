using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day2;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day2Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    private readonly Day2Parser _parser = new();

    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day2input.txt");
        var data = _parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay2Solver solver = choice switch
        {
            "Part 1" => new Day2Part1Solver(),
            "Part 2" => new Day2Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 2 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
