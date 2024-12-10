using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day1;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day1Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    private readonly Day1Parser _parser = new();

    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day1input.txt");
        var data = _parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay1Solver solver = choice switch
        {
            "Part 1" => new Day1Part1Solver(),
            "Part 2" => new Day1Part2Solver(),
            _ => throw new InvalidOperationException("Invalid part choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 1 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
