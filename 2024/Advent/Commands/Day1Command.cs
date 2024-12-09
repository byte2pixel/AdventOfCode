using System.ComponentModel;
using Advent.Common;
using Advent.UseCases.Day1;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day1Command(IFileReader reader) : AsyncCommand<Day1Command.Settings>
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
    private readonly Day1Parser _parser = new();

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day1input.txt");
        var data = _parser.Parse(input);

        var choice =
            settings.Part
            ?? AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Advent of Code 2024[/]")
                    .AddChoices("Part 1", "Part 2")
            );
        IDay1Solver solver = choice switch
        {
            "Part 1" => new Day1Part1Solver(),
            "Part 2" => new Day1Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        AnsiConsole.MarkupLine($"[bold green]Day 1 {choice} [/]");
        AnsiConsole.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
