using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Common.Settings;

public class AdventSettings : CommandSettings
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
