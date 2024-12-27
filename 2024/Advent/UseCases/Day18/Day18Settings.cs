using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.UseCases.Day18;

public sealed class Day18Settings : AdventSettings
{
    [CommandOption("-r|--rows")]
    [Description("The number of rows in the grid")]
    [DefaultValue(71)]
    public required int Rows { get; init; }

    [CommandOption("-c|--columns")]
    [Description("The number of columns in the grid")]
    [DefaultValue(71)]
    public required int Columns { get; init; }

    [CommandOption("-b|--bytes")]
    [Description("The number of bytes to drop on grid")]
    [DefaultValue(1024)]
    public int BytesToDrop { get; init; }

    public override ValidationResult Validate()
    {
        base.Validate();
        if (Rows % 2 == 0 || Columns % 2 == 0)
            return ValidationResult.Error("Rows and Columns must be odd numbers");
        if (Rows < 1 || Columns < 1)
            return ValidationResult.Error("Rows and Columns must be positive numbers");
        if (Rows == 1 && Columns == 1)
            return ValidationResult.Error("Rows and Columns must be greater than 1");
        if (BytesToDrop < 1 || BytesToDrop > Rows * Columns)
            return ValidationResult.Error(
                "Bytes to drop must be a positive number\nand less than the number of cells in the grid"
            );
        return ValidationResult.Success();
    }
}
