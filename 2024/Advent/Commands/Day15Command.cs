using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day15;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day15Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day15input.txt");
        var choice = settings.PartChoice ?? PromptForPartChoice();

        Day15Data data;
        IDay15Solver solver;
        switch (choice.Choice)
        {
            case Part.Part1:
                data = Day15Parser.Parse(input);
                solver = new Day15Part1Solver();
                break;
            case Part.Part2:
                data = Day15Parser.ResizeGrid(Day15Parser.Parse(input));
                solver = new Day15Part2Solver();
                break;
            default:
                _console.MarkupLine("[red]Invalid choice[/]");
                return 1;
        }

        (int result, string[]? gridData) = solver.Solve(data);
        if (gridData is not null)
            DisplayGrid(gridData);
        _console.MarkupLine($"[bold green]Day 15 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
