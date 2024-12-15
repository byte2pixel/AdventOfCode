using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day11;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day11Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day11input.txt");
        var data = Day11Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay11Solver solver = choice switch
        {
            "Part 1" => new Day11Solver(25),
            "Part 2" => new Day11Solver(75),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 11 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
