using System.ComponentModel;
using System.Globalization;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Common.Commands;

public enum Part
{
    Part1,
    Part2
}

public abstract class AdventCommand<TSettings>(IFileReader reader, IAnsiConsole console)
    : AsyncCommand<TSettings>
    where TSettings : CommandSettings
{
    protected readonly IAnsiConsole _console = console;
    protected readonly IFileReader _reader = reader;

    protected virtual PartChoice PromptForPartChoice()
    {
        return _console.Prompt(
            new SelectionPrompt<PartChoice>()
                .Title("[bold green]Advent of Code 2024[/]")
                .UseConverter(choice => choice.Name)
                .AddChoices(new PartChoice(Part.Part1), new PartChoice(Part.Part2))
        );
    }

    protected virtual void DisplayGrid(string[] gridData)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn());
        foreach (var row in gridData)
        {
            grid.AddRow(new Text(row).Centered());
        }
        _console.Write(grid);
    }
}

public class PartChoice(Part choice)
{
    public Part Choice { get; } = choice;

    public string Name =>
        Choice switch
        {
            Part.Part1 => "Part 1",
            Part.Part2 => "Part 2",
            _ => throw new InvalidOperationException("Invalid choice")
        };

    public override string ToString() => Name;
}

public class PartChoiceTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object? ConvertFrom(
        ITypeDescriptorContext? context,
        CultureInfo? culture,
        object value
    )
    {
        if (value is string strValue)
        {
            return strValue.Trim() switch
            {
                "1" or "Part 1" => new PartChoice(Part.Part1),
                "2" or "Part 2" => new PartChoice(Part.Part2),
                _ => throw new ArgumentException($"Invalid part choice: {strValue}")
            };
        }

        return base.ConvertFrom(context, culture, value);
    }
}
