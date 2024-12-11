using System.ComponentModel;
using Advent.Common.Settings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.UseCases.Day4;

public sealed class Day4Settings : AdventSettings
{
    [CommandOption("-w|--word")]
    [Description("The word to search for in the crossword puzzle")]
    public required string Word { get; init; }

    public override ValidationResult Validate()
    {
        base.Validate();
        if (string.IsNullOrWhiteSpace(Word))
            return ValidationResult.Error("Word must be provided using the -w|--word option");
        if (Part == "Part 2" && Word?.Length % 2 == 0)
            return ValidationResult.Error("Word must have an odd length for Part 2");
        return ValidationResult.Success();
    }
}
