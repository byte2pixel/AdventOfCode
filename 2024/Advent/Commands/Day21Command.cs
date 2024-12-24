using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day21;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day21Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day21input.txt");
        var data = Day21Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay21Solver solver = choice switch
        {
            "Part 1" => new Day21Part1Solver(2),
            "Part 2" => new Day21Part1Solver(25),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 21 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
