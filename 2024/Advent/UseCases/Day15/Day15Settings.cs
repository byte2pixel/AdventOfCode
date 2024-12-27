using System.ComponentModel;
using Advent.Common.Settings;
using Spectre.Console.Cli;

namespace Advent.UseCases.Day15;

public sealed class Day15Settings : AdventSettings
{
    [CommandOption("-l|--live")]
    [Description("Process the solution in real time")]
    [DefaultValue(false)]
    public required bool Live { get; init; }
}
