using System.ComponentModel;
using Advent.Common.Commands;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Common.Settings;

public class AdventSettings : CommandSettings
{
    [CommandOption("-p|--part")]
    [Description("The part of the day to solve, 1, 2 or \"Part 1\", \"Part 2\"")]
    [TypeConverter(typeof(PartChoiceTypeConverter))]
    public PartChoice? PartChoice { get; set; }

    public override ValidationResult Validate()
    {
        return
            PartChoice is not null
            && PartChoice.Choice != Part.Part1
            && PartChoice.Choice != Part.Part2
            ? ValidationResult.Error("Invalid part choice")
            : ValidationResult.Success();
    }
}
