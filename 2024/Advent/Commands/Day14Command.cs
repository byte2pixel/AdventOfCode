using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day14;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day14Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<Day14Settings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, Day14Settings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day14input.txt");
        var data = Day14Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay14Solver solver = choice switch
        {
            "Part 1" => new Day14Part1Solver(),
            "Part 2" => new Day14Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        (int result, string[]? gridData) = solver.Solve(data, settings);
        _console.MarkupLine($"[bold green]Day 14 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        if (gridData is not null)
        {
            DisplayGrid(gridData);
        }
        return 0;
    }

    private void DisplayGrid(string[] gridData)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn());
        foreach (var row in gridData)
        {
            grid.AddRow(new Text(row).Centered());
        }
        _console.Write(grid);
    }
}
