using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.UseCases.Day20;

public sealed class Day20Settings : AdventSettings
{
    [CommandOption("-t|--threshold")]
    [Description("Shortcuts with a savings less than this threshold will be ignored")]
    [DefaultValue(100)]
    public int Threshold { get; set; }

    public override ValidationResult Validate()
    {
        base.Validate();
        if (Threshold < 1)
            return ValidationResult.Error("Threshold must be a positive number");
        return ValidationResult.Success();
    }
}
