using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.UseCases.Day14;

public sealed class Day14Settings : AdventSettings
{
    [CommandOption("-r|--rows")]
    [Description("The number of rows in the grid")]
    [DefaultValue(103)]
    public required int Rows { get; init; }

    [CommandOption("-c|--columns")]
    [Description("The number of columns in the grid")]
    [DefaultValue(101)]
    public required int Columns { get; init; }

    [CommandOption("-s|--seconds")]
    [Description("The number of seconds to simulate")]
    [DefaultValue(100)]
    public required int Seconds { get; init; }

    public override ValidationResult Validate()
    {
        base.Validate();
        if (Rows % 2 == 0 || Columns % 2 == 0)
            return ValidationResult.Error("Rows and Columns must be odd numbers");
        if (Rows < 1 || Columns < 1)
            return ValidationResult.Error("Rows and Columns must be positive numbers");
        if (Rows == 1 && Columns == 1)
            return ValidationResult.Error("Rows and Columns must be greater than 1");
        if (Seconds < 1)
            return ValidationResult.Error("Seconds must be a positive number");
        return ValidationResult.Success();
    }
}
