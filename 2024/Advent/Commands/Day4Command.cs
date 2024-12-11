using Advent.Common;
using Advent.Common.Commands;
using Advent.UseCases.Day4;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day4Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<Day4Settings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, Day4Settings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day4input.txt");
        var data = Day4Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay4Solver solver = choice switch
        {
            "Part 1" => new Day4Part1Solver(settings.Word),
            // "Part 2" => new Day3Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 4 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
