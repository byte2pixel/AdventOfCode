using System.ComponentModel;
using Advent.Common.Settings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.UseCases.Day4;

public sealed class Day4Settings : AdventSettings
{
    [CommandOption("-w|--word")]
    [Description("The word to search for in the crossword puzzle")]
    [DefaultValue("XMAS")]
    public string Word { get; init; } = "XMAS";

    public override ValidationResult Validate()
    {
        base.Validate();
        return string.IsNullOrWhiteSpace(Word)
            ? ValidationResult.Error("Invalid word to search for")
            : ValidationResult.Success();
    }
}
