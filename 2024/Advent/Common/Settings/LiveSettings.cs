using System.ComponentModel;
using Spectre.Console.Cli;

namespace Advent.Common.Settings;

public sealed class LiveSettings : AdventSettings
{
    [CommandOption("-l|--live")]
    [Description("Process the solution in real time")]
    [DefaultValue(false)]
    public required bool Live { get; init; }
}
