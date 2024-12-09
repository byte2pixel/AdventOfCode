using System.ComponentModel;
using Advent.Common;
using Advent.UseCases.Day2;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day2Command(IFileReader reader) : AsyncCommand<Day2Command.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-p|--part")]
        [Description("The part of the day to solve, Part 1 or Part 2")]
        public string? Part { get; init; }

        public override ValidationResult Validate()
        {
            return Part is not null && Part is not ("Part 1" or "Part 2")
                ? ValidationResult.Error("Invalid part choice")
                : ValidationResult.Success();
        }
    }

    private readonly IFileReader _reader = reader;
    private readonly Day2Parser _parser = new();

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day2input.txt");
        var data = _parser.Parse(input);

        var choice =
            settings.Part
            ?? AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Advent of Code 2024[/]")
                    .AddChoices("Part 1", "Part 2")
            );
        IDay2Solver solver = choice switch
        {
            "Part 1" => new Day2Part1Solver(),
            "Part 2" => new Day2Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        AnsiConsole.MarkupLine($"[bold green]Day 2 {choice} [/]");
        AnsiConsole.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
